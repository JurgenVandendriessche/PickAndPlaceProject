/*  Copyright (C) 2017  Jurgen Vandendriessche

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Mono.Data.Sqlite;

namespace PickAndPlaceLib
{
    /// <summary>
    /// Static class that contains all methods for reading and writing data to the database
    /// </summary>
    public static class DatabaseOperations
    {
        private static string connectionString = "Data Source=" +
            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PickAndPlace", "pnpFootprints.db") +
                                                ";Version=3; FailIfMissing=True; Foreign Keys=True;";
        //Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "PickAndPlace", "pnpFootprints.db")
        //3 parameters: path seperator is different on windows (\\) and linux (//)

        /// <summary>
        /// Loads the data of the database into the datatable
        /// </summary>
        /// <param name="result">Datatable to be filled</param>
        public static void GetFootprintDataTable(System.Data.DataTable result)
        {
            string sqlString = @"SELECT f.manufacturerPartNumber,f.width,f.length,f.height,f.rotation,f.offsetStackX,f.offsetStackY,f.feedRate,n.name as nozzle,s.name as stackType
                                FROM footprints f, nozzles n,stackTypes s
                                WHERE n.id = f.nozzle_id
                                AND s.id = f.StackType_id ";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                //dbConnection.Open();
                using (SqliteDataAdapter dataAdap = new SqliteDataAdapter(dbCommand))
                {
                    result.Clear();
                    dataAdap.Fill(result);
                }
                //dbConnection.Close();
            }
        }

        /// <summary>
        /// Gets a specific footprint out of the database
        /// </summary>
        /// <param name="partNumber">manufacturer part number of the searched part</param>
        /// <returns>Footprint of the mpm</returns>
        public static Footprint GetFootprint(string partNumber)
        {
            return GetFootprint(partNumber, connectionString);
        }

        /// <summary>
        /// Get the footprint from the database specified by the connectionstring
        /// </summary>
        /// <param name="partNumber">manufacturer part number to be loaded</param>
        /// <param name="connectionString_">connectionstring for the sqlite database</param>
        /// <returns>Footprint of the mpm</returns>
        private static Footprint GetFootprint(string partNumber, string connectionString_)
        {
            Footprint result = null;
            string sqlString = @"SELECT f.manufacturerPartNumber,f.width,f.length,f.height,f.rotation,f.offsetStackX,f.offsetStackY,f.feedRate,n.name as nozzle,s.name as stackType
                                FROM footprints f, nozzles n,stackTypes s
                                WHERE n.id = f.nozzle_id
                                AND s.id = f.StackType_id
                                AND f.manufacturerPartNumber = @manufacturerPartNumber";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString_))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                dbConnection.Open();
                dbCommand.Parameters.AddWithValue("manufacturerPartNumber", partNumber);
                using (SqliteDataReader reader = dbCommand.ExecuteReader())
                {
                    reader.Read();
                    if (reader.HasRows)
                    {
                        string partNumber_ = reader["manufacturerPartNumber"].ToString();
                        float width_ = float.Parse(reader["width"].ToString());
                        float length_ = float.Parse(reader["length"].ToString());
                        float height_ = float.Parse(reader["height"].ToString());
                        int rotation_ = Int32.Parse(reader["rotation"].ToString());
                        float offsetX_ = float.Parse(reader["offsetStackX"].ToString());
                        float offsetY_ = float.Parse(reader["offsetStackY"].ToString());
                        float feedRate = float.Parse(reader["feedRate"].ToString());
                        Nozzle nozzle = PNPconverterTools.StringToNozzle(reader["nozzle"].ToString());
                        StackType stackType = PNPconverterTools.StringToStackType(reader["stackType"].ToString());

                        result = new Footprint(partNumber_, width_, length_, height_, rotation_, offsetX_, offsetY_, feedRate, nozzle, stackType);
                    }
                }
                dbConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Set all the sql command parameters with the values of the footprint, sqlCommand is passed by reference
        /// </summary>
        /// <param name="sqlCommand">sqlite command</param>
        /// <param name="footprint">footprint with parameters</param>
        private static void SetParametersSqlString(SqliteCommand sqlCommand, Footprint footprint)
        {
            //http://stackoverflow.com/questions/6001016/why-c-sharp-dont-let-to-pass-a-using-variable-to-a-function-as-ref-or-out
            //no ref -> should be fine
            sqlCommand.Parameters.AddWithValue("manufacturerPartNumber", footprint.ManufacturerPartNumber);
            sqlCommand.Parameters.AddWithValue("width", Math.Round(footprint.Width, 2));
            sqlCommand.Parameters.AddWithValue("length", Math.Round(footprint.Length, 2));
            sqlCommand.Parameters.AddWithValue("height", Math.Round(footprint.Height, 2));
            sqlCommand.Parameters.AddWithValue("rotation", footprint.Rotation);
            sqlCommand.Parameters.AddWithValue("offsetStackX", Math.Round(footprint.OffsetStackX, 2));
            sqlCommand.Parameters.AddWithValue("offsetStackY", Math.Round(footprint.OffsetStackY, 2));
            sqlCommand.Parameters.AddWithValue("feedRate", Math.Round(footprint.FeedRate, 2));
            sqlCommand.Parameters.AddWithValue("nozzle", footprint.Nozzle.ToString());
            sqlCommand.Parameters.AddWithValue("stackType", footprint.StackType.ToString());
        }

        /// <summary>
        /// Adds a new footprint to the database
        /// </summary>
        /// <param name="footprint">Footprint to be added</param>
        public static void AddNewFootprint(Footprint footprint)
        {
            string sqlString = @"INSERT INTO footprints(manufacturerPartNumber,width,length,height,rotation,offsetStackX,offsetStackY,feedRate,nozzle_id,stackType_id)
                                 VALUES(@manufacturerPartNumber,@width,@length,@height,@rotation,@offsetStackX,@offsetStackY,@feedRate,
                                 (SELECT n.id FROM nozzles n WHERE n.name = @nozzle),
                                 (SELECT s.id FROM stackTypes s WHERE s.name = @stackType));";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                dbConnection.Open();
                SetParametersSqlString(dbCommand, footprint);
                dbCommand.ExecuteNonQuery();
                dbConnection.Clone();
            }
        }

        /// <summary>
        /// Removes the the footprint with coresponding manufacturerPartNumber from the database
        /// </summary>
        /// <param name="manufacturerPartNumber">manufacturer part number to be removed</param>
        public static void RemoveFootprint(string manufacturerPartNumber)
        {
            string sqlString = "DELETE FROM footprints WHERE manufacturerPartNumber= @manufacturerPartNumber";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                dbConnection.Open();
                dbCommand.Parameters.AddWithValue("manufacturerPartNumber", manufacturerPartNumber);
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /// <summary>
        /// Updates all the values of the footprint with the new values, based on the manufacturerPartNumber
        /// </summary>
        /// <param name="footprint">footprint with new values</param>
        public static void UpdateFootprint(Footprint footprint)
        {
            string sqlString = @"UPDATE footprints
                                 SET width=@width, length=@length, height=@height, rotation=@rotation,
                                     offsetStackX=@offsetStackX, offsetStackY=@offsetStackY, feedRate=@feedRate,
                                     nozzle_id=(SELECT n.id FROM nozzles n WHERE n.name = @nozzle),
                                     stackType_id=(SELECT s.id FROM stackTypes s WHERE s.name = @stackType)
                                 WHERE manufacturerPartNumber = @manufacturerPartNumber;";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                dbConnection.Open();
                SetParametersSqlString(dbCommand, footprint);
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
        }

        /// <summary>
        /// Check if the manufacturere part number exists in the database
        /// </summary>
        /// <param name="manufacturerPartNumber">mpn to check</param>
        /// <returns>true if the mpn exists in the database, else false</returns>
        public static bool FootprintExists(string manufacturerPartNumber)
        {
            bool result;
            string sqlString = @"SELECT count(*) as ""exists""
                                 FROM footprints f
                                 WHERE f.manufacturerPartNumber = @manufacturerPartNumber";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                dbConnection.Open();
                dbCommand.Parameters.AddWithValue("manufacturerPartNumber", manufacturerPartNumber);
                using (SqliteDataReader reader = dbCommand.ExecuteReader())
                {
                    reader.Read();
                    result = reader["exists"].ToString() == "1";
                }
                dbConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Gets a list of all the manufacturer part numbers in the database
        /// </summary>
        /// <returns>list of all the manufacturer part numbers in the database</returns>
        public static List<string> GetFootprintList()
        {
            return GetFootprintList(connectionString);
        }

        /// <summary>
        /// Gets a list of all the manufacturer part numbers in the database specified by the connectionstring
        /// </summary>
        /// <param name="connectionString">connectionstring for the sqlite database</param>
        /// <returns>list of all the manufacturer part numbers in the database</returns>
        private static List<string> GetFootprintList(string connectionString)
        {
            List<string> result = new List<string>();
            string sqlString = "SELECT f.manufacturerPartNumber as manufacturerPartNumber FROM footprints f";
            using (SqliteConnection dbConnection = new SqliteConnection(connectionString))
            using (SqliteCommand dbCommand = new SqliteCommand(sqlString, dbConnection))
            {
                dbConnection.Open();
                using (SqliteDataReader reader = dbCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader["manufacturerPartNumber"].ToString());
                    }
                }
                dbConnection.Close();
            }
            return result;
        }

        /// <summary>
        /// Import external database into this database
        /// </summary>
        /// <param name="path">Path to the database to be imported</param>
        /// <param name="progress">Progress class to report to</param>
        public static void ImportDatabase(string path, IProgress<Tuple<int, int>> progress)
        {
            //http://stackoverflow.com/questions/19768718/updating-progressbar-external-class
            string externalConnectionString = "Data Source=" + path + "; Version=3; FailIfMissing=True; Foreign Keys=True;";
            List<string> externalFootprints = GetFootprintList(externalConnectionString); //list of all MPN in the external database
            List<string> internalFootprints = GetFootprintList(connectionString); //list of all the MPN in the internal database
            List<string> difference = externalFootprints.Except(internalFootprints).ToList(); //list of all the MPN that are in the external database and not in the internal database
            int numberOfDifferences = difference.Count;
            int counter = 0;
            progress.Report(new Tuple<int, int>(counter, numberOfDifferences));
            foreach (string manufacturerPartNumber in difference)
            {
                counter++;
                Footprint newFootprint = GetFootprint(manufacturerPartNumber, externalConnectionString); //Get the footprint from the other database
                AddNewFootprint(newFootprint);//And add it to our database
                progress.Report(new Tuple<int, int>(counter, numberOfDifferences));
            }
        }
    }
}

/*https://www.codeproject.com/Articles/837599/Using-Csharp-to-connect-to-and-query-from-a-SQL-da */
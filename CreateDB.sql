CREATE TABLE "footprints" (
	"manufacturerPartNumber" VARCHAR NOT NULL PRIMARY KEY ASC,
	"width" REAL,
	"length" REAL,
	"height" REAL,
	"rotation" INTEGER,
	"offsetStackX" REAL,
	"offsetStackY" REAL,
	"feedRate" REAL,
	"nozzle_id" INTEGER REFERENCES nozzles (id),
	"StackType_id" INTEGER REFERENCES stackTypes (id)
);

CREATE TABLE "nozzles" (
	"id" INTEGER NOT NULL PRIMARY KEY ASC,
	"name" VARCHAR);

CREATE TABLE "stackTypes" (
	"id" INTEGER NOT NULL PRIMARY KEY ASC,
	"name" VARCHAR);

INSERT INTO nozzles(name) VALUES("XS");
INSERT INTO nozzles(name) VALUES("S");
INSERT INTO nozzles(name) VALUES("M");
INSERT INTO nozzles(name) VALUES("ML");

INSERT INTO stackTypes(name) VALUES("Reel08mm");
INSERT INTO stackTypes(name) VALUES("Reel12mm");
INSERT INTO stackTypes(name) VALUES("Reel16mm");
INSERT INTO stackTypes(name) VALUES("Tray18mm");
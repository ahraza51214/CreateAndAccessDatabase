-- 02_tableCreate
USE SuperheroesDb;

-- Creating the Superhero table
CREATE TABLE Superhero (
    Id INT IDENTITY(1,1) PRIMARY KEY ,
    Name VARCHAR(MAX),
    Alias VARCHAR(MAX),
    Origin VARCHAR(MAX)
);
-- Creating the Assistant table
CREATE TABLE Assistant (
    Id INT IDENTITY(1,1) PRIMARY KEY ,
    Name VARCHAR(MAX)
);
-- Creating the Power table
CREATE TABLE Power (
    Id INT IDENTITY(1,1) PRIMARY KEY ,
    Name VARCHAR(MAX),
    Description TEXT
);
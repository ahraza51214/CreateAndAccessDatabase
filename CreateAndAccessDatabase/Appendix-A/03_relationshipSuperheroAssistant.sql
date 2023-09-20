-- 03_relationshipSuperheroAssistant
USE SuperheroesDb;

-- Addding a foreign key to Assistant referencing Superhero
ALTER TABLE Assistant
ADD SuperheroId INT;

-- Addding a foreign key constraint
ALTER TABLE Assistant
ADD CONSTRAINT FK_Assistant_Superhero
FOREIGN KEY (SuperheroId)
REFERENCES Superhero(Id);
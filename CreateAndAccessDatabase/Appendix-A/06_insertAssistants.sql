-- 06_insertAssistants.sql
USE SuperheroesDb;

-- Inserting three assistants and associate them with superheroes
INSERT INTO Assistant (Name, SuperheroId)
VALUES
    ('ThunderDog', 1), -- Associates with Superhero PGS
    ('Thanos', 2), -- Associates with Superhero AHR
    ('WildMonkey', 3); -- Associates with Superhero EAS
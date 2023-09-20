-- 07_powers.sql
USE SuperheroesDb;

-- Inserting four powers
INSERT INTO Power (Name, Description)
VALUES
    ('Fly', 'Travel long distance in air without any objects support'),
    ('ThunderBolt', 'Strike with lightning'),
    ('Chaos', 'Destroy Universe'),
    ('Teleport', 'Dissappear from one location and Appear in another location anywhere in the universe');

-- Associating superheroes with powers
INSERT INTO SuperheroPower (SuperheroId, PowerId)
VALUES
    (1, 1), -- Superhero PGS has Power Fly
	(1, 2), -- Superhero PGS has Power ThunderBolt
    (2, 1), -- Superhero AHR has Power Fly
	(2, 3), -- Superhero AHR has Power Chaos
    (3, 1), -- Superhero EAS has Power Fly
    (3, 4); -- Superhero EAS has Power Teleport
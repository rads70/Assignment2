INSERT INTO dbo.Power([Name],[Description])
VALUES ('Flight','Power of flight'),
('Strength', 'Super Strength'),
('Speed', 'Run super fast'),
('Laser eyes','Laser eyes to burn through everything')
GO

INSERT INTO SuperHeroesDb.dbo.SuperHeroPowers([PowerId],[SuperheroId])
VALUES (1,1),
(2,1),
(2,2),
(1,4),
(3,3)
GO
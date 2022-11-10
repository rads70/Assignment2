CREATE TABLE SuperHeroPowers
(
[SuperheroId] INT,
[PowerId] INT,
PRIMARY KEY ([SuperheroId],[PowerId])
)
GO

ALTER TABLE [SuperHeroPowers]
ADD CONSTRAINT [FK_PowerSuperheroId]
FOREIGN KEY ([SuperheroId]) REFERENCES [SuperHero]([Id])

GO

ALTER TABLE [SuperHeroPowers]
ADD CONSTRAINT [FK_PowerId]
FOREIGN KEY ([PowerId]) REFERENCES [Power]([Id])

GO
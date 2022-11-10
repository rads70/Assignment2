ALTER TABLE Assistant 
	ADD [SuperheroId] INT
	CONSTRAINT FK_SuperheroId
	FOREIGN KEY ([SuperheroId]) REFERENCES SuperHero([Id])
GO
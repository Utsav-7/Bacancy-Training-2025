ALTER TABLE Tournaments ADD TotalMatches INT;
UPDATE Tournaments SET TotalMatches = 1;

SELECT * FROM Players;
SELECT * FROM Tournaments;
SELECT * FROM MatchResults;

EXEC sp_help Players;
EXEC sp_help Tournaments;
EXEC sp_help MatchResults;
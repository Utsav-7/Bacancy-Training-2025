-- 1. Define Table Relationships:  Connect Players with MatchResults and Tournaments.
SELECT *
FROM MatchResults AS MS
INNER JOIN Players AS P
ON MS.PlayerID = P.PlayerID
INNER JOIN Tournaments AS T
ON MS.TournamentID = T.TournamentID;


-- 2. Implement Keys: Use PKs for unique identification and FKs to link match results.
EXEC sp_pkeys 'Players';
EXEC sp_pkeys 'Tournaments';


-- 3. Create Views: Design views to track tournament results and player performance.
CREATE VIEW PlayerPerformance AS
SELECT P.Name, P.Sport, T.Name AS Tournament_Name, T.Date, T.Location, MS.Score
FROM MatchResults AS MS
INNER JOIN Players AS P
ON MS.PlayerID = P.PlayerID
INNER JOIN Tournaments AS T
ON MS.TournamentID = T.TournamentID;

SELECT * FROM PlayerPerformance;


-- 4. SQL Functions: Develop a function to compute the average score for each player.
CREATE FUNCTION fn_AvgScoreOfAllPlayers()
RETURNS TABLE
AS
RETURN
(
    SELECT 
        P.PlayerID,
        P.Name,
        AVG(MR.Score) AS AvgScore
    FROM Players P
    JOIN MatchResults MR ON P.PlayerID = MR.PlayerID
    GROUP BY P.PlayerID, P.Name
);

SELECT * FROM dbo.fn_AvgScoreOfAllPlayers();


-- 5. Stored Procedures: Write a stored procedure to record match results and update player rankings.
CREATE PROCEDURE PlayersRanking
AS
BEGIN
    SELECT 
        P.Name, 
        AVG(MR.Score) AS AverageScore
    FROM Players P
    INNER JOIN MatchResults MR
        ON P.PlayerID = MR.PlayerID
    GROUP BY P.Name
    ORDER BY AverageScore DESC;
END;
EXEC PlayersRanking;


-- 6. SQL Joins: Write JOIN queries to combine data from Players, Tournaments, and MatchResults for complete performance reports.
SELECT P.Name, P.Contact, P.Sport, T.Name AS Tournament_Name, T.Date, T.Location, MS.Score
FROM MatchResults AS MS
INNER JOIN Players AS P
ON MS.PlayerID = P.PlayerID
INNER JOIN Tournaments AS T
ON MS.TournamentID = T.TournamentID;


-- 7. Indexes: Create indexes on PlayerID, TournamentID, and Date to improve query performance.
CREATE INDEX IX_Players ON Players (PlayerID);
CREATE INDEX IX_Tournaments ON Tournaments (TournamentID, Date);

DROP INDEX Tournaments.IX_Tournaments; -- Drop Index by using table name 
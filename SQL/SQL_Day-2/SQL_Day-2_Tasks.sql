-- NOTES: Query from 1 to 7 are completed previously.

-- ---------------------------------------------------------------------------------------------------
-- 8. Triggers: Implement a trigger to automatically update tournament standings when match scores are recorded.
CREATE TRIGGER trg_UpdateTournamentStandings
ON MatchResults
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    -- Update TotalMatches count in Tournaments when a new match is inserted
    UPDATE Tournaments
    SET TotalMatches = TotalMatches + 1
    FROM Tournaments t
    JOIN inserted i ON t.TournamentID = i.TournamentID;
    
    PRINT 'Tournament standings updated successfully!';
END;

drop trigger trg_UpdateTournamentStandings

INSERT INTO MatchResults (MatchID,PlayerID, TournamentID, Score)
VALUES 
    (19, 1, 1, 50),  
    (20, 2, 1, 40),
    (21, 3, 3, 30);

SELECT * FROM Tournaments;

-- ---------------------------------------------------------------------------------------------------
-- 9. Cursors: Use a cursor to iterate through match results and compile player performance summaries.

DECLARE @PlayerID INT, @TotalScore INT, @MatchesPlayed INT;

-- Declare a cursor to fetch PlayerID and compute performance summaries
DECLARE PlayerPerformanceCursor CURSOR FOR
SELECT PlayerID, SUM(Score) AS TotalScore, COUNT(MatchID) AS MatchesPlayed
FROM MatchResults
GROUP BY PlayerID;

-- Open the cursor
OPEN PlayerPerformanceCursor;

-- Fetch the first row
FETCH NEXT FROM PlayerPerformanceCursor INTO @PlayerID, @TotalScore, @MatchesPlayed;

-- Iterate through the cursor
WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Player ID: ' + CAST(@PlayerID AS VARCHAR) +
          ', Total Score: ' + CAST(@TotalScore AS VARCHAR) +
          ', Matches Played: ' + CAST(@MatchesPlayed AS VARCHAR);

    -- Fetch next row
    FETCH NEXT FROM PlayerPerformanceCursor INTO @PlayerID, @TotalScore, @MatchesPlayed;
END;

-- Close and deallocate the cursor
CLOSE PlayerPerformanceCursor;
DEALLOCATE PlayerPerformanceCursor;

-- ---------------------------------------------------------------------------------------------------
-- 10. Temporary Tables: Store temporary match results before finalizing tournament rankings.
CREATE TABLE #TempMatchResults (
    MatchID INT PRIMARY KEY,
    PlayerID INT,
    TournamentID INT,
    Score INT
);
INSERT INTO #TempMatchResults (MatchID, PlayerID, TournamentID, Score) VALUES (1, 1, 1, 87);

SELECT * FROM #TempMatchResults; 

-- ---------------------------------------------------------------------------------------------------
-- 11. CTE: Use a CTE to list players with the highest win percentage.

WITH PlayerWins AS (
    -- Count the number of wins per player (highest score in a tournament)
    SELECT 
        m.PlayerID, 
        COUNT(*) AS Wins
    FROM MatchResults m
    JOIN (
        -- Find the highest score in each tournament
        SELECT TournamentID, MAX(Score) AS MaxScore
        FROM MatchResults
        GROUP BY TournamentID
    ) t ON m.TournamentID = t.TournamentID AND m.Score = t.MaxScore
    GROUP BY m.PlayerID
),
PlayerMatches AS (
    -- Count total matches played by each player
    SELECT PlayerID, COUNT(*) AS TotalMatches
    FROM MatchResults
    GROUP BY PlayerID
),
WinPercentage AS (
    -- Calculate win percentage for each player
    SELECT 
        pm.PlayerID,
        COALESCE(pw.Wins, 0) AS Wins, 
        pm.TotalMatches,
        (COALESCE(pw.Wins, 0) * 100.0 / pm.TotalMatches) AS WinPercent
    FROM PlayerMatches pm
    LEFT JOIN PlayerWins pw ON pm.PlayerID = pw.PlayerID
)
-- Select players sorted by highest win percentage
SELECT p.Name, w.Wins, w.TotalMatches, w.WinPercent
FROM WinPercentage w
JOIN Players p ON w.PlayerID = p.PlayerID
ORDER BY w.WinPercent DESC;


-- ---------------------------------------------------------------------------------------------------
--12. Constraints: Add a NOT NULL constraint to ensure all match records include player IDs.
ALTER TABLE MatchResults ALTER COLUMN PlayerID INT NOT NULL;
EXEC SP_HELP 'MatchResults';


CREATE TABLE Players (
    PlayerID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Contact VARCHAR(50),
    Sport VARCHAR(50) NOT NULL
);

CREATE TABLE Tournaments (
    TournamentID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Date DATE NOT NULL,
    Location VARCHAR(100) NOT NULL
);

CREATE TABLE MatchResults (
    MatchID INT PRIMARY KEY,
    PlayerID INT,
    TournamentID INT,
    Score INT CHECK (Score >= 0), -- Ensures non-negative scores
    FOREIGN KEY (PlayerID) REFERENCES Players(PlayerID) ON DELETE CASCADE,
    FOREIGN KEY (TournamentID) REFERENCES Tournaments(TournamentID) ON DELETE CASCADE
);

INSERT INTO Players (PlayerID, Name, Contact, Sport) VALUES 
(1, 'Utsav', 8732787238, 'Cricket'),
(2, 'Devansh', 8732723238, 'Hockey'),
(3, 'Yash', 3732787238, 'Kabbaddi'),
(4, 'Mahesh', 5657732738, 'Tennis'),
(5, 'Ram', 3732787238, 'Football'),
(6, 'Rajesh', 432723238, 'Cricket'),
(7, 'Amit', 9988776655, 'Badminton'),
(8, 'Karan', 8877665544, 'Basketball'),
(9, 'Suresh', 7766554433, 'Chess'),
(10, 'Vikas', 6655443322, 'Cricket'),
(11, 'Harsh', 5544332211, 'Football'),
(12, 'Piyush', 4433221100, 'Tennis'),
(13, 'Nirav', 3322110099, 'Hockey'),
(14, 'Vishal', 2211009988, 'Badminton'),
(15, 'Rakesh', 1100998877, 'Table Tennis');

INSERT INTO Tournaments (TournamentID, Name, Date, Location) VALUES 
(1, 'Summer Open', '2025-06-15', 'New York'),
(2, 'Winter Cup', '2025-12-10', 'Los Angeles'),
(3, 'Monsoon Challenge', '2025-08-20', 'Mumbai'),
(4, 'Pro League', '2025-09-05', 'London'),
(5, 'Super League', '2025-07-25', 'Paris'),
(6, 'Global Championship', '2025-11-10', 'Dubai'),
(7, 'Asia Cup', '2025-10-12', 'Delhi'),
(8, 'National Sports Fest', '2025-04-18', 'Sydney'),
(9, 'Spring Invitational', '2025-05-22', 'Tokyo'),
(10, 'Champions Trophy', '2025-06-30', 'Berlin'),
(11, 'Legends Cup', '2025-07-10', 'Moscow'),
(12, 'World Championship', '2025-08-15', 'Toronto'),
(13, 'Elite Cup', '2025-09-28', 'Singapore'),
(14, 'Mega Tournament', '2025-10-05', 'Bangkok'),
(15, 'Ultimate League', '2025-11-20', 'Barcelona');

INSERT INTO MatchResults (MatchID, PlayerID, TournamentID, Score) VALUES 
(1, 1, 1, 85),
(2, 2, 3, 78),
(3, 3, 2, 90),
(4, 4, 5, 67),
(5, 5, 4, 74),
(6, 6, 7, 88),
(7, 7, 6, 92),
(8, 8, 9, 80),
(9, 9, 8, 60),
(10, 10, 10, 95),
(11, 11, 12, 82),
(12, 12, 11, 75),
(13, 13, 14, 89),
(14, 14, 13, 76),
(15, 15, 15, 93);

SELECT * FROM Players;
SELECT * FROM Tournaments;
SELECT * FROM MatchResults;
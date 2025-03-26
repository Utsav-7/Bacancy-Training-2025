# SQL Day - 1 
## Problem Statement: 
- Sports Club Management System
  - Tables & Fields:
    - Players:
      - Fields: PlayerID [PK], Name, Contact, Sport
    - Tournaments:
      - Fields: TournamentID [PK], Name, Date, Location
    - MatchResults:
      - Fields: MatchID [PK], PlayerID [FK], TournamentID [FK], Score
- Practical Tasks:
  - Define Table Relationships:
    - Connect Players with MatchResults and Tournaments.
  - Implement Keys:  
    - Use PKs for unique identification and FKs to link match results.
  - Create Views:
    - Design views to track tournament results and player performance.
  - SQL Functions:
    - Develop a function to compute the average score for each player.
  - Stored Procedures:
    - Write a stored procedure to record match results and update player rankings.
  - SQL Joins:
    - Write JOIN queries to combine data from Players, Tournaments, and MatchResults for complete performance reports.
  - Indexes:
    - Create indexes on PlayerID, TournamentID, and Date to improve query performance.

## Screenshots: 
![Players_Table](https://github.com/user-attachments/assets/d178ccb2-c33c-4d60-a28c-eee4544037db)
![MatchResults_Table](https://github.com/user-attachments/assets/31e9f4f5-3ada-47b6-aad3-b84565518d15)
![Tournaments_Table](https://github.com/user-attachments/assets/91615a30-8291-4e73-b37e-fb364e3602c5)
![Query_1](https://github.com/user-attachments/assets/2662b745-53f9-4afb-a3b6-b78af633615c)
![Query_2_1](https://github.com/user-attachments/assets/bf11f3b5-bac7-4f5d-b494-6f7170d1bab6)
![Query_2_2](https://github.com/user-attachments/assets/41a62211-f9a7-4aa9-a9da-0d933d2e0abf)

# OOPS Day - 1 : Flight Reservation System
## Problem Statement:
- Objective: Implement a Flight Booking System.
  ### Requirements
  - Class Design & Encapsulation
  - Create a Flight class with attributes:
    - FlightID (int)
    - Destination (string)
    - SeatsAvailable (private int)
  - Implement Encapsulation:
    - Restrict direct access to SeatsAvailable (private).
    - Provide methods: GetSeatsAvailable() (getter) and BookSeat(int count) (setter, ensuring seats do not go below zero).
  - Implement:
    - Parameterized Constructor to initialize flight details.
    - Destructor to print a message when a flight is removed.
  ### Tasks to Implement:
  - Create Flights & Manage Availability:
    - Add 3 commercial flights and 2 private jets.
    - Ensure encapsulation restricts modifying seats directly.

## Code: 
- **Flight.cs** called all the methods, constructor, destructor.
- **Program.cs** contains Method that call all the required method from the **Flight.cs**

## Output: 
![Screenshot 2025-02-04 144636](https://github.com/user-attachments/assets/eb704f17-9ec6-44c5-b7af-7955b24b564e)

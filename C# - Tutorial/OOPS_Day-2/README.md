# OOPS Day - 2 : Flight Reservation System
## Problem Statement:
### Inheritance (Base & Derived Classes, base Keyword, Method Overriding)
- Create a base class Transport with common attributes (TransportID, Destination).
- Create derived classes:
  - Flight (inherits Transport and adds seat management).
  - PrivateJet (inherits Flight and adds luxury services).
- Use the base keyword in derived classes to call the parent constructor.
- Override GetTransportDetails() to show flight-specific details.

### Polymorphism (Method Overloading, Method Overriding, Virtual Methods)
- Implement Method Overriding:
  - Use virtual in Transport for DisplayDetails().
  - Override DisplayDetails() in Flight and PrivateJet.

### Abstraction (Abstract Classes vs Interfaces)
- Create interface BookingSystem:
  - method ConfirmBooking().
  - Implement BookingSystem in Flight.
- Create an interface IFlightOperations:
  - void BookTicket(int flightID, int seats);
  - void CancelTicket(int flightID, int seats);
  - void DisplayFlights();
  - Implement Explicit Interface Implementation in FlightManager(New class).

### Sealed Class
- Implement a sealed class ReservationDatabase to manage reservations.
  - Add a method SaveReservation(int flightID, string passengerName).
  
 ### Partial Class
- Implement a partial class FlightOperations:
  - One part handles BookTicket() and CancelTicket().
  - Another part handles UpdateSeats() and DisplayFlights().

### Tasks to Implement:
- Demonstrate Inheritance & Method Overriding:
  - Use base keyword to initialize the Transport fields.
  - Override DisplayDetails() to show detailed information.
- Demonstrate Polymorphism:
  - Override DisplayDetails() from Transport.
- Implement Abstraction:
  - Define BookingSystem as an interface and implement it in Flight
  - Implement IFlightOperations explicitly in FlightManager.
- Use Partial & Sealed Classes:
  - Call ReservationDatabase.SaveReservation(101, "Alice").
  - Use FlightOperations partial class for flight management.
 
## Output Screenshot: 
![Screenshot 2025-02-06 171213](https://github.com/user-attachments/assets/e81932ee-a471-48f8-9ed8-8fe54ee508b8)
![Screenshot 2025-02-06 171230](https://github.com/user-attachments/assets/d2be3824-77ac-4c89-bd5f-cb960fd8d7f5)
![Screenshot 2025-02-06 171246](https://github.com/user-attachments/assets/237be3d6-6ee8-4fd1-825f-f55f4cf0bf11)
![Screenshot 2025-02-06 171305](https://github.com/user-attachments/assets/7e9945ac-27a9-431d-b4d0-a4ee6e09126a)
![Screenshot 2025-02-06 171328](https://github.com/user-attachments/assets/e5d7ea9d-44d6-4ee0-aee3-7583d9fd7e26)


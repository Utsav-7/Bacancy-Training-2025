using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace OOPS_Day_2
{
    public class main
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\tFlight Reservation System");
            Console.WriteLine("---------------------------------------------");

            while (true)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Flight Booking\n2. Private Jet Booking\n3. Flight Manager\n4. Partial Class Access\n5. Exit.");
                int choice = 0;
                Console.Write("Enter your choice: ");
                schoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("---------------------------------------------");

                switch (choice)
                {
                    case 1:
                        try
                        {
                            Console.Write("\t----- Flight Booking System -----\n");
                            Console.Write("Enter Destination: ");
                            string dest = Console.ReadLine();
                            Flight flight = new Flight(dest);
                            Console.Write("Enter Seats: ");
                            int seats = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Passenger Name: ");
                            string name = Console.ReadLine();
                            flight.BookSeat(seats, name);
                            flight.ConfirmBooking();
                            ReservationDatabase db = new ReservationDatabase();
                            db.SaveReservation(flight.flightID, name);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine("Invalid Input. Please try again.");
                        }
                        break;

                    case 2:
                        try
                        {
                            Console.Write("\t----- Private Jet Booking System -----\n");
                            Console.Write("Enter Destination: ");
                            string jetDest = Console.ReadLine();
                            PrivateJet jet = new PrivateJet(jetDest);
                            Console.Write("Enter Seats: ");
                            int seat = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter Passenger Name: ");
                            string pasName = Console.ReadLine();
                            jet.BookSeat(seat, pasName);
                            ReservationDatabase db = new ReservationDatabase();
                            db.SaveReservation(jet.jetID, pasName);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine("Invalid Input. Please try again.");
                        }
                        break;

                    case 3:
                        try
                        {
                            Console.Write("\t----- Flight Manager -----\n");
                            FlightManager manager = new FlightManager();
                            IFlightOperations flightOperations = manager;
                            Console.Write("Enter Seats: ");
                            int managerSeat = Convert.ToInt32(Console.ReadLine());
                            flightOperations.BookTicket(managerSeat);
                            flightOperations.DisplayFlights();
                            Console.Write("\t----- Seat Cancellation -----\n");
                            Console.Write("Enter Flight ID: ");
                            string flightID = Console.ReadLine();
                            Console.Write("Enter No. of Cancel Seats: ");
                            int cancelSeat = Convert.ToInt32(Console.ReadLine());
                            flightOperations.CancelTicket(flightID, cancelSeat);
                            flightOperations.DisplayFlights();
                        }catch(FormatException ex)
                        {
                            Console.WriteLine("Invalid Input. Please try again.");
                        }
                        break;

                    case 4:
                        try
                        {
                            Console.Write("\t----- Partial Class Access -----\n");
                            FlightOperations operations = new FlightOperations();
                            operations.BookTicket();
                            operations.CancelTicket();
                            operations.UpdateSeats();
                            operations.DisplayFlight();
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine("Invalid Input. Please try again.");
                        }
                        break;
                    case 5:
                        Console.WriteLine("Exiting the system...");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. Please select a valid option.");
                        break;
                }
            }
        }
    }
}
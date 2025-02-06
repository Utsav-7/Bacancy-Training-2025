using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *   I have created 2 interface 
 *   1. IBookingSystem 
 *       IBookingSystem has a method ConfirmBooking()
 *   2. IFlightOperations
 *       IFlightOperations has 3 methods BookTicket(), CancelTicket(), DisplayFlights()
 *   I have created a class FlightManager which implements IFlightOperations
 *   I have created a sealed class ReservationDatabase which has a method SaveReservation()
 *   I have created a partial class FlightOperations which has 2 methods BookTicket(), CancelTicket()
 */
namespace OOPS_Day_2
{
    interface IBookingSystem
    {
        public void ConfirmBooking();
    }

    interface IFlightOperations
    {
        public void BookTicket(int seats);
        public void CancelTicket(string flightID, int seats);
        public void DisplayFlights();
    }

    public class FlightManager : IFlightOperations
    {
        private string _flightID;
        private int _totalSeats = 500;

        public FlightManager()
        {
            _flightID = "FL" + new Random().Next(1000, 9999);
        }

        // explicit interface implementation
        void IFlightOperations.BookTicket(int seats)
        {
            try
            {
                if (seats > _totalSeats)
                {
                    throw new Exception("Seats are not available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            _totalSeats -= seats;
            Console.WriteLine($"SUCCESS! Your {seats} seats booked in {_flightID}");
        }

        // explicit interface implementation
        void IFlightOperations.CancelTicket(string flightID, int seats)
        {
            try
            {
                if (seats > _totalSeats)
                {
                    throw new Exception("Seats are not available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            _totalSeats += seats;
            Console.WriteLine($"SUCCESS! Your {seats} seats cancelled in {_flightID}");
        }

        // explicit interface implementation
        void IFlightOperations.DisplayFlights()
        {
            Console.WriteLine($"Flight ID: {_flightID}");
            Console.WriteLine($"No of Seats: {500 - _totalSeats}");
            Console.WriteLine($"Available Seats: {_totalSeats}");
        }
    }

    sealed class ReservationDatabase
    {
        public void SaveReservation(int flightID, string passengerName)
        {
            Console.WriteLine($"Flight ID: {flightID}");
            Console.WriteLine($"Passenger Name: {passengerName}");
            Console.WriteLine("Reservation Saved Successfully");

        }
    }

    partial class FlightOperations
    {
        public void BookTicket()
        {
            Console.WriteLine("Book Ticket in Partial Class");
        }
        public void CancelTicket()
        {
            Console.WriteLine("Cancel Ticket in Partial Class");
        }
    }
}
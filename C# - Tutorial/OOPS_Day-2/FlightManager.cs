using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *   I have created a class FlightManager which implements IFlightOperations
 */
namespace OOPS_Day_2
{
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
}
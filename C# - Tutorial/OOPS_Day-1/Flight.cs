using System;
namespace OOPS_Day_1
{
    public class Flight
    {
        // fields
        private static int _flightID = 100;
        private string _destination;
        private int _seatAvailable = 100;

        // parameterized constructor to initialize flight destination
        public Flight(string destination)
        {
            try
            {
                // check all string has only letter or not
                bool isOnlyLetters = destination.All(c => char.IsLetter(c));
                if (isOnlyLetters)
                {
                    this._destination = destination;
                    _seatAvailable = 100;
                    _flightID++;
                }
                else
                    throw new Exception("Invalid Destination");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public int GetSeatAvailable()
        {
            return _seatAvailable;
        }

        public void BookSeat(int seat)
        {
            if (seat > 0 && seat <= 100)
                this._seatAvailable = this._seatAvailable - seat;
            else if(seat > 100) 
            {
                Console.WriteLine("Insufficient seats...MAX = 100");
                Console.WriteLine("****************************************");
            }
            else
            {
                Console.WriteLine("Seats can't be negative");
                Console.WriteLine("****************************************");
            }
        }

        public void GetBookingDetails()
        {
            Console.WriteLine($"--> Flight ID: {_flightID}");
            Console.WriteLine($"--> Destination: {_destination}");
            Console.WriteLine($"--> Seats Booked: {100 - _seatAvailable}");
            Console.WriteLine($"Currently, Available Seats: {_seatAvailable}");
            Console.WriteLine("----------------------------------------");

        }

        ~Flight()
        {
            Console.WriteLine("Flight is removed SUCCESSFULLY........");
        }
    }
}

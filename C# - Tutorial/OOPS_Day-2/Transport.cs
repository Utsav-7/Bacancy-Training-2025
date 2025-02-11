using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * In this file,
 * I have created a class Transport which is inherit in Flight and PrivateJet class
 */

namespace OOPS_Day_2
{
    public class Transport
    {
        private string _transportID;
        private string _destination;

        protected private string TransportID { get; set; }

        public Transport(string destination)
        {
            _destination = destination;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine("This is Transports DisplayDetails() Method");
        }
    }

    class Flight : Transport, IBookingSystem
    {
        private string _flightID;
        private int _totalSeats = 500;

        public string flightID {
            get
            {
                return _flightID;
            } 
        }

        public Flight(string dest) : base(dest)
        {
            _flightID = "FL" + new Random().Next(1000, 9999);
        }

        public void BookSeat(int count)
        {
            try
            {
                if (count > _totalSeats)
                {
                    throw new Exception("Seats are not available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            _totalSeats -= count;
            Console.WriteLine($"SUCCESS! Your {count} seats booked in {_flightID}");
        }

        public void BookSeat(int count, string passengerName)
        {
            this.BookSeat(count);
            Console.WriteLine($"Passenger Name: {passengerName}");
            this.DisplayDetails();
            Console.WriteLine("---------------------------------------------");
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Flight ID: {_flightID}");
            Console.WriteLine($"No of Seats: {500 - _totalSeats}");
        }
        public void ConfirmBooking()
        {
            Console.WriteLine("SUCCESS! Booking Confirmed");
        }
    }

    class PrivateJet : Transport
    {
        private static int _counter = 1;
        private string _jetID;
        private int _totalSeats = 100;

        public string jetID
        {
            get
            {
                return _jetID;
            }
        }

        public PrivateJet(string dest) : base(dest)
        {
            _jetID = TransportID = "JT" + (_counter++);
        }

        public void BookSeat(int count)
        {
            try
            {
                if (count > _totalSeats)
                {
                    throw new Exception("Seats are not available");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            _totalSeats -= count;
        }
        public void BookSeat(int count, string passengerName)
        {
            this.BookSeat(count);
            Console.WriteLine($"SUCCESS! Your {count} seats booked in {_jetID} & Booked by {passengerName}");
            Console.WriteLine($"Passenger Name: {passengerName}");
            this.DisplayDetails();
            Console.WriteLine("---------------------------------------------");
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Private Jet ID: {_jetID}");
            Console.WriteLine($"No of Seats: {100 - _totalSeats}");
        }
    }
}
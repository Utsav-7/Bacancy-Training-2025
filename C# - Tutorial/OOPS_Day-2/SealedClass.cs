using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Day_2
{
    sealed class ReservationDatabase
    {
        public void SaveReservation(string flightID, string passengerName)
        {
            Console.WriteLine($"Flight ID: {flightID}");
            Console.WriteLine($"Passenger Name: {passengerName}");
            Console.WriteLine("Reservation Saved Successfully");
        }
    }
}

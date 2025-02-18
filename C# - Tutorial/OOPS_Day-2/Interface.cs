using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

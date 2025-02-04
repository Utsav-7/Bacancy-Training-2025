using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPS_Day_1
{
    public class main()
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("\tFlight Management System");
            Console.WriteLine("****************************************");

            
            try
            {
                int count = 0;

                while(count < 5)
                {
                    Console.Write("Enter your destination: ");
                    string dest = Console.ReadLine();
                    Console.Write("Enter no. of seats: ");
                    int seats = Convert.ToInt32(Console.ReadLine());

                    // object creation
                    Flight flight = new Flight(dest);
                    flight.GetSeatAvailable();

                    // seat booking
                    flight.BookSeat(seats);

                    // get the flight details
                    flight.GetBookingDetails();
                    count++;
                }
            }
            catch(FormatException ex)       // throw message if int store invalid format.
            {
                Console.WriteLine("Invalid input format...");
            }

            // pause the screen until user will not press any keys.
            Console.ReadKey();
        }
    }
}
using System;
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
                    Flight flight = new Flight(dest);
                    flight.GetSeatAvailable();
                    flight.BookSeat(seats);
                    flight.GetBookingDetails();
                    count++;
                }
            }
            catch(FormatException ex)       
            {
                Console.WriteLine("Invalid input format...");
            }
            // pause the screen until user will not press any keys.
            Console.ReadKey();
        }
    }
}
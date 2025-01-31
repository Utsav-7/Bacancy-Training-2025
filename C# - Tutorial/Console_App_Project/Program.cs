// See https://aka.ms/new-console-template for more information
using System;


namespace Console_App_Project
{
    public class main
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(" Welcome to School Management System ");
            Console.WriteLine("-------------------------------------");

            int choice = 0;
            Console.WriteLine("1.Student Management\n2. Teacher Management\n3. Class Management");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine(" Welcome to Student Management ");
                    Console.WriteLine("-------------------------------");
                    int innerChoice = 0;
                    Console.WriteLine("1.Add new student\n2. View all student\n3. Update student record.\n4. Delete student record.");
                    Console.Write("Enter your choice: ");
                    innerChoice = Convert.ToInt32(Console.ReadLine());

                    switch (innerChoice)
                    {
                        case 1:
                            Student student = new Student();

                            break;
                    }

                    break;
            }
        }
    }
}
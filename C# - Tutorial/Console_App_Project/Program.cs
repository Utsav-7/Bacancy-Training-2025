// See https://aka.ms/new-console-template for more information
using System;


namespace Console_App_Project
{
    public class main
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=====================================");
            Console.WriteLine(" Welcome to School Management System ");
            Console.WriteLine("=====================================");

            int choice = 0;
            Console.WriteLine("1. Student Management\n2. Teacher Management\n3. Class Management");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("* Welcome to Student Management *");
                    Console.WriteLine("---------------------------------");

                    while (true)
                    {
                        int innerChoice = 0;
                        Console.WriteLine("1. Add new student\n2. View all student\n3. Search student\n4. Update student record.\n5. Delete student record.\n6. exit.");
                        Console.Write("Enter your choice: ");
                        innerChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                        switch (innerChoice)
                        {
                            case 1:
                                Student.AddNewStudent();
                                Console.WriteLine("Hurrey!... New student added in the records.");
                                break;
                            case 2:
                                Student.ViewStudents();
                                break;
                            case 3:
                                Student.SearchStudent();
                                break;
                            case 4:
                                Console.Write("Enter student roll no (For Update): ");
                                int updateRollNo = Convert.ToInt32(Console.ReadLine());
                                Student.UpdateStudent(updateRollNo);
                                break;
                            case 5:
                                Console.Write("Enter student roll no (For Delete): ");
                                int deleteRollNo = Convert.ToInt32(Console.ReadLine());
                                Student.DeleteStudent(deleteRollNo);
                                break;
                            case 6:
                                return;
                            default:
                                Console.WriteLine("Invalid Choice... :( ");
                                break;
                        }
                        Console.WriteLine("---------------------------------");
                    }


                    break;
            }
        }
    }
}
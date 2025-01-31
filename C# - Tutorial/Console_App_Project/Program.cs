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
            Console.WriteLine("1. Student Management\n2. Teacher Management\n3. Class Management\n4. Exit");
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

                case 2:
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("* Welcome to Teacher Management *");
                    Console.WriteLine("---------------------------------");

                    while (true)
                    {
                        int innerChoice = 0;
                        Console.WriteLine("1. Add new teacher\n2. View all teacher\n3. Search teacher\n4. Update teacher record.\n5. Delete teacher record.\n6. exit.");
                        Console.Write("Enter your choice: ");
                        innerChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                        switch (innerChoice)
                        {
                            case 1:
                                Teacher.AddNewTeacher();
                                Console.WriteLine("Hurrey!... New teacher added in the records.");
                                break;
                            case 2:
                                Teacher.ViewTeacher();
                                break;
                            case 3:
                                Teacher.SearchTeacher();
                                break;
                            case 4:
                                Console.Write("Enter teacher's employee ID (For Update): ");
                                int updateEmployeeID = Convert.ToInt32(Console.ReadLine());
                                Teacher.UpdateTeacher(updateEmployeeID);
                                break;
                            case 5:
                                Console.Write("Enter teacher's employee ID (For Delete): ");
                                int deleteEmployeeID = Convert.ToInt32(Console.ReadLine());
                                Teacher.DeleteTeacher(deleteEmployeeID);
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

                case 3:
                    break;

                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice....");
                    break;

            }
        }
    }
}
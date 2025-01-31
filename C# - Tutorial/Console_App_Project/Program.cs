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

            // Take user input for go into particular system
            int choice = 0;
            Console.WriteLine("1. Student Management\n2. Teacher Management\n3. Class Management\n4. Exit");
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            switch (choice)
            {
                case 1:
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("* Welcome to Student Management *");
                    Console.WriteLine("---------------------------------");

                    while (true)
                    {
                        int innerChoice = 0;
                        // print options
                        Console.WriteLine("1. Add new student\n2. View all student\n3. Search student\n4. Update student record.\n5. Delete student record.\n6. exit.");

                        // take user input to perform particular tasks
                        Console.Write("Enter your choice: ");
                        innerChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                        switch (innerChoice)
                        {
                            case 1:
                                // method calling for add new Student
                                Student.AddNewStudent();
                                Console.WriteLine("Hurrey!... New student added in the records.");
                                break;
                            case 2:
                                // fetch all the student from the list/set
                                Student.ViewStudents();
                                break;
                            case 3:
                                //search student by name and roll no
                                Student.SearchStudent();
                                break;
                            case 4:
                                // update student by roll no
                                Console.Write("Enter student roll no (For Update): ");
                                int updateRollNo = Convert.ToInt32(Console.ReadLine());
                                Student.UpdateStudent(updateRollNo);
                                break;
                            case 5:
                                // delete student by roll no
                                Console.Write("Enter student roll no (For Delete): ");
                                int deleteRollNo = Convert.ToInt32(Console.ReadLine());
                                Student.DeleteStudent(deleteRollNo);
                                break;
                            case 6:
                                break;
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
                        // print options
                        Console.WriteLine("1. Add new teacher\n2. View all teacher\n3. Search teacher\n4. Update teacher record.\n5. Delete teacher record.\n6. exit.");
                        Console.Write("Enter your choice: ");
                        innerChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                        switch (innerChoice)
                        {
                            case 1:
                                // add new teacher
                                Teacher.AddNewTeacher();
                                Console.WriteLine("Hurrey!... New teacher added in the records.");
                                break;
                            case 2:
                                // view all the teacher list from set
                                Teacher.ViewTeacher();
                                break;
                            case 3:
                                // search teacher by name and employee ID
                                Teacher.SearchTeacher();
                                break;
                            case 4:
                                // update teacher data using employee ID
                                Console.Write("Enter teacher's employee ID (For Update): ");
                                int updateEmployeeID = Convert.ToInt32(Console.ReadLine());
                                Teacher.UpdateTeacher(updateEmployeeID);
                                break;
                            case 5:
                                // delete teacher record using employee ID
                                Console.Write("Enter teacher's employee ID (For Delete): ");
                                int deleteEmployeeID = Convert.ToInt32(Console.ReadLine());
                                Teacher.DeleteTeacher(deleteEmployeeID);
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Invalid Choice... :( ");
                                break;
                        }
                        Console.WriteLine("---------------------------------");
                    }
                    break;

                case 3:
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("* Welcome to Class Management *");
                    Console.WriteLine("---------------------------------");
                    while (true)
                    {
                        int innerChoice = 0;
                        // print options
                        Console.WriteLine("1. Create a new class\n2. View all classes\n3. exit.");
                        Console.Write("Enter your choice: ");
                        innerChoice = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

                        switch (innerChoice)
                        {
                            case 1:
                                // add new class in list
                                ClassFunc.AddNewClasses();
                                Console.WriteLine("Hurrey!... New class added in the records.");
                                break;
                            case 2:
                                // fetch all the classes details from list
                                ClassFunc.ViewAllClasses();
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Invalid Choice... :( ");
                                break;
                        }
                        Console.WriteLine("---------------------------------");
                    }
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
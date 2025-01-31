using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Console_App_Project
{
    public class teacher
    {
        public string name;
        public string subject;
        public int experience;
        public int employeeID;

        public teacher() { }
        public teacher(string name, string subject, int experience, int employeeID)
        {
            this.name = name;
            this.subject = subject;
            this.experience = experience;
            this.employeeID = employeeID;
        }

        public string updateName { get; set; }
        public string updateSubject { get; set; }
        public int updateExperience { get; set; }
        public int updateEmployeeID { get; set; }

        public override string ToString()
        {
            return $"Name: {name} | Subject: {subject} | Experience: {experience} | Employee ID: {employeeID}";
        }

    };

    public class Teacher
    {
        public static HashSet<teacher> teachers = new HashSet<teacher>();

        public static void AddNewTeacher()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter experience (year): ");
            int experience = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter employee ID: ");
            int employeeID = Convert.ToInt32(Console.ReadLine());
            
            teacher s = new teacher(name, subject, experience, employeeID);

            teachers.Add(s);
        }


        public static void SearchTeacher()
        {
            Console.WriteLine("1. Search by name\n2. Search by Employee ID\n3. exit.");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    TeacherSearchByName(name);
                    break;
                case 2:
                    Console.Write("Enter employee ID: ");
                    int searchRollNo = Convert.ToInt32(Console.ReadLine());
                    TeacherSearchByEmployeeID(searchRollNo);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice....");
                    break;

            }
            Console.WriteLine("---------------------------------");

        }


        public static void TeacherSearchByName(string name)
        {
            foreach (var item in teachers)
            {
                if (item.name == name)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void TeacherSearchByEmployeeID(int employeeID)
        {
            var searchIndex = teachers.FirstOrDefault(s => s.employeeID == employeeID);
            Console.WriteLine(searchIndex);
        }

        public static void UpdateTeacher(int roll_no)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();
            Console.Write("Enter exprience (in year): ");
            int experience = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter employee ID: ");
            int employeeID = Convert.ToInt32(Console.ReadLine());

            var updateIndex = teachers.FirstOrDefault(s => s.employeeID == employeeID);

            if (updateIndex != null)
            {
                updateIndex.name = name;
                updateIndex.subject = subject;
                updateIndex.experience = experience;
                updateIndex.employeeID = employeeID;
                Console.WriteLine("Hurrey! teacher record updated...");


                Console.WriteLine(updateIndex);
            }
            else
            {
                Console.WriteLine("Sorry... teacher is not found!");
            }
            Console.WriteLine("---------------------------------");

        }

        public static void DeleteTeacher(int employeeID)
        {
            var removeIndex = teachers.FirstOrDefault(s => s.employeeID == employeeID);

            if (removeIndex != null)
            {
                Console.WriteLine("Hurrey! teacher deleted from records...");
                teachers.Remove(removeIndex);
            }
            else
            {
                Console.WriteLine("Sorry... teacher is not found!");
            }
            Console.WriteLine("---------------------------------");

        }

        public static void ViewTeacher()
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("Sorry.... teacher records is empty!");
            }
            else
            {
                foreach (teacher teacher in teachers)
                {
                    Console.WriteLine($"Name: {teacher.name} | Subject: {teacher.subject} | Exprience: {teacher.experience} | Employee ID: {teacher.employeeID}");
                    Console.WriteLine("---------------------------------");

                }
            }
        }
    }
}

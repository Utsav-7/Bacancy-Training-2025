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
        
        // initialize object using parameterized constructor
        public teacher(string name, string subject, int experience, int employeeID)
        {
            this.name = name;
            this.subject = subject;
            this.experience = experience;
            this.employeeID = employeeID;
        }

        // used to update variable of class 
        public string updateName { get; set; }
        public string updateSubject { get; set; }
        public int updateExperience { get; set; }
        public int updateEmployeeID { get; set; }

        // used to print var object 
        public override string ToString()
        {
            return $"Name: {name} | Subject: {subject} | Experience: {experience} | Employee ID: {employeeID}";
        }

    };

    public class Teacher
    {
        // hashset is used to store teachers data
        public static HashSet<teacher> teachers = new HashSet<teacher>();

        // add new teachers in teachers hashset
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
            
            // create new object to teachers
            teacher s = new teacher(name, subject, experience, employeeID);
            // teacher object in hashset 
            teachers.Add(s);
        }


        public static void SearchTeacher()
        {
            // give option to the user to search teacher by name and employee ID
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
                    // convert string into int
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


        // to search teacher by name 
        public static void TeacherSearchByName(string name)
        {
            foreach (var item in teachers)
            {
                // check condition of given name same to the object contain name
                if (item.name == name)
                {
                    Console.WriteLine(item);
                }
            }
        }

        // to search teacher by employee ID
        public static void TeacherSearchByEmployeeID(int employeeID)
        {
            // find index of particular employee ID
            var searchIndex = teachers.FirstOrDefault(s => s.employeeID == employeeID);
            Console.WriteLine(searchIndex);
        }

        // update the teacher records store which is store in hashset
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

            // find index of roll no to update particular records
            var updateIndex = teachers.FirstOrDefault(s => s.employeeID == employeeID);

            // if index is null then record is not exists
            if (updateIndex != null)
            {
                // update the variable using set method
                updateIndex.name = name;
                updateIndex.subject = subject;
                updateIndex.experience = experience;
                updateIndex.employeeID = employeeID;
                Console.WriteLine("Hurrey! teacher record updated...");

                // print updated record
                Console.WriteLine(updateIndex);
            }
            else
            {
                Console.WriteLine("Sorry... teacher is not found!");
            }
            Console.WriteLine("---------------------------------");

        }

        // delete employee by using employee ID to delete particular record
        public static void DeleteTeacher(int employeeID)
        {
            // find index of object which one we want to delete
            var removeIndex = teachers.FirstOrDefault(s => s.employeeID == employeeID);

            // if index is null then record is not found
            if (removeIndex != null)
            {
                Console.WriteLine("Hurrey! teacher deleted from records...");
                // remove records from the hashset
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
            // if hashset is empty then message will be print
            if (teachers.Count == 0)
            {
                Console.WriteLine("Sorry.... teacher records is empty!");
            }
            else
            {
                // iterate hashset for print all the records
                foreach (teacher teacher in teachers)
                {
                    Console.WriteLine($"Name: {teacher.name} | Subject: {teacher.subject} | Exprience: {teacher.experience} | Employee ID: {teacher.employeeID}");
                    Console.WriteLine("---------------------------------");

                }
            }
        }
    }
}

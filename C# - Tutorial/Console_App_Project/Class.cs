using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_App_Project;

namespace Console_App_Project
{
    public class Class
    {
        public int className;
        public string section;
        public int employeeID;

        public Class() { }

        // parameterized constructor is used to assign value to particular variable
        public Class(int className, string section, int employeeID)
        {
            this.className = className;
            this.section = section;
            this.employeeID = employeeID;
        }
    }

    public class ClassFunc : Student
    {
        // hashset is used to store the class object
        public static HashSet<Class> classes = new HashSet<Class>();

        // add new class into set
        public static void AddNewClasses()
        {
            Console.Write("Enter class name: ");
            int className = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter section: ");
            string section = Console.ReadLine();
            Console.Write("Enter assigned teacher employee ID: ");
            int employeeID = Convert.ToInt32(Console.ReadLine());
           
            // create new object and initialize using constructor
            Class newClass = new Class(className, section, employeeID);
            // add new record in hashset
            classes.Add(newClass);
        }

        // view all the record of that store in hashset
        public static void ViewAllClasses()
        {
            // if hashset is empty then return message
            if(classes.Count == 0)
            {
                Console.WriteLine("No class found!....");
            }
            else
            {
                foreach (Class items in classes)
                {
                    //print the object data 
                    Console.WriteLine($"Class Name: {items.className} | Section: {items.section} | Assigned Teacher ID: {items.employeeID}");
                }
            }
            
        }

        // to display all the assigned students in particular class
        public static void AssignedStudent()
        {
            var assignedStudent = students.GroupBy(s => s.Class);
            foreach (var item in assignedStudent)
            {
                Console.WriteLine($"Class: {item.Key}"); // Group key (Class)

                foreach (var student in item)
                {
                    Console.WriteLine($"  - Student: {student.name}"); // Print student details
                }
            }
        }



    }


}

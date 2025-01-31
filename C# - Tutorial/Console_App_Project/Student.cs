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
    public class student
    {
        public string name;
        public int age;
        public string Class;
        public int roll_no;
        public string address;

        public student() { } 
        public student(string name, int age, string Class, int roll_no, string address)
        {
            this.name = name;
            this.age = age;
            this.Class = Class;
            this.roll_no = roll_no;
            this.address = address;
        }

        public string updateName { get; set; }
        public int updateAge { get; set; }
        public string updateClass { get; set; }
        public int updateRollNo {  get; set; }
        public string updateAddress {  get; set; }

        public override string ToString()
        {
            return $"Name: {name} | Age: {age} | Class: {Class} | Roll No: {roll_no} | Address: {address}";
        }

    };

    public class Student
    {
        public static HashSet<student> students = new HashSet<student>();

        public static void AddNewStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student class: ");
            string Class = Console.ReadLine();
            Console.Write("Enter student roll no: ");
            int roll_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student address: ");
            string address = Console.ReadLine();

            student s = new student(name, age, Class, roll_no, address);

            students.Add(s);
        }


        public static void SearchStudent()
        {
            Console.WriteLine("1. Search by name\n2. Search by Roll No\n3. exit.");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Write("Enter Student name: ");
                    string name = Console.ReadLine();
                    StudentSearchByName(name);
                    break;
                case 2:
                    Console.Write("Enter Student roll no: ");
                    int searchRollNo = Convert.ToInt32(Console.ReadLine());
                    StudentSearchByRollNo(searchRollNo);
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid Choice....");
                    break;

            }
            Console.WriteLine("---------------------------------");

        }


        public static void StudentSearchByName(string name)
        {
            foreach (var item in students)
            {
                if(item.name == name)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public static void StudentSearchByRollNo(int roll_no)
        {
            var searchIndex = students.FirstOrDefault(s => s.roll_no == roll_no);
            Console.WriteLine(searchIndex);
        }

        public static void UpdateStudent(int roll_no)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student class: ");
            string Class = Console.ReadLine();
            Console.Write("Enter student roll no: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student address: ");
            string address = Console.ReadLine();

            var updateIndex = students.FirstOrDefault(s => s.roll_no == roll_no);

            if (updateIndex != null)
            {
                updateIndex.name = name;
                updateIndex.age = age;
                updateIndex.Class = Class;
                updateIndex.roll_no = roll_no;
                updateIndex.address = address;
                Console.WriteLine("Hurrey! Student record updated...");


                Console.WriteLine(updateIndex);
            }
            else
            {
                Console.WriteLine("Sorry... Student is not found!");
            }
            Console.WriteLine("---------------------------------");

        }

        public static void DeleteStudent(int roll_no)
        {
            var removeIndex = students.FirstOrDefault(s => s.roll_no == roll_no);

            if (removeIndex != null)
            {
                Console.WriteLine("Hurrey! Student deleted from records...");
                students.Remove(removeIndex);
            }
            else
            {
                Console.WriteLine("Sorry... Student is not found!");
            }
            Console.WriteLine("---------------------------------");

        }

        public static void ViewStudents()
        {
            if(students.Count == 0)
            {
                Console.WriteLine("Sorry.... Student records is empty!");
            }
            else
            {
                foreach (student student in students)
                {
                    Console.WriteLine($"Name: {student.name} | Age: {student.age} | Class: {student.Class} | Roll No: {student.roll_no} | Address: {student.address}");
                    Console.WriteLine("---------------------------------");

                }
            }
        }
    }
}

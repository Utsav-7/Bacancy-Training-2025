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
        public int Class;
        public int roll_no;
        public string address;

        public student() { }

        // initialize the variable using parameterized constructor
        public student(string name, int age, int Class, int roll_no, string address)
        {
            this.name = name;
            this.age = age;
            this.Class = Class;
            this.roll_no = roll_no;
            this.address = address;
        }

        // get and set method update the variable
        public string updateName { get; set; }
        public int updateAge { get; set; }
        public int updateClass { get; set; }
        public int updateRollNo { get; set; }
        public string updateAddress { get; set; }

        // used to print var object
        public override string ToString()
        {
            return $"Name: {name} | Age: {age} | Class: {Class} | Roll No: {roll_no} | Address: {address}";
        }

    };

    public class Student
    {



        // used to store students in hashset
        public static HashSet<student> students = new HashSet<student>();

        // add data for initial records
        static Student(){
            students.Add(new student("Utsav", 21, 1, 43, "Surat"));
            students.Add(new student("Jay", 20, 1, 40, "Ahmedabad"));
            students.Add(new student("Ram", 22, 2, 32, "Baroda"));
            students.Add(new student("Mehul", 19, 3, 49, "Rajkot"));
            students.Add(new student("Rakesh", 29, 3, 90, "Surat"));
            students.Add(new student("Priya", 21, 2, 55, "Vadodara"));
            students.Add(new student("Amit", 23, 4, 25, "Surat"));
            students.Add(new student("Neha", 20, 1, 78, "Ahmedabad"));
            students.Add(new student("Rohan", 22, 2, 66, "Gandhinagar"));
            students.Add(new student("Kiran", 24, 4, 88, "Bhavnagar"));
        }

        // add method to add new records in hashset
        public static void AddNewStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student class: ");
            int Class = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student roll no: ");
            int roll_no = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student address: ");
            string address = Console.ReadLine();

            // create object and initialize using parameterized constructor
            student s = new student(name, age, Class, roll_no, address);
            // add new object in hashset
            students.Add(s);
        }

        // search student by name and roll no
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

                    // call funtion to search record using name (also give multiple records)
                    StudentSearchByName(name);
                    break;
                case 2:
                    Console.Write("Enter Student roll no: ");

                    // call function to search record using roll no (it give only single record)
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

        // search record by name
        public static void StudentSearchByName(string name)
        {
            foreach (var item in students)
            {
                // check given name is matched with object's name variable
                if(item.name == name)
                {
                    Console.WriteLine(item);
                }
            }
        }

        // search record by roll no
        public static void StudentSearchByRollNo(int roll_no)
        {
            // find the record using roll no
            var searchIndex = students.FirstOrDefault(s => s.roll_no == roll_no);
            Console.WriteLine(searchIndex);
        }

        // update the student records stored in hashset
        public static void UpdateStudent(int roll_no)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student class: ");
            int Class = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student roll no: ");
            int rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter student address: ");
            string address = Console.ReadLine();

            // find index of particular records by using roll no
            var updateIndex = students.FirstOrDefault(s => s.roll_no == roll_no);

            // if index is not null then record is present in the set
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

        // delete the record by using roll no
        public static void DeleteStudent(int roll_no)
        {
            // find particular index that we will need to delete
            var removeIndex = students.FirstOrDefault(s => s.roll_no == roll_no);

            // if index is not null then record is found
            if (removeIndex != null)
            {
                Console.WriteLine("Hurrey! Student deleted from records...");

                // remove record using index
                students.Remove(removeIndex);
            }
            else
            {
                Console.WriteLine("Sorry... Student is not found!");
            }
            Console.WriteLine("---------------------------------");

        }

        // print all the records which are stored in hashset
        public static void ViewStudents()
        {
            // if count is 0, hashset is empty
            if(students.Count == 0)
            {
                Console.WriteLine("Sorry.... Student records is empty!");
            }
            else
            {
                // iterate over the hashset and print record
                foreach (student student in students)
                {
                    Console.WriteLine($"Name: {student.name} | Age: {student.age} | Class: {student.Class} | Roll No: {student.roll_no} | Address: {student.address}");
                    Console.WriteLine("---------------------------------");

                }
            }
        }
    }
}

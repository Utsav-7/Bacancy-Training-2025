using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App_Project
{
    public struct student
    {
        public string name;
        public int age;
        public string Class;
        public int roll_no;
        public string address;

        public string updateName { get; set; }


    };

    public class Student
    {
        List<student> students = new List<student>();

        public void addNewStudent(student student)
        {
            students.Add(student);
        }

        //public void updateStudent(string name, int age, string Class, int roll_no, string address)
        //{
        //    int idx = students.FindIndex(student => student.name == name);
        //    students[idx].name = name;

        //}


        public void deleteStudent(string name)
        {
            int idx = students.FindIndex(student => student.name == name);
            students.RemoveAt(idx);
        }

        public void viewStudents()
        {
            foreach (student student in students)
            {
                Console.WriteLine($"Name: {student.name}\nAge: {student.age}\nClass: {student.Class}\nRoll No: {student.roll_no}\nAddress: {student.address}");
            }

        }
    }
}

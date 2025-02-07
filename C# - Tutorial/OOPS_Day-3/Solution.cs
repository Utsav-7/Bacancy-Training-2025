using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Code with SOLID principles
 * this follow the Interface Segregation Principle
 * also follows the Single Responsibility Principle
 * and the Open/Closed Principle
 */

namespace OOPS_Day_3
{
    class CalculateSalary
    {
        public static double Calculate(double employeeSalary)
        {
            return employeeSalary * 1.10;
        }
    }

    class GenerateReport : CalculateSalary
    {

        public void PrintReports(string name, double salary )
        {
            Console.WriteLine("Employee: " + name);
            Console.WriteLine("Salary After bonus:" + Calculate(salary));
        }
    }

    class Employee
    {
        private string employeeName;
        private double employeeSalary;
        public Employee(string name, double salary)
        {
            this.employeeName = name;
            this.employeeSalary = salary;
        }
    }
}

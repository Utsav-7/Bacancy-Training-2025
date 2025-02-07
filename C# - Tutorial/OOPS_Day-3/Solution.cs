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
    interface ICalculateSalary
    {
        public static double Calculate(double employeeSalary)
        {
            return employeeSalary * 1.10;
        }
    }

    internal class GenerateReport : ICalculateSalary
    {
        private string employeeName;
        private double employeeSalary;

        public GenerateReport(string name, double salary)
        {
            this.employeeName = name;
            this.employeeSalary = salary;
        }

        public void PrintReports()
        {
            Console.WriteLine("Employee: " + employeeName);
            Console.WriteLine("Salary After bonus:" + ICalculateSalary.Calculate(employeeSalary));
        }

    }

    class Employee : ICalculateSalary
    {
        private string employeeName;
        private double employeeSalary;
        public Employee(string name, double salary)
        {
            this.employeeName = name;
            this.employeeSalary = salary;
        }

        public void CalculateSalary()
        {
            Console.WriteLine("Salary: " + ICalculateSalary.Calculate(employeeSalary));
        }

        public void GenerateReport()
        {
            GenerateReport generateReport = new GenerateReport(employeeName, employeeSalary);
            generateReport.PrintReports();
        }
    }
}

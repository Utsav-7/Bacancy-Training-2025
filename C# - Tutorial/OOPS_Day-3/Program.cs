using System;

namespace OOPS_Day_3
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            int salary = 1000;
            string name = "John";
            Employee employee = new Employee(name,salary);
            GenerateReport report = new GenerateReport();   
            report.PrintReports(name, salary);
        }
    }
}
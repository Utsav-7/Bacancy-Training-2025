using System;

namespace OOPS_Day_3
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            Employee employee = new Employee("John", 1000);
            employee.CalculateSalary();
            employee.GenerateReport();
        }
    }
}
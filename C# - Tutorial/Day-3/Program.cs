using System;

namespace Solution
{
    public class Program
    {
        // Define delegates for Math and String Operations
        public delegate int MathOperation(int a, int b);
        public delegate string StringOperation(string str);

        static void Main(string[] args)
        {
            // Math Operations
            MathOperation add = delegate (int a, int b) { return a + b; };
            MathOperation subtract = delegate (int a, int b) { return a - b; };
            MathOperation multiply = delegate (int a, int b) { return a * b; };
            MathOperation divide = delegate (int a, int b)
            {
                if (b != 0)
                    return a / b;
                else
                    throw new DivideByZeroException("Cannot divide by zero.");
            };

            // String Operations
            StringOperation toUpperCase = delegate (string str) { return str.ToUpper(); };
            StringOperation getLength = delegate (string str) { return "Length: " + str.Length; };
            StringOperation reverseString = delegate (string str)
            {
                char[] charArray = str.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            };


            Console.WriteLine("---------- Math's Operation ----------");

            int num1 = 0;
            int num2 = 0;

            // Perform Math Operations
            try
            {
                Console.WriteLine("------------- Addition -------------");
                Console.WriteLine("Enter a two seperated value: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Addition: {add(num1, num2)}");

                Console.WriteLine("------------- Subtraction -------------");
                Console.WriteLine("Enter a two seperated value: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Subtraction: {subtract(num1, num2)}");

                Console.WriteLine("------------- Multiplication -------------");
                Console.WriteLine("Enter a two seperated value: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Multiplication: {multiply(num1, num2)}");

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid Input type :(");
            }

            try
            {
                Console.WriteLine("------------- Divison -------------");
                Console.WriteLine("Enter a two seperated value: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Division: {divide(num1, num2)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }


            // Perform String Operations 
            Console.WriteLine("---------- String Operations ----------");
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();

            Console.WriteLine($"Original String: {str}");
            Console.WriteLine($"Uppercase: {toUpperCase(str)}");
            Console.WriteLine(getLength(str));
            Console.WriteLine($"Reversed: {reverseString(str)}");


            // Pause the screen until we  can't press any key.
            Console.ReadKey();
        }
    }
}

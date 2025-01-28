using System;
using Day_2; // Make sure the Bank and UnsufficientBalanc classes are in this namespace

class Program
{
    static void Main(string[] args)
    {
        // Create a Bank object with initial balance
        Bank user1 = new Bank("user1", 10000);
        int choice = 0 ;
        Console.WriteLine("=====================================================");
        Console.WriteLine("----------------Bacancy Bank Of India----------------");
        Console.WriteLine("=====================================================");


        while (choice >= 0)
        {
            Console.WriteLine("1. Money Deposit\n2. Money Withdraw\n3. Check Balance\n-----Write -1 for exit-----");
            // Read user input for the choice
            Console.Write("Enter your choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------------");
            // Switch statement to handle different choices
            switch (choice)
            {
                case 1:
                    user1.GetBalance();
                    Console.Write("Enter an amount to deposit: ");
                    int depositAmount = Convert.ToInt32(Console.ReadLine());
                    user1.Deposit(depositAmount); // Correct method name with PascalCase
                    break;

                case 2:
                    user1.GetBalance();
                    Console.Write("Enter an amount to withdraw: ");
                    int withdrawAmount = Convert.ToInt32(Console.ReadLine());
                    user1.Withdraw(withdrawAmount); // Correct method name with PascalCase
                    break;

                case 3:
                    user1.GetBalance(); // Correct method name with PascalCase
                    break;

                default:
                    break;
            }
            Console.WriteLine("-----------------------------------------------------");
        }

    }
}

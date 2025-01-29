using System;
using Day_2;

class Program
{
    static void Main(string[] args)
    {
        Bank user1 = new Bank("user1", 10000);
        int choice = 0 ;
        Console.WriteLine("=====================================================");
        Console.WriteLine("----------------Bacancy Bank Of India----------------");
        Console.WriteLine("=====================================================");


        while (choice >= 0)
        {
            Console.WriteLine("1. Money Deposit\n2. Money Withdraw\n3. Check Balance\n-1. EXIT");

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
                    user1.Deposit(depositAmount); 
                    break;

                case 2:
                    user1.GetBalance();
                    Console.Write("Enter an amount to withdraw: ");
                    int withdrawAmount = Convert.ToInt32(Console.ReadLine());
                    user1.Withdraw(withdrawAmount); 
                    break;

                case 3:
                    user1.GetBalance();
                    break;
                case -1:
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.WriteLine("-----------------------------------------------------");
        }

    }
}

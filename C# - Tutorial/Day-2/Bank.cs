using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    // Custom exception for insufficient balance
    public class UnsufficientBalanc : Exception
    {
        public UnsufficientBalanc() { }

        public UnsufficientBalanc(string message) : base(message) { }

        public UnsufficientBalanc(string message, Exception inner) : base(message, inner) { }
    }

    public class Bank
    {
        string username;
        int balance;

        public Bank(string username, int balance)
        {
            this.username = username;
            this.balance = balance;
        }

        // Method to deposit money into the account
        public void Deposit(int amount)
        {
            balance += amount;
            Console.WriteLine($"-----> {amount} $ has been deposited into your account.");
            GetBalance();
        }

        // Method to display current balance
        public void GetBalance()
        {
            Console.WriteLine($"* Your current balance is: {balance} $");
        }

        // Method to withdraw money from the account
        public void Withdraw(int amount)
        {
            try
            {
                if (amount > balance)
                {
                    // Throw the custom exception when balance is insufficient
                    throw new UnsufficientBalanc("Balance is not sufficient to withdraw.");
                }
                else
                {
                    balance -= amount;
                    Console.WriteLine($"----> {amount} $ has been withdrawn from your account.");
                    Console.WriteLine($"Remaining Balance: {balance} $");
                }
            }
            catch (UnsufficientBalanc ex)
            {
                Console.WriteLine($"******** {ex.Message} ********");
            }
        }
    }
}


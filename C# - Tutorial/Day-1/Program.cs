using System;

namespace MySolution
{
    public class Solution
    {
        //main method
        static void Main(string[] args)
        {
            // create object of Solution
            Solution s = new Solution();

            // function call
            s.checkPairCombination();
        }



        public static bool IsNumber(string str)
        {
            return int.TryParse(userInput);
        }


        // method defination for check pair combination
        public void checkPairCombination()
        {

            try
            {
                //Variable declaration
                int num1;
                int num2;
                int num3;

                // take first number from user
                Console.Write("Enter a first number: ");
                string num1 = Console.ReadLine());

                if (!IsNumber(num1))
                {
                    throw new Exception("Invalid Number is entered");
                }

                // take second number from user 
                Console.Write("Enter a second number: ");
                num2 = Convert.ToInt32(Console.ReadLine());

                // take third number from user
                Console.Write("Enter a third number: ");
                num3 = Convert.ToInt32(Console.ReadLine());

            }  
            


            Console.WriteLine("---------------------------------------------------------");
            // calculation
            if (num1 % 2 == 0)
            {
                if (num2 % 2 != 0)
                {
                    if (num3 % 2 == 0)
                    {
                        Console.WriteLine("Your number is Odd-Even Pair combination :) ");
                    }
                    else
                    {
                        Console.WriteLine("Your number is not Odd-Even Pair Combination :( ");
                    }
                }
                else
                {
                    Console.WriteLine("Your number is not Odd-Even Pair Combination :( ");
                }

            }
            else
            {
                if (num2 % 2 == 0)
                {
                    if (num3 % 2 != 0)
                    {
                        Console.WriteLine("Your number is Odd-Even Pair combination :) ");
                    }
                    else
                    {
                        Console.WriteLine("Your number is not Odd-Even Pair Combination :( ");
                    }
                }
                else
                {
                    Console.WriteLine("Your number is not Odd-Even Pair Combination :( ");
                }
            }

            Console.WriteLine("---------------------------------------------------------");
            Console.ReadKey();
        }
    }
}

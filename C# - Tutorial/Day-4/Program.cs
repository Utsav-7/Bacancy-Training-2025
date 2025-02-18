using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Day_4
{
    public class Program
    {

        // Semaphore to control access to the resource 
        public static SemaphoreSlim semaphore = new SemaphoreSlim(3);

        // Shared variable
        public static int sharedCounter = 0;

        // Simulated resource access and modifying sharedCounter
        public static void AccessResourceAndModifyCounter(int threadId)
        {
            Console.WriteLine($"---> Thread {threadId} is waiting to access the resource...");

            // Wait to enter the semaphore, which allows a max of 3 threads to proceed at once
            semaphore.Wait();

            try
            {
                Console.WriteLine($" ----- Thread {threadId} is accessing the resource...");

                // Modify the shared variable (increment the counter)
                Console.WriteLine($" -|-|- Thread {threadId} is modifying the shared counter...");
                sharedCounter++;

                Console.WriteLine($"<--- Thread {threadId} has finished accessing the resource.");
            }
            finally
            {
                // Release the semaphore, allowing another thread to enter
                semaphore.Release();
            }
        }


        static void Main()
        {

            int totalThreads = 6;

            List<Thread> threads = new List<Thread>();

            // Start threads
            for (int i = 1; i <= totalThreads; i++)
            {
                int threadId = i;
                Thread thread = new Thread(() => AccessResourceAndModifyCounter(threadId));
                threads.Add(thread);
                thread.Start();
            }

            // Wait for all threads to finish
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Output the final value of the shared counter
            Console.WriteLine($"Final shared counter value: {sharedCounter}");
            Console.WriteLine("All threads have completed.");
        }
    }

}
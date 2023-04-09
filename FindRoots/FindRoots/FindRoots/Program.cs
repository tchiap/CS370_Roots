
/**
 * Tom Chiapete
 * October 9, 2007
 * 
 * Find Roots Program
 * Finds Roots using threading
 */

// Define our libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FindRoots 
{

    // Define a class roots that extends object
    class Roots : Object
    {
        // instance variables
        private static Semaphore s = new Semaphore(1, 1);

        // main counter for finding roots for
        private static int j = 0;

        // start, end time string variables
        private static String startTime = "";
        private static String endTime = "";

        // count variable for working with our threads
        private static int count = 0;

        // Constructor
        public Roots()
        {
            // Set the start time
            startTime = "Start Time: " + DateTime.Now + ":" + DateTime.Now.Millisecond;

            // Create our threads
            Thread[] threads = new Thread[3];

            for (count = 0; count < threads.Length; count++)
            {
                // For each thread, start by running Run() method
                threads[count] = new Thread(new ThreadStart(Run));

                // Start the thread
                threads[count].Start();

                // Define the name of the thread, which is just a number
                threads[count].Name = "" + count;
                
            }
        }

        /**
         * main() method
         * First method executed upon execution 
         */
        static void Main(string[] args)
        {            
            // Define a new roots object
            Roots roots = new Roots();
        }

        /**
         * run() method
         * Executed among thread start
         */
        public static void Run()
        {
            
            // Define an output string
            String outputString = "";

            // Set up our loop to count up to 5000
            for (; j < 5000;)
            {
                                
                // Activate semaphore
                s.WaitOne();

                // Set up the output string, defining which thread we
                // are using, and the root we are taking
                outputString += "T" + Thread.CurrentThread.Name + ":";
                outputString += "V" + j + "=" + Math.Sqrt((double)j) + "   ";

                // If we've printed out four to the line already, 
                // throw in a line break
                if (j % 4 == 0)
                    outputString += "\n\r";
                Console.Write(outputString);

                // Increment the counter here before the releasing the semaphore
                j++;

                // Release the semaphore
                s.Release();
                
                // Reset our output string
                outputString = "";
            }

            // Set our end time
            endTime = "End Time: " + DateTime.Now + ":" + DateTime.Now.Millisecond;
            Console.WriteLine();
            
            ////////// Output - uncomment to activate output
            // Console.WriteLine(startTime);
            // Console.WriteLine(endTime);
            // Console.ReadLine();
            

            // Note, in order to find execution time, take the first START time,
            // and the last END time.
             
        }
    }
}

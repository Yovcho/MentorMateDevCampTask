using MentorMateDevCampTask.Logic;
using System;

namespace MentorMateDevCampTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Use try catch block to catch exceptions
            try
            {
                // initialize an object from Engine class and call its Start method to run the program
                var engine = new Engine();
                engine.Start();
            }
            catch (Exception ex)
            {
                // Write out exception in console
                Console.WriteLine(ex.Message);
            }
        }
    }
}

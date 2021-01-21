using System;
using System.Linq;

namespace MentorMateDevCampTask.Utilities
{
    public static class Helpers
    {
        public static int[] ReadLineAndConvertToArray()
        {
            return Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
        }
    }
}

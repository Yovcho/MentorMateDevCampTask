using System;
using System.Linq;

namespace MentorMateDevCampTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            int[,] layer = new int[input[0], input[1]];

            for (int row = 0; row < input[0]; row++)
            {
                var inputRow = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (int column = 0; column < input[1]; column++)
                {
                    layer[row, column] = inputRow[column];
                }
            }
            int[,] newLayer = new int[input[0], input[1]];
            int brickCounter = 1;
            for (int i = 0; i < input[0]; i++)
            {
                for (int j = 0; j < input[1]; j++)
                {
                    if (newLayer[i, j] == 0 && j == input[1] - 1)
                    {
                        newLayer[i, j] = newLayer[i + 1, j] = brickCounter; ;
                        brickCounter++;
                    }

                    else if (newLayer[i, j] == 0 && j < input[1] - 1)
                    {
                        if (layer[i, j] == layer[i, j + 1])
                        {
                            newLayer[i, j] = newLayer[i + 1, j] = brickCounter;
                            brickCounter++;
                        }
                        else
                        {
                            newLayer[i, j] = newLayer[i, j + 1] = brickCounter;
                            brickCounter++;
                        }
                    }
                }
            }
            for (int row = 0; row < input[0]; row++)
            {
                for (int column = 0; column < input[1]; column++)
                {
                    Console.Write(string.Format("| {0} ", newLayer[row, column]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.ReadLine();
        }
    }
}

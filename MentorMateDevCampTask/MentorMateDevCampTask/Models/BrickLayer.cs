using System;
using System.Linq;

namespace MentorMateDevCampTask.Models
{
    public class BrickLayer
    {
        public int Row
        {
            get => row;
            private set
            {
                row = value;

                if (row % 2 == 1)
                {
                    throw new ArgumentException("Rows need to be an even number!");
                }
                if (row > 100)
                {
                    throw new ArgumentException("Rows should not exceed 100!");
                }
            }

        }
        public int Column
        {
            get => column;
            private set
            {
                column = value;

                if (column % 2 == 1)
                {
                    throw new ArgumentException("Colums need to be an even number!");
                }
                if (column > 100)
                {
                    throw new ArgumentException("Columns should not exceed 100!");
                }
            }
        }
        private int row;
        private int column;
        private int[,] firstLayer;
        private int[,] secondLayer;
        public BrickLayer(int[] input)
        {
            this.Row = input[0];
            this.Column = input[1];
            this.firstLayer = new int[this.Row, this.Column];
            this.secondLayer = new int[this.Row, this.Column];

        }
        public void AddBrickLines()
        {
            for (int row = 0; row < this.row; row++)
            {
                var inputRow = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (int column = 0; column < this.column; column++)
                {
                    firstLayer[row, column] = inputRow[column];
                }
            }
        }

        public void BuildSecondLayer()
        {
            int brickNumberCounter = 1;
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Column; j++)
                {
                    if (secondLayer[i, j] == 0 && j == this.Column - 1)
                    {
                        secondLayer[i, j] = secondLayer[i + 1, j] = brickNumberCounter; ;
                        brickNumberCounter++;
                    }

                    else if (secondLayer[i, j] == 0 && j < this.Column - 1)
                    {
                        if (firstLayer[i, j] == firstLayer[i, j + 1])
                        {
                            secondLayer[i, j] = secondLayer[i + 1, j] = brickNumberCounter;
                            brickNumberCounter++;
                        }
                        else
                        {
                            secondLayer[i, j] = secondLayer[i, j + 1] = brickNumberCounter;
                            brickNumberCounter++;
                        }
                    }
                }
            }
        }
        public void PrintLayer()
        {
            for (int row = 0; row < this.row; row++)
            {
                for (int column = 0; column < this.column; column++)
                {
                    Console.Write(string.Format("| {0} ", secondLayer[row, column]));
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}

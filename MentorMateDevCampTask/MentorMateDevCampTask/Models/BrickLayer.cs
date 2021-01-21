using MentorMateDevCampTask.Utilities;
using System;
using System.Collections.Generic;
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
                // throw exception if validation is wrong
                if (row % 2 == 1)
                {
                    throw new ArgumentException("Rows need to be an even number!");
                }
                if (row > 100 || row <= 0)
                {
                    throw new ArgumentException("Rows should not exceed 100 or be less than 0!");
                }
            }

        }
        public int Column
        {
            get => column;
            private set
            {
                column = value;
                // throw exception if validation is wrong
                if (column % 2 == 1)
                {
                    throw new ArgumentException("Colums need to be an even number!");
                }
                if (column > 100 || column <= 0)
                {
                    throw new ArgumentException("Columns should not exceed 100 or be less than 0!");
                }
            }
        }
        //private fields that we will use
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
        // Method used for adding the brick lines to first layer
        public void AddBrickLines()
        {
            for (int row = 0; row < this.row; row++)
            {
                var inputRow = Helpers.ReadLineAndConvertToArray();
                for (int column = 0; column < this.column; column++)
                {
                    firstLayer[row, column] = inputRow[column];
                }
            }
            this.ValidateLayer();
        }
        // All brick validations method
        private void ValidateLayer()
        {
            this.IsBrickSpanningThreeRows();
            this.IsBrickSpanningThreeColumns();
            this.BrickNumbersValidation();
        }
        // Algorithm for building the second layer
        public void BuildSecondLayer()
        {
            // Number of current brick 
            int brickNumberCounter = 1;
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    //Check if it is the last column and is it free, if it is place a vertical brick
                    if (secondLayer[i, j] == 0 && j == this.column - 1)
                    {
                        secondLayer[i, j] = secondLayer[i + 1, j] = brickNumberCounter; ;
                        brickNumberCounter++;
                    }
                    //check if position on secondLayer is free 
                    else if (secondLayer[i, j] == 0 && j < this.column - 1)
                    {
                        //check if brick on firstLayer is horizontal
                        if (firstLayer[i, j] == firstLayer[i, j + 1])
                        {
                            //if it is place a vertical brick on secondLayer
                            secondLayer[i, j] = secondLayer[i + 1, j] = brickNumberCounter;
                            brickNumberCounter++;
                        }
                        else
                        {
                            //Otherwise place the brick horizontally
                            secondLayer[i, j] = secondLayer[i, j + 1] = brickNumberCounter;
                            brickNumberCounter++;
                        }
                    }
                }
            }
        }
        // Method for printing second layer
        public void PrintLayer()
        {
            for (int row = 0; row < this.row; row++)
            {
                for (int column = 0; column < this.column; column++)
                {
                    Console.Write(string.Format("{0} ", secondLayer[row, column]));
                }
                Console.Write(Environment.NewLine);
            }
        }
        // Method used for checking if brick is spanning three rows
        private void IsBrickSpanningThreeRows()
        {
            for (int row = 0; row < firstLayer.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < firstLayer.GetLength(1); col++)
                {
                    if (firstLayer[row, col] == firstLayer[row + 1, col] &&
                        firstLayer[row + 1, col] == firstLayer[row + 2, col])
                    {
                        throw new Exception("There is a brick on 3 rows!");
                    }
                }
            }
        }
        // Method used for checking if brick is spanning three columns
        private void IsBrickSpanningThreeColumns()
        {
            for (int row = 0; row < firstLayer.GetLength(0); row++)
            {
                for (int col = 0; col < firstLayer.GetLength(1) - 2; col++)
                {
                    if (firstLayer[row, col] == firstLayer[row, col + 1] &&
                        firstLayer[row, col + 1] == firstLayer[row, col + 2])
                    {
                        throw new Exception("There is a brick on 3 columns!");
                    }
                }
            }
        }
        // Method to check if a brick number is duplicate somewhere in the first layer
        private void BrickNumbersValidation()
        {
            var duplicateNumberDictionary = new Dictionary<int, int>();
            for (int row = 0; row < firstLayer.GetLength(0); row++)
            {
                for (int column = 0; column < firstLayer.GetLength(1); column++)
                {
                    if (!duplicateNumberDictionary.ContainsKey(firstLayer[row, column]))
                    {
                        duplicateNumberDictionary.Add(firstLayer[row, column], 0);
                    }

                    duplicateNumberDictionary[firstLayer[row, column]]++;

                    if (duplicateNumberDictionary[firstLayer[row, column]] > 2)
                    {
                        throw new Exception($"Brick with number {duplicateNumberDictionary.FirstOrDefault(x => x.Key == firstLayer[row,column]).Key} is duplicate!");
                    }

                }
            }
        }
    }
}

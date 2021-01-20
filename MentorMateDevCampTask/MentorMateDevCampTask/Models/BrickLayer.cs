using System;

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
    }
}

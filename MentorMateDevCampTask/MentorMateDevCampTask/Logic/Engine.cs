using MentorMateDevCampTask.Models;
using System;
using System.Linq;

namespace MentorMateDevCampTask.Logic
{
    public class Engine
    {

        public void Start()
        {
            var inputArea = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();

            if (inputArea[0] == 2 && inputArea[1] == 2)
            {
                throw new Exception("-1 No solution exists");
            }

            var firstLayer = new BrickLayer(inputArea);

            firstLayer.AddBrickLines();
            firstLayer.BuildSecondLayer();
            firstLayer.PrintLayer();
        }
    }
}

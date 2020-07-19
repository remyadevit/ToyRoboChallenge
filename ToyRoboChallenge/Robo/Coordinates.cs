using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRoboChallenge.Robo
{
    /// <summary>
    /// This class represents the position of the toy on the board.
    /// </summary>
    public class Coordinates
    {
        private int x;
        private int y;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public Coordinates(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

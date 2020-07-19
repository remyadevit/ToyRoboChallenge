using System;
using System.Collections.Generic;
using System.Text;
using ToyRoboChallenge.SquareGrid.Interface;
using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.SquareGrid
{
    /// <summary>
    /// This class is the board that the toy sits on. It has a properties for rows and colums.
    /// There is also a method for checking if the position of the toy is valid.
    /// </summary>
    public class Grid : IGrid
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Grid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        // Check whether the position specified is inside the boundaries of the square grid.
        public bool IsPositionValid(Coordinates coordinates)
        {
            return coordinates.X < Columns && coordinates.X >= 0 &&
                   coordinates.Y < Rows && coordinates.Y >= 0;
        }
    }
}

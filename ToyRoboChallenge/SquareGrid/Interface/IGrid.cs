using System;
using System.Collections.Generic;
using System.Text;
using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.SquareGrid.Interface
{
    //This method should validate if the position of the robot is valid and 
    //within a 5*5 matrix
    public interface IGrid
    {
        bool IsPositionValid(Coordinates coordinates);
    }
}

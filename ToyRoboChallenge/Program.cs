using System;
using ToyRoboChallenge.SquareGrid.Interface;
using ToyRoboChallenge.SquareGrid;
using ToyRoboChallenge.CommandParserList.Interface;
using ToyRoboChallenge.CommandParserList;
using ToyRoboChallenge.Robo.Interface;
using ToyRoboChallenge.Robo;



namespace ToyRoboChallenge
{
    class Program
    {
        public static void Main(string[] args)
        {
            var exitApp = false;
            const string message = @"
  ***************************************************
  ***************************************************
  ****    Welcome to the TOY ROBO Challenge     *****
  ***************************************************
  ***************************************************
  ***************************************************
  Instructions:
  1: Place the toy on a 5 x 5 grid
     using the following command:

     PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST)

  2: When the toy is placed, have at go at using
     the following commands.
                
     REPORT – Shows the current status of the toy. 
     LEFT   – turns the toy 90 degrees left.
     RIGHT  – turns the toy 90 degrees right.
     MOVE   – Moves the toy 1 unit in the facing direction.
     EXIT   – Closes the toy Simulator.";

            Console.WriteLine(message);
            IGrid grid = new Grid(5,5);
            ICommandParser commandParser = new CommandParser();
            IToyRobo robot = new ToyRobo();
            var robo = new Behaviour.Behaviour(robot, grid, commandParser);

            do
            {
                var command = Console.ReadLine();
                if (command == null) continue;

                if (command.Equals("EXIT"))
                    exitApp = true;
                else
                {
                    try
                    {
                        //Need an object which will hold the robo position and the current commands
                        var output = robo.ProcessInput(command.Split(' '));
                        if (!string.IsNullOrEmpty(output))
                            Console.WriteLine(output);

                    }
                    catch (ArgumentException exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
            } while (!exitApp);
        }
    }
}

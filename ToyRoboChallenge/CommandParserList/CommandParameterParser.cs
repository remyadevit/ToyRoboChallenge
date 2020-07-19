using System;
using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.CommandParserList
{
    // This class checks the parameters for the "PLACE" command.
    public class CommandParameterParser
    {
        private const int ParameterCount = 3;

        // Number of raw input items expected from user.
        private const int InputCommandCount = 2;

        // Checks the toy's initial position and the direction it is going to be facing.
        public CommandParameter ParseParameters(string[] input)
        {
            Direction direction;
            Coordinates coordinates = null;

            // Checks that Place command is followed by valid command parameters (X,Y and F toy's face direction).
            if (input.Length != InputCommandCount)
                throw new ArgumentException("Invalid command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            // Checks that three command parameters are provided for the PLACE command.   
            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Invalid command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            // Checks the direction which the robo is going to be facing.
            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            coordinates = new Coordinates(x, y);

            return new CommandParameter(coordinates, direction);
        }
    }
}



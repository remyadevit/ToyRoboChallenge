using System;
using ToyRoboChallenge.CommandParserList.Interface;
using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.CommandParserList
{
    public class CommandParser :ICommandParser
    {
        // this method takes a string array and compares the first element to the list of commands
        // if the command doesn't exist then an error is thrown, otherwise the command is returned
        public Command ParseCommand(string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }

        // Extracts the parameters from the user input and returns it       
        public CommandParameter ParseCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new CommandParameterParser();
            return thisPlaceCommandParameter.ParseParameters(input);
        }
    }
}

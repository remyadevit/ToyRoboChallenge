using System;
using System.Collections.Generic;
using System.Text;
using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.CommandParserList.Interface
{
    // Interface to process the commands from the user.
    public interface ICommandParser
    {
        Command ParseCommand(string[] rawInput);

        // This extracts the parameters from the user's input.        
        CommandParameter ParseCommandParameter(string[] input);
    }
}

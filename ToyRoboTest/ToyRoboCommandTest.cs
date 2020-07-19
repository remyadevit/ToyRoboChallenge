using NUnit.Framework;
using ToyRoboChallenge.CommandParserList;
using ToyRoboChallenge.Robo;
using System;

namespace ToyRoboTest
{
    class ToyRoboCommandTest
    {

        /// <summary>
        /// Test valid place command
        /// </summary>
        [Test]
        public void TestValidPlaceCommand()
        {
            // arrange
            var commandParser = new CommandParser();
            string[] rawInput = "PLACE".Split(' ');

            // act
            var command = commandParser.ParseCommand(rawInput);

            // assert
            Assert.AreEqual(Command.Place, command);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommand()
        {
            // arrange
            var commandParser = new CommandParser();
            string[] rawInput = "PLACETOY".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { commandParser.ParseCommand(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Sorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT"));
        }

        /// <summary>
        /// Test a full place command with valid parameters
        /// </summary>
        [Test]
        public void TestValidPlaceCommandAndParams()
        {
            // arrange
            var commandParser = new CommandParser();
            string[] rawInput = "PLACE 4,3,WEST".Split(' ');

            // act
            var placeCommandParameter = commandParser.ParseCommandParameter(rawInput);

            // assert
            Assert.AreEqual(4, placeCommandParameter.Coordinates.X);
            Assert.AreEqual(3, placeCommandParameter.Coordinates.Y);
            Assert.AreEqual(Direction.West, placeCommandParameter.Direction);
        }

        /// <summary>
        /// Test a place command with an incomplete parameter
        /// </summary>
        [Test]
        public void TestInvalidPlaceCommandAndParams()
        {
            // arrange
            var commandParser = new CommandParser();
            string[] rawInput = "PLACE 3,1".Split(' ');

            // act and assert
            var exception = Assert.Throws<System.ArgumentException>(delegate
            { var placeCommandParameter = commandParser.ParseCommandParameter(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F"));
        }

        /// <summary>
        /// Test a place command with an invalid direction
        /// </summary>
        [Test]
        public void TestInvalidPlaceDirection()
        {
            // arrange
            var paramParser = new CommandParameterParser();
            string[] rawInput = "PLACE 2,4,OneDirection".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST"));
        }

        /// <summary>
        /// Test a place command with an invalid parameter format
        /// </summary>
        [Test]
        public void TestInvalidPlaceParamsFormat()
        {
            // arrange
            var paramParser = new CommandParameterParser();
            string[] rawInput = "PLACE 3,3,SOUTH,2".Split(' ');

            // act and assert
            var exception = Assert.Throws<ArgumentException>(delegate { paramParser.ParseParameters(rawInput); });
            Assert.That(exception.Message, Is.EqualTo("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F"));
        }

    }
}



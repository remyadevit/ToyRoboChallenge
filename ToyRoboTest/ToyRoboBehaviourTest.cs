using NUnit.Framework;
using ToyRoboChallenge.SquareGrid.Interface;
using ToyRoboChallenge.SquareGrid;
using ToyRoboChallenge.CommandParserList.Interface;
using ToyRoboChallenge.CommandParserList;
using ToyRoboChallenge.Robo.Interface;
using ToyRoboChallenge.Robo;
using ToyRoboChallenge.Behaviour;


namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public void TestValidBehaviourPlace()
        {
            // arrange
            IGrid grid = new Grid(5, 5);
            ICommandParser inputParser = new CommandParser();
            IToyRobo robot = new ToyRobo();
            var simulator = new Behaviour(robot, grid, inputParser);

            // act
            simulator.ProcessInput("PLACE 1,3,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, robot.Coordinates.X);
            Assert.AreEqual(4, robot.Coordinates.Y);
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourPlace()
        {
            // arrange
            IGrid grid = new Grid(5, 5);
            ICommandParser inputParser = new CommandParser();
            IToyRobo robot = new ToyRobo();
            var simulator = new Behaviour(robot, grid, inputParser);

            // act
            simulator.ProcessInput("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(robot.Coordinates);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Test]
        public void TestValidBehaviourMove()
        {
            // arrange
            IGrid grid = new Grid(5, 5);
            ICommandParser inputParser = new CommandParser();
            IToyRobo robot = new ToyRobo();
            var simulator = new Behaviour(robot, grid, inputParser);

            // act
            simulator.ProcessInput("PLACE 3,2,SOUTH".Split(' '));
            simulator.ProcessInput("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 3,1,SOUTH", simulator.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourMove()
        {
            // arrange
            IGrid grid = new Grid(5, 5);
            ICommandParser inputParser = new CommandParser();
            IToyRobo robot = new ToyRobo();
            var simulator = new Behaviour(robot, grid, inputParser);

            // act
            simulator.ProcessInput("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessInput("MOVE".Split(' '));
            simulator.ProcessInput("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessInput("MOVE".Split(' '));

            // assert
            Assert.AreEqual("Output: 2,4,NORTH", simulator.GetReport());
        }

        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidBehaviourReport()
        {
            // arrange
            IGrid grid = new Grid(5, 5);
            ICommandParser inputParser = new CommandParser();
            IToyRobo robot = new ToyRobo();
            var simulator = new Behaviour(robot, grid, inputParser);

            // act
            simulator.ProcessInput("PLACE 3,3,WEST".Split(' '));
            simulator.ProcessInput("MOVE".Split(' '));
            simulator.ProcessInput("MOVE".Split(' '));
            simulator.ProcessInput("LEFT".Split(' '));
            simulator.ProcessInput("MOVE".Split(' '));
            var output = simulator.ProcessInput("REPORT".Split(' '));

            // assert
            Assert.AreEqual("Output: 1,2,SOUTH", output);
        }
    }
}
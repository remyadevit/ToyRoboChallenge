using ToyRoboChallenge.Robo.Interface;
using ToyRoboChallenge.SquareGrid.Interface;
using ToyRoboChallenge.CommandParserList.Interface;
using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.Behaviour
{
    /// <summary>
    /// This class is used to simulate the behaviour of the toy robo.
    /// It calls the interfaces from other classes to make a behaviour object.
    /// Methods for this object include processing the commands and
    /// rendering the report.
    /// </summary>
    public class Behaviour
    {
        public IToyRobo ToyRobot { get; private set; }
        public IGrid Grid { get; private set; }
        public ICommandParser CommandParser { get; private set; }

        public Behaviour(IToyRobo toyRobot, IGrid squareBoard, ICommandParser commandParser)
        {
            ToyRobot = toyRobot;
            Grid = squareBoard;
            CommandParser = commandParser;
        }

        public string ProcessInput(string[] input)
        {
            var command = CommandParser.ParseCommand(input);
            if (command != Command.Place && ToyRobot.Coordinates == null) return string.Empty;

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = CommandParser.ParseCommandParameter(input);
                    if (Grid.IsPositionValid(placeCommandParameter.Coordinates))
                        ToyRobot.Place(placeCommandParameter.Coordinates, placeCommandParameter.Direction);
                    break;
                case Command.Move:
                    var newPosition = ToyRobot.GetNextPosition();
                    if (Grid.IsPositionValid(newPosition))
                        ToyRobot.Coordinates = newPosition;
                    break;
                case Command.Left:
                    ToyRobot.RotateLeft();
                    break;
                case Command.Right:
                    ToyRobot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return string.Empty;
        }

        public string GetReport()
        {
            return string.Format("Output: {0},{1},{2}", ToyRobot.Coordinates.X,
                ToyRobot.Coordinates.Y, ToyRobot.Direction.ToString().ToUpper());
        }
    }
}

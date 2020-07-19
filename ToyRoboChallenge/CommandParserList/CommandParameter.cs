using ToyRoboChallenge.Robo;

namespace ToyRoboChallenge.CommandParserList
{
    // This is a class to store the parameters for the "PLACE" command.
    public class CommandParameter
    {
        public Coordinates Coordinates { get; set; }
        public Direction Direction { get; set; }

        public CommandParameter(Coordinates coordinates, Direction direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }
    }
}

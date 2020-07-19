using NUnit.Framework;
using ToyRoboChallenge.SquareGrid;
using ToyRoboChallenge.Robo;

namespace ToyRoboTest
{
    class ToyRoboGridTest
    {
        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Test]
        public void TestInvalidBoardPosition()
        {
            // arrange
            Grid squareGrid = new Grid(5, 5);
            Coordinates coordinates = new Coordinates(6, 6);

            // act
            var result = squareGrid.IsPositionValid(coordinates);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test valid positon 
        /// </summary>
        [Test]
        public void TestValidBoardPosition()
        {
            // arrange
            Grid squareGrid = new Grid(5, 5);
            Coordinates coordinates = new Coordinates(1, 4);

            // act
            var result = squareGrid.IsPositionValid(coordinates);

            // assert
            Assert.IsTrue(result);
        }

    }
}

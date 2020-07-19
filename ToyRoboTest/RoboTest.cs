using System;
using NUnit.Framework;
using ToyRoboChallenge.Robo;
namespace ToyRoboTest
{
    class RoboTest
    {
        /// <summary>
        /// Test toy turn left
        /// </summary>
        [Test]
        public void TestValidToyTurnLeft()
        {
            // arrange
            var robot = new ToyRobo { Direction = Direction.West, Coordinates = new Coordinates(2, 2) };

            // act
            robot.RotateLeft();

            // assert
            Assert.AreEqual(Direction.South, robot.Direction);
        }

        /// <summary>
        /// Test toy turn right
        /// </summary>
        [Test]
        public void TestValidToyTurnRight()
        {
            // arrange
            var robot = new ToyRobo { Direction = Direction.West, Coordinates = new Coordinates(2, 2) };

            // act
            robot.RotateRight();

            // assert
            Assert.AreEqual(Direction.North, robot.Direction);
        }


        /// <summary>
        /// Test move
        /// </summary>
        [Test]
        public void TestValidToyMove()
        {
            // arrange
            var robot = new ToyRobo { Direction = Direction.East, Coordinates = new Coordinates(2, 2) };

            // act
            var nextPosition = robot.GetNextPosition();

            // assert
            Assert.AreEqual(3, nextPosition.X);
            Assert.AreEqual(2, nextPosition.Y);
        }

        /// <summary>
        /// Test set toy position and direction
        /// </summary>
        [Test]
        public void TestValidToyPositionAndDirection()
        {
            // arrange
            var coordinates = new Coordinates(3, 3);
            var robot = new ToyRobo();

            // act
            robot.Place(coordinates, Direction.North);

            // assert
            Assert.AreEqual(3, robot.Coordinates.X);
            Assert.AreEqual(3, robot.Coordinates.Y);
            Assert.AreEqual(Direction.North, robot.Direction);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Library;
using NUnit.Framework;
using Moq;

namespace MarsRover.Test
{
    [TestFixture]
    public class RoverFixture
    {
        private Mock<IPosition> _position = null;
        private Mock<IPlateau> _pleateau = null;
        private IRover _roverOne = null;
        private IRover _roverTwo = null;

        [SetUp]
        public void Setup()
        {
            _pleateau = new Mock<IPlateau>();
            _position = new Mock<IPosition>();
        }

        private void SetupRoverOne()
        {
            _position.SetupProperty(x => x.X, 1);
            _position.SetupProperty(x => x.Y, 2);
            _pleateau.Setup(x => x.PlateauPosition).Returns(new Position(5, 5));
            _roverOne = new Rover(_position.Object, Orientations.N, _pleateau.Object);
        }

        private void SetupRoverTwo()
        {
            _position.SetupProperty(x => x.X, 3);
            _position.SetupProperty(x => x.Y, 3);
            _pleateau.Setup(x => x.PlateauPosition).Returns(new Position(5, 5));
            _roverTwo = new Rover(_position.Object, Orientations.E, _pleateau.Object);
        }

        [Test]
        public void Move_Rover_Outside_Borders()
        {
            SetupRoverOne();

            _roverOne.Process("MMRMMRMRRMMRRMRMRMMMMMMRMMMM");

            Console.WriteLine(_roverOne.ToString());
            Assert.IsTrue(_roverOne.ToString().Contains("Rover outside the border"));
        }

        [Test]
        public void Move_RoverOne_Check_Output()
        {
            SetupRoverOne();

            _roverOne.Process("LMLMLMLMM");

            Console.WriteLine(_roverOne.ToString());
            Assert.AreEqual(_roverOne.ToString(), "1 3 N");
        }

        [Test]
        public void Move_RoverTwo_Check_Output()
        {
            SetupRoverTwo();
            
            _roverTwo.Process("MMRMMRMRRRRRRM");

            Console.WriteLine(_roverTwo.ToString());
            Assert.AreEqual(_roverTwo.ToString(), "5 1 E");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void Move_RoverOne_Incorrect_Input()
        {
            SetupRoverOne();

            _roverOne.Process("LMLMLMFLMM");
        }
    }
}

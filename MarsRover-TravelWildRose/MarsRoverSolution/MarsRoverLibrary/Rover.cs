using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Library;

namespace MarsRover.Library
{
   
    public class Rover : IRover
    {
        public IPosition RoverPosition { get; set; }
        public Orientations RoverOrientation { get; set; }
        public IPlateau RoverPlateau { get; set; }


        public Rover(IPosition roverPosition, Orientations roverOrientation, IPlateau roverPlateau)
        {
            RoverPosition = roverPosition;
            RoverOrientation = roverOrientation;
            RoverPlateau = roverPlateau;
        }

        public void Process(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        Left();
                        break;
                    case ('R'):
                        Right();
                        break;
                    case ('M'):
                        Advance();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid Command: {0}", command));
                }
            }
        }

        public bool IsRobotInsideBorders
        {
            get
            {
                bool isInsideBoundaries = false;
                if (RoverPosition.X > RoverPlateau.PlateauPosition.X || RoverPosition.Y > RoverPlateau.PlateauPosition.Y)
                    isInsideBoundaries = true;
                return isInsideBoundaries;
            }
        }

        private void Left()
        {
            RoverOrientation = (RoverOrientation - 1) < Orientations.N ? Orientations.W : RoverOrientation - 1;
        }

        private void Right()
        {
            RoverOrientation = (RoverOrientation + 1) > Orientations.W ? Orientations.N : RoverOrientation + 1;
        }

        private void Advance()
        {
            if (RoverOrientation == Orientations.N)
            {
                RoverPosition.Y++;
            }
            else if (RoverOrientation == Orientations.E)
            {
                RoverPosition.X++;
            }
            else if (RoverOrientation == Orientations.S)
            {
                RoverPosition.Y--;
            }
            else if (RoverOrientation == Orientations.W)
            {
                RoverPosition.X--;
            }
        }

        public override string ToString()
        {
            string printedRoverPosition = string.Format("{0} {1} {2}", RoverPosition.X, RoverPosition.Y, RoverOrientation.GetStringValue());
            if (IsRobotInsideBorders)
                printedRoverPosition =
                    string.Format("Rover outside the field, Rover position is at: {0} , and the plateau limit {1}",
                                  printedRoverPosition, RoverPlateau.PlateauPosition.ToString());

            return printedRoverPosition;

        }
    }
}

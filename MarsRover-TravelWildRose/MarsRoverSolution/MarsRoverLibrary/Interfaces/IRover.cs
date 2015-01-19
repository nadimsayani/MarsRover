using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRover.Library;

namespace MarsRover
{
    public enum Orientations
    {
        [Utils.StringValueAttribute("N")]
        N = 1,
        [Utils.StringValueAttribute("E")]
        E = 2,
        [Utils.StringValueAttribute("S")]
        S = 3,
        [Utils.StringValueAttribute("W")]
        W = 4
    }

    public interface IRover
    {
        IPosition RoverPosition { get; set; }
        Orientations RoverOrientation { get; set; }
        IPlateau RoverPlateau { get; set; }
        bool IsRobotInsideBorders { get; }
        void Process(string commands);
        string ToString();
    }

}

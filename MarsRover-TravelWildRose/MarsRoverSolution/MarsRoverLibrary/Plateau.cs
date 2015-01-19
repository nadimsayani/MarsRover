using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Plateau : IPlateau
    {
        public Position PlateauPosition { get; private set; }

        public Plateau(Position position)
        {
            PlateauPosition = position;
        }
    }
}

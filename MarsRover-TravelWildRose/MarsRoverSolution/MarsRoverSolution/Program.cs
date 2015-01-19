using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Library;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input");
            Console.WriteLine("5 5");
            Console.WriteLine("1 2 N");
           
            Rover one = new Rover(new Position(1, 2), Orientations.N, new Plateau(new Position(5, 5)));
            Console.WriteLine("LMLMLMLMM");
            one.Process("LMLMLMLMM");
            
            Rover two = new Rover(new Position(3, 3), Orientations.E, new Plateau(new Position(5, 5)));
            Console.WriteLine("MMRMMRMRRM");
            two.Process("MMRMMRMRRM");
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Output");

            Console.WriteLine(one.ToString());
            Console.WriteLine(two.ToString());

            Console.ReadLine();

        }
    }
}

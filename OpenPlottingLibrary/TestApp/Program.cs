using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPlottingLibrary;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point3D> sortedPoints = PlaneGenerator.Generate("2*x+3*y", 0, 3, 0, 3, 1f);
            foreach(Point3D p in sortedPoints)
            {
                Console.WriteLine("x = " + p.x + ", y = " + p.y + ", z = " + p.z);
            }
            Console.ReadLine();
        }
    }
}

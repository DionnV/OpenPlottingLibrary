using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlottingLibrary
{
    class PointGenerator
    {
        public List<Point3D> generatedPoints;

        public PointGenerator() 
        {
            generatedPoints = new List<Point3D>();
        }


        public static List<Point3D> Generate(int xMin, int xMax, int yMin, int yMax)
        {
            List<Point3D> generatedPoints = new List<Point3D>();
            for(int x = xMin; x < xMax; x++)
            {
                for (int y = yMin; y < yMax; y++)
                {
                    generatedPoints.Add(new Point3D(x, y, x + y));
                }
            }

            return generatedPoints;
        }

    }
}

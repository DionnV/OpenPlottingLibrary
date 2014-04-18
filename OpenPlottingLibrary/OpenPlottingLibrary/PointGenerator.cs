using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlottingLibrary
{
    public class PointGenerator
    {
        public List<Point3D> generatedPoints;

        public PointGenerator() 
        {
            generatedPoints = new List<Point3D>();
        }


        public static List<Point3D> Generate(int xMin, int xMax, int yMin, int yMax, float density)
        {
            List<Point3D> generatedPoints = new List<Point3D>();
            for (float x = xMin; x <= xMax; x += (float)1/density)
            {
                for (float y = yMin; y <= yMax; y += (float)1/density)
                {
                    generatedPoints.Add(new Point3D(x, y, x + y));
                }
            }
            return generatedPoints;
        }

    }
}

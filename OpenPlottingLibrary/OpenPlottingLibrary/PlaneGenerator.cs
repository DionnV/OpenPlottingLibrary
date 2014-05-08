using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlottingLibrary
{
    public class PlaneGenerator
    {
         public List<Point3D> generatedPlane;

        public PlaneGenerator() 
        {
            generatedPlane = new List<Point3D>();
        }

        public static List<Point3D> Generate(String expr, int xMin, int xMax, int yMin, int yMax, float density)
        {

            List<Point3D> generatedPlane = new List<Point3D>();
          
            float x = xMin;
            float y = yMin;
            float dir = 1;

            var f = Function.ToFunc<float, float, float>(expr, "x", "y");

            float rowCount = 0;

            bool yUp = false;
            bool yDown = false;
            bool start = true;

            while (x <= xMax && y <= yMax)
            {
                //Add first point
                if (start)
                {
                    generatedPlane.Add(new Point3D(x, y, f(x,y)));
                    start = false;
                    yUp = true;
                }

                if (yUp)
                {
                    y += density;
                    generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    yUp = false;
                    yDown = true;
                }

                if (yDown)
                {
                    y -= density;
                    x += dir * density;
                    if (!(x > xMax))
                    {
                        generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    }
                    yUp = true;
                    yDown = false;
                }

                if ((x >= xMax|| x <= xMin) && y <= yMax)
                {
                    rowCount++;
                    y += density;
                    generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    dir = -dir;
                }
            }
            return generatedPlane;
        }
    }
}

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
          
            var f = Function.ToFunc<float, float, float>(expr, "x", "y");

            for (float x = xMin; x <= xMax; x += (1/density))
            {
                for (float y = yMin; y <= yMax; y += (1/density))
                {
                    generatedPlane.Add(new Point3D(x,y, f(x,y)));
                }
            }

            /*            
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
                    if (!(x > xMax || y > yMax))
                    {
                        generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    }
                    x += dir * density;
                    if (!(x > xMax || y > yMax))
                    {
                        generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    }
                    yUp = false;
                    yDown = true;
                }

                if (yDown)
                {
                    y -= density;
                    if (!(x > xMax || y > yMax))
                    {
                        generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    }
                    x += dir * density;
                    if (!(x > xMax || y > yMax))
                    {
                        generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    }
                    yUp = true;
                    yDown = false;
                }

                if ((x >= xMax || x <= xMin) && y <= yMax)
                {
                    rowCount++;
                    y += density;
                    //generatedPlane.Add(new Point3D(x, y, f(x, y)));
                    dir = -dir;
                }
            }
             * */
            return generatedPlane;
        }

        public static List<Point3D> GenerateFlatPlane(int xMin, int xMax, int yMin, int yMax, float density)
        {
            List<Point3D> points = new List<Point3D>();

            for (double i = xMin; i <= xMax; i += 1/density)
            {
                for (double j = yMin; j <= yMax; j += 1/density)
                {
                    points.Add(new Point3D((float)i,(float)j,0));  
                }
            }

            return points;
        }

        public static List<Point3D> GenerateSOMBRERO(int xMin, int xMax, int yMin, int yMax, float density)
        {
            List<Point3D> generatedPlane = new List<Point3D>();
            for (float x = xMin; x <= xMax; x += (1 / density))
            {
                for (float y = yMin; y <= yMax; y += (1 / density))
                {
                    generatedPlane.Add(new Point3D(x, y, Math.Sin((Math.Sqrt(x*x + y*y)) / (Math.Sqrt(x*x + y*y)))));
                }
            }
            return generatedPlane;
        }
    }
}

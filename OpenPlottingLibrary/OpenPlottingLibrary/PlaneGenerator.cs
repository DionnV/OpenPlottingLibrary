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

        public static List<Point3D> Generate(List<Point3D> pointList)
        {
            List<Point3D> generatedPlane = new List<Point3D>();

            //The density can be found by taking the difference between the first two elements of the list.
            float density = Math.Abs(pointList[0].y - pointList[1].y);

            //The starting values can be found by taking the first elements of the list
            float x = pointList[0].x;
            float y = pointList[0].y;

            float rowCount = 0;

            bool yUp = false;
            bool yDown = false;
            bool start = true;


            while(x <= pointList[pointList.Count - 1].x && y <= pointList[pointList.Count - 1].y)
            {
                //Add first point
                if(start)
                {
                    generatedPlane.Add(pointList.Find(point => point.x == x && point.y == y));
                    start = false;
                    yUp = true;
                }

                if(yUp)
                {
                    y += density;
                    generatedPlane.Add(pointList.Find(point => point.x == x && point.y == y));
                    x += density;
                    if (!(x > pointList[pointList.Count - 1].x))
                    {
                        generatedPlane.Add(pointList.Find(point => point.x == x && point.y == y));
                    }
                    yUp = false;
                    yDown = true;                 
                }

                if(yDown)
                {
                    y -= density;
                    generatedPlane.Add(pointList.Find(point => point.x == x && point.y == y));
                    x += density;
                    if (!(x > pointList[pointList.Count - 1].x))
                    {                       
                        generatedPlane.Add(pointList.Find(point => point.x == x && point.y == y));
                    }
                    yUp = true;
                    yDown = false;  
                }

                if (x >= pointList[pointList.Count - 1].x && y <= pointList[pointList.Count - 1].y)
                {
                    rowCount++;
                    x = pointList[0].x;
                    y = pointList[0].y + rowCount * density;
                }
            }            

            return generatedPlane;
        }
    }
}

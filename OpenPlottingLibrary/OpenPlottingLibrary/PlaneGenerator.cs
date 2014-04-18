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
            generatedPlane = pointList.OrderBy(point => point.x + point.y + point.z).ToList();
            return generatedPlane;
        }
    }
}

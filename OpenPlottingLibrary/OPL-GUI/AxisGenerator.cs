using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlottingLibrary
{
    public class AxisGenerator
    {
        public List<Point3D> generatedAxis;
        public enum axis { x, y, z }

        public AxisGenerator()
        {
            generatedAxis = new List<Point3D>();
        }

        public static List<Point3D> Generate(axis ax, int Min, int Max)
        {
            List<Point3D> generatedAxis = new List<Point3D>();

            switch (ax)
            {
                case axis.x:
                    generatedAxis.Add(new Point3D((float)Min, 0, 0));
                    generatedAxis.Add(new Point3D((float)Max, 0, 0));
                    break;
                case axis.y:
                    generatedAxis.Add(new Point3D(0, (float)Min, 0));
                    generatedAxis.Add(new Point3D(0, (float)Max, 0));
                    break;
                case axis.z:
                    generatedAxis.Add(new Point3D(0, 0, (float)Min));
                    generatedAxis.Add(new Point3D(0, 0, (float)Max));
                    break;
            }

            return generatedAxis;
        }
    }
}

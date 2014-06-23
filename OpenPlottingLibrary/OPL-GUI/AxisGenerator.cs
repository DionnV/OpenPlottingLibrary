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
        public enum axis {x,y,z}

        public AxisGenerator() 
        {
            generatedAxis = new List<Point3D>();
        }

        public static List<Point3D> Generate(axis ax ,int Min, int Max)
        {
            List<Point3D> generatedAxis = new List<Point3D>();

            switch(ax)
            {
                case axis.x:
                    for (double i = Min; i <= Max; i = (double)(i + .1))
                    {
                        generatedAxis.Add(new Point3D((float)i, 0, 0));
                    }
                    break;
                case axis.y:
                    for (double i = Min; i <= Max; i = (double)(i + .1))
                    {
                        generatedAxis.Add(new Point3D(0, (float)i, 0));
                    }
                    break;
                case axis.z:
                    for (double i = Min; i <= Max; i = (double)(i + .1))
                    {
                        generatedAxis.Add(new Point3D(0, 0, (float)i));
                    }
                    break;
            }

            return generatedAxis;
        }
    }
}

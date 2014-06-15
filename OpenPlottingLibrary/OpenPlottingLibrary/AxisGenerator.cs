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
                    for (float i = Min; i <= Max; i = (float)(i + .1))
                    {
                        generatedAxis.Add(new Point3D(i, 0, 0));
                    }
                    break;
                case axis.y:
                    for (float i = Min; i <= Max; i = (float)(i + .1))
                    {
                        generatedAxis.Add(new Point3D(0, i, 0));
                    }
                    break;
                case axis.z:
                    for (float i = Min; i <= Max; i = (float)(i + .1))
                    {
                        generatedAxis.Add(new Point3D(0, 0, i));
                    }
                    break;
            }

            return generatedAxis;
        }
    }
}

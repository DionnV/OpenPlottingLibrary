using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlottingLibrary
{
    public class GridGenerator
    {
        public List<Point3D> generatedGrid;
        public enum axis {x,y,z}

        public GridGenerator() 
        {
            generatedGrid = new List<Point3D>();
        }

        public static List<Point3D> Generate(axis ax ,int Min, int Max)
        {
            List<Point3D> generatedGrid = new List<Point3D>();

            switch(ax)
            {
                case axis.x:
                    for (int i = Min; i <= Max; i++)
                    {
                        generatedGrid.Add(new Point3D(0, i, 0));
                        generatedGrid.Add(new Point3D(Min, i, 0));
                        generatedGrid.Add(new Point3D(Max, i, 0));
                        generatedGrid.Add(new Point3D(0, i, 0));
                    }
                    break;
                case axis.y:
                    for (int i = Min; i <= Max; i++)
                    {
                        generatedGrid.Add(new Point3D(i, 0, 0));
                        generatedGrid.Add(new Point3D(i, Min, 0));
                        generatedGrid.Add(new Point3D(i, Max, 0));
                        generatedGrid.Add(new Point3D(i, 0, 0));
                    }
                    for (int i = Min; i <= Max; i++)
                    {
                        generatedGrid.Add(new Point3D(0, 0, i));
                        generatedGrid.Add(new Point3D(0, Min, i));
                        generatedGrid.Add(new Point3D(0, Max, i));
                        generatedGrid.Add(new Point3D(0, 0, i));
                    }                                        
                    break;
                case axis.z:
                    for (int i = Min; i <= Max; i++)
                    {
                        generatedGrid.Add(new Point3D(0, i, 0));
                        generatedGrid.Add(new Point3D(0, i, Min));
                        generatedGrid.Add(new Point3D(0, i, Max));
                        generatedGrid.Add(new Point3D(0, i, 0));
                    }                                        
                    break;
            }

            return generatedGrid;
        }
    }
}

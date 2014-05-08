using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPlottingLibrary;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI
{
    class PointRender : IRenderable
    {
        private List<Point3D> points;
        public void PointRender(List<Point3D> pointList)
        {
            points = pointList;
        }
        public void draw() 
        {
            for (int i = 0; i < this.points.Count; i++)
            {
                //draw points this.points[i]
            }
        }
    }
}

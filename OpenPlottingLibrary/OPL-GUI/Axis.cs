using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPlottingLibrary;

namespace OPL_GUI
{
    class Axis : IRenderable
    {
        public enum axisType { x, y, z };
        axisType type;
        private Point3D basePoint = new Point3D(0, 0, 0);
        private Point3D endPoint;
        public void draw()
        {
            //draw the points of the axis with OpenGL
        }
        public Axis(axisType type)
        {

            switch (type)
            {
                case axisType.x:
                    this.endPoint = new Point3D(1, 0, 0);//adjust length of axis
                    break;
                case axisType.y:
                    this.endPoint = new Point3D(0, 1, 0);//adjust length of axis
                    break;
                case axisType.z:
                    this.endPoint = new Point3D(0, 0, 1);//adjust length of axis
                    break;
            }
        }
    }
}

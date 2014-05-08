using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenPlottingLibrary;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI
{
    class SurfaceRender
    {
        private List<PolygonSet> polyList;

        public void SurfaceRender(List<PolygonSet> polygonList) 
        {
            this.polyList = polygonList;
        }
        public void draw() 
        {
            for (int i = 0; i < this.polyList.Count; i++) 
            { 
                //draw polygons this.polyList[i]
                GL.DrawElements(BeginMode.Triangles)
            }
        }
    }
}

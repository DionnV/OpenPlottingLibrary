using System;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI
{
    public class TimedColor : IRenderable
    {
        private Random rand = new Random(DateTime.Now.Millisecond);

        public void draw()
        {
            GL.ClearColor((float) rand.NextDouble(), (float) rand.NextDouble(), (float) rand.NextDouble(), 0);
        }
    }
}
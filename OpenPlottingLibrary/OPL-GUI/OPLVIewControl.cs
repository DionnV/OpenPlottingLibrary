using System.Drawing;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI
{
    public class OPLViewControl : GLControl
    {


        public OPLViewControl() : base(GraphicsMode.Default, 3, 1, GraphicsContextFlags.ForwardCompatible )
        {
                    
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            
            GL.ClearColor(Color.Bisque);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            this.SwapBuffers();
        }
    }
}
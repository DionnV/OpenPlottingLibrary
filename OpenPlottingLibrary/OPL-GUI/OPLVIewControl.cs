using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI
{
    public class OPLViewControl : GLControl
    {
        private List<IRenderable> _renderlist = new List<IRenderable>(); 

        public OPLViewControl() : base(new GraphicsMode(32, 24, 8, 4), 3, 1, GraphicsContextFlags.ForwardCompatible )
        {
            //this._renderlist.Add(new TimedColor());           
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (isInIDE()) return;

            MakeCurrent();
            _renderlist.ForEach(x => x.draw());

            GL.Clear(ClearBufferMask.ColorBufferBit);
            SwapBuffers();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (isInIDE()) return;

            
        }

        /// <summary>
        /// List of objects that are rendered.
        /// </summary>
        public List<IRenderable> Renderlist
        {
            get { return _renderlist; }
            set { _renderlist = value; }
        }

        public int AntiAlisingLevel
        {
            get { return this.GraphicsMode.Samples; }
        }

        /// <summary>
        /// Checks if the control is used in an designer.
        /// </summary>
        /// <returns>True if used in designer</returns>
        private bool isInIDE()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return true;
            }

            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OPL_GUI.Renderables;

namespace OPL_GUI
{
    public class OPLViewControl : GLControl
    {
        // NonSerialized needs to be here otherwise VS tries to serialize this to the Resx for gods now why and 
        // fails to load it again making the build impossible.
        [NonSerialized]
        private List<IRenderable> _renderlist;
        
        // Checks if the control is in designmode, when in designmode rendering is cancelled. When 
        // rendering in the designer, Visual Studio crashes.
        private bool _indesigner = false;

        private Camera _camera;

        public OPLViewControl() : base(new GraphicsMode(32, 24, 8, 4), 3, 1, GraphicsContextFlags.ForwardCompatible )
        {

            _renderlist = new List<IRenderable>();
            _camera = new Camera(1.3f, this.Width / (float)this.Height, 1f, 20f);

            if(LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                _indesigner = true;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_indesigner) return;

            GL.Viewport(0, 0, this.Width, this.Height);

            MakeCurrent();
            if (_renderlist.Count > 0)
            {
                _renderlist.ForEach(x => x.Draw(_camera));   
            }

            SwapBuffers();
        }

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_indesigner) return;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _camera.AspectRatio = Width/(float) Height;
        }

        #endregion
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
            get { return GraphicsMode.Samples; }
        }
    }
}
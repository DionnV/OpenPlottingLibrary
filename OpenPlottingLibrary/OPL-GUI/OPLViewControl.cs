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

        public Camera _camera;

        public OPLViewControl() : base(new GraphicsMode(32, 24, 8, 4), 3, 1, GraphicsContextFlags.ForwardCompatible )
        {

            _renderlist = new List<IRenderable>();
            _camera = new Camera(new Vector3(1,1,-10), new Quaternion(1,1,1,0));

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
            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            if (_renderlist.Count > 0)
            {
                _renderlist.ForEach(draw);   
            }

            GL.ClearColor(1, 1f, 1f, 1);
            SwapBuffers();
        }

        private void draw(IRenderable renderable)
        {
            // Get the shader program to use 
            GL.UseProgram(renderable.GetShaderProgramHandle());

            renderable.Draw(_camera);

            // Disable shader program
            GL.UseProgram(0);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OPLViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "OPLViewControl";            
            this.ResumeLayout(false);

        }


    }
}
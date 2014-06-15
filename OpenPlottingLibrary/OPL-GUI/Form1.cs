using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using OpenPlottingLibrary;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OPL_GUI.Renderables;

namespace OPL_GUI
{
    public partial class MainWindow : Form
    {
        OPLViewControl _oplvIewControl1;
        MouseInfo _mInfo;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _mInfo = new MouseInfo();
            // The OPLViewcontrol is loaded manually, otherwise the designer keeps crashing
            _oplvIewControl1 = new OPLViewControl
            {
                BackColor = System.Drawing.Color.Black,
                Location = new System.Drawing.Point(12, 12),
                Name = "oplvIewControl1",
                Size = new System.Drawing.Size(947, 592),
                TabIndex = 0,
                VSync = false               
            };
            Controls.Add(_oplvIewControl1);
            this._oplvIewControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OPLViewControl_MouseDown);
            this._oplvIewControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OPLViewControl_MouseMove);
            this._oplvIewControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OPLViewControl_MouseUp);

            GLControl glControl = _oplvIewControl1;
            lblGLVersion.Text = GL.GetInteger(GetPName.MajorVersion) + "." + GL.GetInteger(GetPName.MinorVersion);

            lblAA.Text = glControl.Context.GraphicsMode.Samples.ToString(CultureInfo.InvariantCulture);

            lblVendor.Text = GL.GetString(StringName.Vendor);
            lblRenderer.Text = GL.GetString(StringName.Renderer); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Point3D> points = PlaneGenerator.Generate(expressionBox.Text,-5,5, -5, 5, densityBar.Value);
            
            PointRenderer renderer = new PointRenderer(points);

            ((OPLViewControl)this._oplvIewControl1).Renderlist.Clear();
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(renderer);
            this.Refresh();
        }

        private void OPLViewControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                _mInfo.xPosWhenPressed = e.X;
                _mInfo.yPosWhenPressed = e.Y;
                _mInfo.isLeftDown = true;
            }

            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Rotate graph here
                _mInfo.isRightDown = true;
            }
        }
         
        private void OPLViewControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mInfo.isLeftDown)
            {
                //Moving camera here
                _oplvIewControl1._camera.MoveY((_mInfo.xPosWhenPressed - e.X)/2);
                _oplvIewControl1._camera.MoveX(-(_mInfo.yPosWhenPressed - e.Y)/2);
                _mInfo.xPosWhenPressed = e.X;
                _mInfo.yPosWhenPressed = e.Y;
                this.Refresh();
            }

            if (_mInfo.isRightDown)
            {
                //Rotate graph here
                _oplvIewControl1._camera.MoveZ(-(_mInfo.yPosWhenPressed - e.Y) / 2);
                _mInfo.yPosWhenPressed = e.Y;
                this.Refresh();
            }
        }

        private void OPLViewControl_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            { 
                _mInfo.isLeftDown = false;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                _mInfo.isRightDown = false;
            }
        }
    }
}

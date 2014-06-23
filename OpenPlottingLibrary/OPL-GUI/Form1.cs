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
        Point mousePos;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
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
            this._oplvIewControl1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.OPLViewControl_MouseWheel);

            GLControl glControl = _oplvIewControl1;
            lblGLVersion.Text = GL.GetInteger(GetPName.MajorVersion) + "." + GL.GetInteger(GetPName.MinorVersion);

            lblAA.Text = glControl.Context.GraphicsMode.Samples.ToString(CultureInfo.InvariantCulture);

            lblVendor.Text = GL.GetString(StringName.Vendor);
            lblRenderer.Text = GL.GetString(StringName.Renderer); 
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            List<Point3D> points = PlaneGenerator.Generate(expressionBox.Text,-5, 5, -5, 5, densityBar.Value);
            //List<Point3D> points = PlaneGenerator.GenerateFlatPlane(-10, 10, -10, 10, densityBar.Value);
            List<Point3D> xAxis = AxisGenerator.Generate(AxisGenerator.axis.x, -5, 5);
            List<Point3D> yAxis = AxisGenerator.Generate(AxisGenerator.axis.y, -5, 5);
            List<Point3D> zAxis = AxisGenerator.Generate(AxisGenerator.axis.z, -5, 5);
            
            PointRenderer renderer = new PointRenderer(points, (5 - (-5))*densityBar.Value);
            AxisRenderer xRenderer = new AxisRenderer(xAxis);
            AxisRenderer yRenderer = new AxisRenderer(yAxis);
            AxisRenderer zRenderer = new AxisRenderer(zAxis);


            ((OPLViewControl)this._oplvIewControl1).Renderlist.Clear();
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(renderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(xRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(yRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(zRenderer);
            this.Refresh();
        }

        private void OPLViewControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousePos = e.Location;
            }

            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Rotate graph here
            }
        }
         
        private void OPLViewControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //Moving camera here
                _oplvIewControl1._camera.MoveY((mousePos.X - e.X)/2);
                _oplvIewControl1._camera.MoveX(-(mousePos.Y - e.Y)/2);
                mousePos = e.Location;
                this.Refresh();
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Rotate graph here
                _oplvIewControl1._camera.Rotate((mousePos.X - e.X), (mousePos.Y - e.Y));
                mousePos = e.Location;
                this.Refresh();
            }
        }

        private void OPLViewControl_MouseWheel(object sender, MouseEventArgs e)
        {
            _oplvIewControl1._camera.MoveZ(e.Delta/60);
            this.Refresh();
        }

    }
}

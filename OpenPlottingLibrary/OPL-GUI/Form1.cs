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

        private int _axisSize = 10;
        private int _planeSize = 5;

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
            //List<Point3D> points = PlaneGenerator.Generate(expressionBox.Text, -_planeSize, _planeSize, -_planeSize, _planeSize, densityBar.Value);
            List<Point3D> points = PlaneGenerator.GenerateFlatPlane(-_planeSize, _planeSize, -_planeSize, _planeSize, densityBar.Value);
            List<Point3D> xAxis = AxisGenerator.Generate(AxisGenerator.axis.x, -_axisSize, _axisSize);
            List<Point3D> yAxis = AxisGenerator.Generate(AxisGenerator.axis.y, -_axisSize, _axisSize);
            List<Point3D> zAxis = AxisGenerator.Generate(AxisGenerator.axis.z, -_axisSize, _axisSize);
            List<Point3D> xGrid = GridGenerator.Generate(GridGenerator.axis.x, -_axisSize, _axisSize);
            List<Point3D> yGrid = GridGenerator.Generate(GridGenerator.axis.y, -_axisSize, _axisSize);
            List<Point3D> zGrid = GridGenerator.Generate(GridGenerator.axis.z, -_axisSize, _axisSize);
            
            PointRenderer renderer = new PointRenderer(points, (_planeSize*2)*densityBar.Value);
            XAxisRenderer xRenderer = new XAxisRenderer(xAxis, 2);
            YAxisRenderer yRenderer = new YAxisRenderer(yAxis, 2);
            ZAxisRenderer zRenderer = new ZAxisRenderer(zAxis, 2);
            XGridRenderer xGRenderer = new XGridRenderer(xGrid, _axisSize * 2);
            YGridRenderer yGRenderer = new YGridRenderer(yGrid, _axisSize * 2);
            ZGridRenderer zGRenderer = new ZGridRenderer(zGrid, _axisSize * 2);

            ((OPLViewControl)this._oplvIewControl1).Renderlist.Clear();
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(renderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(xRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(yRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(zRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(xGRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(yGRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(zGRenderer);
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
                _oplvIewControl1._camera.MoveX((mousePos.X - e.X)/2);
                _oplvIewControl1._camera.MoveY((mousePos.Y - e.Y)/2);
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

        private void sombreroButton_Click(object sender, EventArgs e)
        {
            List<Point3D> points = PlaneGenerator.GenerateSOMBRERO( -_planeSize, _planeSize, -_planeSize, _planeSize, densityBar.Value);
            //List<Point3D> points = PlaneGenerator.GenerateFlatPlane(-10, 10, -10, 10, densityBar.Value);
            List<Point3D> xAxis = AxisGenerator.Generate(AxisGenerator.axis.x, -_axisSize, _axisSize);
            List<Point3D> yAxis = AxisGenerator.Generate(AxisGenerator.axis.y, -_axisSize, _axisSize);
            List<Point3D> zAxis = AxisGenerator.Generate(AxisGenerator.axis.z, -_axisSize, _axisSize);

            PointRenderer renderer = new PointRenderer(points, (_planeSize * 2) * densityBar.Value);
            XAxisRenderer xRenderer = new XAxisRenderer(xAxis, 2);
            YAxisRenderer yRenderer = new YAxisRenderer(yAxis, 2);
            ZAxisRenderer zRenderer = new ZAxisRenderer(zAxis, 2);


            ((OPLViewControl)this._oplvIewControl1).Renderlist.Clear();
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(renderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(xRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(yRenderer);
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(zRenderer);
            this.Refresh();
        }

    }
}

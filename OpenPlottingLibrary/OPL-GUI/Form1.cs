using System;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OPL_GUI.Renderables;

namespace OPL_GUI
{
    public partial class MainWindow : Form
    {
        OPLViewControl oplvIewControl1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.oplvIewControl1 = new OPL_GUI.OPLViewControl();
            this.oplvIewControl1.BackColor = System.Drawing.Color.Black;
            this.oplvIewControl1.Location = new System.Drawing.Point(12, 12);
            this.oplvIewControl1.Name = "oplvIewControl1";
            this.oplvIewControl1.Size = new System.Drawing.Size(947, 592);
            this.oplvIewControl1.TabIndex = 0;
            this.oplvIewControl1.VSync = false;
            this.Controls.Add(this.oplvIewControl1);

            GLControl glControl = oplvIewControl1;
            lblGLVersion.Text = GL.GetInteger(GetPName.MajorVersion) + "." +
                                     GL.GetInteger(GetPName.MinorVersion);

            lblAA.Text = glControl.Context.GraphicsMode.Samples.ToString();

            lblVendor.Text = GL.GetString(StringName.Vendor);
            lblRenderer.Text = GL.GetString(StringName.Renderer); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((OPLViewControl)this.oplvIewControl1).Renderlist.Add(new Cube());
            this.Refresh();
        }
    }
}

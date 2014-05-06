using System;
using System.Globalization;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OPL_GUI.Renderables;

namespace OPL_GUI
{
    public partial class MainWindow : Form
    {
        OPLViewControl _oplvIewControl1;

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

            GLControl glControl = _oplvIewControl1;
            lblGLVersion.Text = GL.GetInteger(GetPName.MajorVersion) + "." + GL.GetInteger(GetPName.MinorVersion);

            lblAA.Text = glControl.Context.GraphicsMode.Samples.ToString(CultureInfo.InvariantCulture);

            lblVendor.Text = GL.GetString(StringName.Vendor);
            lblRenderer.Text = GL.GetString(StringName.Renderer); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((OPLViewControl)this._oplvIewControl1).Renderlist.Add(new Cube());
            this.Refresh();
        }
    }
}

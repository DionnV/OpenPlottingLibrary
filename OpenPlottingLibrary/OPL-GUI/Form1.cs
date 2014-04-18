using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OPL_GUI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            GLControl glControl = this.oplvIewControl1;
            this.lblGLVersion.Text = GL.GetInteger(GetPName.MajorVersion) + "." +
                                     GL.GetInteger(GetPName.MinorVersion);

            this.lblAA.Text = glControl.Context.GraphicsMode.Samples.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

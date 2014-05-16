namespace OPL_GUI
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRenderer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAA = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGLVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.expressionBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.densityBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.XBar = new System.Windows.Forms.TrackBar();
            this.YBar = new System.Windows.Forms.TrackBar();
            this.ZBar = new System.Windows.Forms.TrackBar();
            this.XLabel = new System.Windows.Forms.Label();
            this.YLabel = new System.Windows.Forms.Label();
            this.ZLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRenderer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblVendor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblAA);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblGLVersion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(965, 469);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rendering Overview";
            // 
            // lblRenderer
            // 
            this.lblRenderer.AutoSize = true;
            this.lblRenderer.Location = new System.Drawing.Point(100, 55);
            this.lblRenderer.Name = "lblRenderer";
            this.lblRenderer.Size = new System.Drawing.Size(35, 13);
            this.lblRenderer.TabIndex = 7;
            this.lblRenderer.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Renderer:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(100, 42);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(35, 13);
            this.lblVendor.TabIndex = 5;
            this.lblVendor.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vendor:";
            // 
            // lblAA
            // 
            this.lblAA.AutoSize = true;
            this.lblAA.Location = new System.Drawing.Point(100, 29);
            this.lblAA.Name = "lblAA";
            this.lblAA.Size = new System.Drawing.Size(35, 13);
            this.lblAA.TabIndex = 3;
            this.lblAA.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "AA  Level:";
            // 
            // lblGLVersion
            // 
            this.lblGLVersion.AutoSize = true;
            this.lblGLVersion.Location = new System.Drawing.Point(100, 16);
            this.lblGLVersion.Name = "lblGLVersion";
            this.lblGLVersion.Size = new System.Drawing.Size(35, 13);
            this.lblGLVersion.TabIndex = 1;
            this.lblGLVersion.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "OpenGL version:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1094, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Draw";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // expressionBox
            // 
            this.expressionBox.Location = new System.Drawing.Point(1094, 41);
            this.expressionBox.Name = "expressionBox";
            this.expressionBox.Size = new System.Drawing.Size(100, 20);
            this.expressionBox.TabIndex = 3;
            this.expressionBox.Text = "2*x+3*y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1058, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "f(x,y) =";
            // 
            // densityBar
            // 
            this.densityBar.Location = new System.Drawing.Point(1094, 68);
            this.densityBar.Minimum = 1;
            this.densityBar.Name = "densityBar";
            this.densityBar.Size = new System.Drawing.Size(104, 45);
            this.densityBar.TabIndex = 5;
            this.densityBar.Value = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1053, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Density:";
            // 
            // XBar
            // 
            this.XBar.Location = new System.Drawing.Point(1094, 119);
            this.XBar.Maximum = 25;
            this.XBar.Minimum = -25;
            this.XBar.Name = "XBar";
            this.XBar.Size = new System.Drawing.Size(104, 45);
            this.XBar.TabIndex = 7;
            this.XBar.TickFrequency = 5;
            this.XBar.Scroll += new System.EventHandler(this.XBar_Scroll);
            // 
            // YBar
            // 
            this.YBar.Location = new System.Drawing.Point(1094, 170);
            this.YBar.Maximum = 25;
            this.YBar.Minimum = -25;
            this.YBar.Name = "YBar";
            this.YBar.Size = new System.Drawing.Size(104, 45);
            this.YBar.TabIndex = 8;
            this.YBar.TickFrequency = 5;
            this.YBar.Scroll += new System.EventHandler(this.YBar_Scroll);
            // 
            // ZBar
            // 
            this.ZBar.Location = new System.Drawing.Point(1094, 221);
            this.ZBar.Maximum = 25;
            this.ZBar.Minimum = -25;
            this.ZBar.Name = "ZBar";
            this.ZBar.Size = new System.Drawing.Size(104, 45);
            this.ZBar.TabIndex = 9;
            this.ZBar.TickFrequency = 5;
            this.ZBar.Scroll += new System.EventHandler(this.ZBar_Scroll);
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(1061, 119);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(14, 13);
            this.XLabel.TabIndex = 10;
            this.XLabel.Text = "X";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(1061, 170);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(14, 13);
            this.YLabel.TabIndex = 11;
            this.YLabel.Text = "Y";
            // 
            // ZLabel
            // 
            this.ZLabel.AutoSize = true;
            this.ZLabel.Location = new System.Drawing.Point(1061, 221);
            this.ZLabel.Name = "ZLabel";
            this.ZLabel.Size = new System.Drawing.Size(14, 13);
            this.ZLabel.TabIndex = 12;
            this.ZLabel.Text = "Z";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 617);
            this.Controls.Add(this.ZLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.ZBar);
            this.Controls.Add(this.YBar);
            this.Controls.Add(this.XBar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.densityBar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.expressionBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1309, 655);
            this.MinimumSize = new System.Drawing.Size(1309, 655);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Open Plotting Library GUI";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGLVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblRenderer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox expressionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar densityBar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar XBar;
        private System.Windows.Forms.TrackBar YBar;
        private System.Windows.Forms.TrackBar ZBar;
        private System.Windows.Forms.Label XLabel;
        private System.Windows.Forms.Label YLabel;
        private System.Windows.Forms.Label ZLabel;
    }
}


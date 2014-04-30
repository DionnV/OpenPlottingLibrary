﻿namespace OPL_GUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRenderer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblAA = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGLVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.oplvIewControl1 = new OPL_GUI.OPLViewControl();
            this.groupBox1.SuspendLayout();
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
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.label2.Click += new System.EventHandler(this.label2_Click);
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
            // oplvIewControl1
            // 
            this.oplvIewControl1.BackColor = System.Drawing.Color.Black;
            this.oplvIewControl1.Location = new System.Drawing.Point(12, 12);
            this.oplvIewControl1.Name = "oplvIewControl1";
            this.oplvIewControl1.Size = new System.Drawing.Size(947, 592);
            this.oplvIewControl1.TabIndex = 0;
            this.oplvIewControl1.VSync = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 616);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.oplvIewControl1);
            this.Name = "MainWindow";
            this.Text = "Open Plotting Library GUI";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private OPL_GUI.OPLViewControl oplvIewControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGLVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.Label lblRenderer;
        private System.Windows.Forms.Label label4;
    }
}


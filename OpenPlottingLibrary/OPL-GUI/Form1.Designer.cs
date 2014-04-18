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
            this.oplvIewControl1 = new OPL_GUI.OPLViewControl();
            this.SuspendLayout();
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
            this.Controls.Add(this.oplvIewControl1);
            this.Name = "MainWindow";
            this.Text = "Open Plotting Library GUI";
            this.ResumeLayout(false);

        }

        #endregion

        private OPL_GUI.OPLViewControl oplvIewControl1;
    }
}


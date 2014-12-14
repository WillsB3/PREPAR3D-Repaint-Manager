namespace Repaint_Manager
{
    partial class frmMain
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
            this.btnScanAircraft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnScanAircraft
            // 
            this.btnScanAircraft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScanAircraft.Location = new System.Drawing.Point(12, 12);
            this.btnScanAircraft.Name = "btnScanAircraft";
            this.btnScanAircraft.Size = new System.Drawing.Size(185, 23);
            this.btnScanAircraft.TabIndex = 0;
            this.btnScanAircraft.Text = "Scan for Aircraft";
            this.btnScanAircraft.UseVisualStyleBackColor = true;
            this.btnScanAircraft.Click += new System.EventHandler(this.btnScanAircraft_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 134);
            this.Controls.Add(this.btnScanAircraft);
            this.Name = "frmMain";
            this.Text = "Repaint Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnScanAircraft;
    }
}


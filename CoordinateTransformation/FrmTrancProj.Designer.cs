namespace CoordinateTransformation
{
    partial class FrmTrancProj
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
            this.ucCoordTran1 = new CoordinateTransformation.UCCoordTran();
            this.SuspendLayout();
            // 
            // ucCoordTran1
            // 
            this.ucCoordTran1.Location = new System.Drawing.Point(3, 3);
            this.ucCoordTran1.Name = "ucCoordTran1";
            this.ucCoordTran1.Size = new System.Drawing.Size(653, 469);
            this.ucCoordTran1.TabIndex = 0;
            this.ucCoordTran1.Load += new System.EventHandler(this.ucCoordTran1_Load);
            // 
            // FrmTrancProj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 477);
            this.Controls.Add(this.ucCoordTran1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmTrancProj";
            this.Text = "坐标转换";
            this.ResumeLayout(false);

        }

        #endregion

        private UCCoordTran ucCoordTran1;
    }
}
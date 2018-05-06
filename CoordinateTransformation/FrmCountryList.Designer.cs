namespace CoordinateTransformation
{
    partial class FrmCountryList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCountryList));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeState = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.treeState)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "图层 (2).png");
            this.imageList1.Images.SetKeyName(1, "旗帜-实心 (1).png");
            // 
            // treeState
            // 
            this.treeState.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Control;
            this.treeState.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeState.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeState.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeState.Location = new System.Drawing.Point(0, 0);
            this.treeState.Name = "treeState";
            this.treeState.OptionsBehavior.Editable = false;
            this.treeState.OptionsFind.FindDelay = 100;
            this.treeState.OptionsFind.FindFilterColumns = "CoorName";
            this.treeState.OptionsMenu.EnableColumnMenu = false;
            this.treeState.OptionsView.ShowColumns = false;
            this.treeState.SelectImageList = this.imageList1;
            this.treeState.Size = new System.Drawing.Size(227, 446);
            this.treeState.TabIndex = 9;
            this.treeState.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeState_FocusedNodeChanged);
            // 
            // FrmCountryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 446);
            this.Controls.Add(this.treeState);
            this.Name = "FrmCountryList";
            this.Text = "选择国家";
            ((System.ComponentModel.ISupportInitialize)(this.treeState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraTreeList.TreeList treeState;
    }
}
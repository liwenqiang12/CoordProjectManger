namespace CoordinateTransformation
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelCtrl = new DevExpress.XtraEditors.PanelControl();
            this.lblnkCoord = new System.Windows.Forms.LinkLabel();
            this.lblnkFrameTranc = new System.Windows.Forms.LinkLabel();
            this.lblnkCalcPara = new System.Windows.Forms.LinkLabel();
            this.lblnkCoordTran = new System.Windows.Forms.LinkLabel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lnklblParaTranc = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Location = new System.Drawing.Point(12, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(576, 48);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "全球测图空间基准转换系统";
            // 
            // panelCtrl
            // 
            this.panelCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCtrl.Location = new System.Drawing.Point(0, 88);
            this.panelCtrl.Name = "panelCtrl";
            this.panelCtrl.Size = new System.Drawing.Size(784, 446);
            this.panelCtrl.TabIndex = 4;
            // 
            // lblnkCoord
            // 
            this.lblnkCoord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnkCoord.AutoSize = true;
            this.lblnkCoord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnkCoord.Location = new System.Drawing.Point(431, 61);
            this.lblnkCoord.Name = "lblnkCoord";
            this.lblnkCoord.Size = new System.Drawing.Size(0, 16);
            this.lblnkCoord.TabIndex = 6;
            this.lblnkCoord.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblnkCoord_LinkClicked);
            // 
            // lblnkFrameTranc
            // 
            this.lblnkFrameTranc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnkFrameTranc.AutoSize = true;
            this.lblnkFrameTranc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnkFrameTranc.Location = new System.Drawing.Point(513, 61);
            this.lblnkFrameTranc.Name = "lblnkFrameTranc";
            this.lblnkFrameTranc.Size = new System.Drawing.Size(72, 16);
            this.lblnkFrameTranc.TabIndex = 6;
            this.lblnkFrameTranc.TabStop = true;
            this.lblnkFrameTranc.Text = "框架转化";
            this.lblnkFrameTranc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblnkFrameTranc_LinkClicked);
            // 
            // lblnkCalcPara
            // 
            this.lblnkCalcPara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnkCalcPara.AutoSize = true;
            this.lblnkCalcPara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnkCalcPara.Location = new System.Drawing.Point(595, 61);
            this.lblnkCalcPara.Name = "lblnkCalcPara";
            this.lblnkCalcPara.Size = new System.Drawing.Size(72, 16);
            this.lblnkCalcPara.TabIndex = 6;
            this.lblnkCalcPara.TabStop = true;
            this.lblnkCalcPara.Text = "参数解算";
            this.lblnkCalcPara.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblnkCalcPara_LinkClicked);
            // 
            // lblnkCoordTran
            // 
            this.lblnkCoordTran.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnkCoordTran.AutoSize = true;
            this.lblnkCoordTran.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnkCoordTran.Location = new System.Drawing.Point(677, 61);
            this.lblnkCoordTran.Name = "lblnkCoordTran";
            this.lblnkCoordTran.Size = new System.Drawing.Size(72, 16);
            this.lblnkCoordTran.TabIndex = 6;
            this.lblnkCoordTran.TabStop = true;
            this.lblnkCoordTran.Text = "数据转换";
            this.lblnkCoordTran.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblnkCoordTran_LinkClicked);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.InitialImage")));
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(784, 85);
            this.pictureEdit1.TabIndex = 1;
            // 
            // lnklblParaTranc
            // 
            this.lnklblParaTranc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnklblParaTranc.AutoSize = true;
            this.lnklblParaTranc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lnklblParaTranc.Location = new System.Drawing.Point(420, 61);
            this.lnklblParaTranc.Name = "lnklblParaTranc";
            this.lnklblParaTranc.Size = new System.Drawing.Size(72, 16);
            this.lnklblParaTranc.TabIndex = 6;
            this.lnklblParaTranc.TabStop = true;
            this.lnklblParaTranc.Text = "参数转换";
            this.lnklblParaTranc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblParaTranc_LinkClicked);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 535);
            this.Controls.Add(this.lblnkCoordTran);
            this.Controls.Add(this.lblnkCalcPara);
            this.Controls.Add(this.lnklblParaTranc);
            this.Controls.Add(this.lblnkFrameTranc);
            this.Controls.Add(this.lblnkCoord);
            this.Controls.Add(this.panelCtrl);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelCtrl;
        private System.Windows.Forms.LinkLabel lblnkCoord;
        private System.Windows.Forms.LinkLabel lblnkFrameTranc;
        private System.Windows.Forms.LinkLabel lblnkCalcPara;
        private System.Windows.Forms.LinkLabel lblnkCoordTran;
        private System.Windows.Forms.LinkLabel lnklblParaTranc;
    }
}
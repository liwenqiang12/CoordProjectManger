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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelCtrl = new DevExpress.XtraEditors.PanelControl();
            this.lblnkCoord = new System.Windows.Forms.LinkLabel();
            this.lblnkPara = new System.Windows.Forms.LinkLabel();
            this.lblnkCalcPara = new System.Windows.Forms.LinkLabel();
            this.lblnkCoordTran = new System.Windows.Forms.LinkLabel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.mnuTrancPara = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barbtnParamTranc = new DevExpress.XtraBars.BarButtonItem();
            this.barbtnFrameTranc = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuTrancPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
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
            // lblnkPara
            // 
            this.lblnkPara.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblnkPara.AutoSize = true;
            this.lblnkPara.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblnkPara.Location = new System.Drawing.Point(513, 61);
            this.lblnkPara.Name = "lblnkPara";
            this.lblnkPara.Size = new System.Drawing.Size(72, 16);
            this.lblnkPara.TabIndex = 6;
            this.lblnkPara.TabStop = true;
            this.lblnkPara.Text = "转换参数";
            this.lblnkPara.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblnkPara_LinkClicked);
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
            // mnuTrancPara
            // 
            this.mnuTrancPara.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnParamTranc),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnFrameTranc)});
            this.mnuTrancPara.Manager = this.barManager1;
            this.mnuTrancPara.Name = "mnuTrancPara";
            // 
            // barbtnParamTranc
            // 
            this.barbtnParamTranc.Caption = "参数转换法";
            this.barbtnParamTranc.Id = 0;
            this.barbtnParamTranc.Name = "barbtnParamTranc";
            this.barbtnParamTranc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnParamTranc_ItemClick);
            // 
            // barbtnFrameTranc
            // 
            this.barbtnFrameTranc.Caption = "框架转换法";
            this.barbtnFrameTranc.Id = 2;
            this.barbtnFrameTranc.Name = "barbtnFrameTranc";
            this.barbtnFrameTranc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnFrameTranc_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnParamTranc,
            this.barbtnFrameTranc});
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 535);
            this.barDockControlBottom.Size = new System.Drawing.Size(784, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 535);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 535);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 535);
            this.Controls.Add(this.lblnkCoordTran);
            this.Controls.Add(this.lblnkCalcPara);
            this.Controls.Add(this.lblnkPara);
            this.Controls.Add(this.lblnkCoord);
            this.Controls.Add(this.panelCtrl);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.panelCtrl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuTrancPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelCtrl;
        private System.Windows.Forms.LinkLabel lblnkCoord;
        private System.Windows.Forms.LinkLabel lblnkPara;
        private System.Windows.Forms.LinkLabel lblnkCalcPara;
        private System.Windows.Forms.LinkLabel lblnkCoordTran;
        private DevExpress.XtraBars.PopupMenu mnuTrancPara;
        private DevExpress.XtraBars.BarButtonItem barbtnParamTranc;
        private DevExpress.XtraBars.BarButtonItem barbtnFrameTranc;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}
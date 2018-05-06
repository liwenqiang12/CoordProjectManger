﻿namespace CoordinateTransformation
{
    partial class UCParameter
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCParameter));
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeState = new DevExpress.XtraTreeList.TreeList();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.paraGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.AreaofUse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CoorTranName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Defined = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.countryNameCmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.paraTypeCmb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.resetBtn = new DevExpress.XtraEditors.SimpleButton();
            this.searchBtn = new DevExpress.XtraEditors.SimpleButton();
            this.paraCountLbl = new DevExpress.XtraEditors.LabelControl();
            this.addBtn = new DevExpress.XtraEditors.SimpleButton();
            this.editBtn = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.delBtn = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewPosPair = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.paraGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countryNameCmb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paraTypeCmb.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.treeState);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.paraCountLbl);
            this.splitContainerControl1.Panel2.Controls.Add(this.addBtn);
            this.splitContainerControl1.Panel2.Controls.Add(this.editBtn);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnViewPosPair);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnView);
            this.splitContainerControl1.Panel2.Controls.Add(this.delBtn);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(810, 460);
            this.splitContainerControl1.SplitterPosition = 171;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
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
            this.treeState.Size = new System.Drawing.Size(171, 460);
            this.treeState.TabIndex = 8;
            this.treeState.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeState_FocusedNodeChanged);
            this.treeState.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.treeState_CustomDrawNodeImages);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "图层 (2).png");
            this.imageList1.Images.SetKeyName(1, "旗帜-实心 (1).png");
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.paraGridControl);
            this.groupControl1.Location = new System.Drawing.Point(2, 44);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(629, 384);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "转换参数列表";
            // 
            // paraGridControl
            // 
            this.paraGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paraGridControl.Location = new System.Drawing.Point(2, 21);
            this.paraGridControl.MainView = this.gridView1;
            this.paraGridControl.Name = "paraGridControl";
            this.paraGridControl.Size = new System.Drawing.Size(625, 361);
            this.paraGridControl.TabIndex = 9;
            this.paraGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.AreaofUse,
            this.CoorTranName,
            this.Defined});
            this.gridView1.GridControl = this.paraGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // AreaofUse
            // 
            this.AreaofUse.Caption = "国家名称";
            this.AreaofUse.FieldName = "AreaofUse";
            this.AreaofUse.Name = "AreaofUse";
            this.AreaofUse.Visible = true;
            this.AreaofUse.VisibleIndex = 0;
            // 
            // CoorTranName
            // 
            this.CoorTranName.Caption = "转换参数名称";
            this.CoorTranName.FieldName = "CoorTranName";
            this.CoorTranName.Name = "CoorTranName";
            this.CoorTranName.Visible = true;
            this.CoorTranName.VisibleIndex = 1;
            // 
            // Defined
            // 
            this.Defined.Caption = "是否自定义";
            this.Defined.FieldName = "Defined";
            this.Defined.Name = "Defined";
            this.Defined.Visible = true;
            this.Defined.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.countryNameCmb);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.paraTypeCmb);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.resetBtn);
            this.panelControl1.Controls.Add(this.searchBtn);
            this.panelControl1.Location = new System.Drawing.Point(2, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(632, 40);
            this.panelControl1.TabIndex = 16;
            // 
            // countryNameCmb
            // 
            this.countryNameCmb.Location = new System.Drawing.Point(75, 10);
            this.countryNameCmb.Name = "countryNameCmb";
            this.countryNameCmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.countryNameCmb.Size = new System.Drawing.Size(161, 20);
            this.countryNameCmb.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "国家名称:";
            // 
            // paraTypeCmb
            // 
            this.paraTypeCmb.Location = new System.Drawing.Point(314, 10);
            this.paraTypeCmb.Name = "paraTypeCmb";
            this.paraTypeCmb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.paraTypeCmb.Size = new System.Drawing.Size(123, 20);
            this.paraTypeCmb.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(248, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 14);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "参数类型：";
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(526, 7);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(66, 23);
            this.resetBtn.TabIndex = 2;
            this.resetBtn.Text = "重置";
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(452, 7);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(66, 23);
            this.searchBtn.TabIndex = 2;
            this.searchBtn.Text = "筛选";
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // paraCountLbl
            // 
            this.paraCountLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.paraCountLbl.Location = new System.Drawing.Point(8, 436);
            this.paraCountLbl.Name = "paraCountLbl";
            this.paraCountLbl.Size = new System.Drawing.Size(70, 14);
            this.paraCountLbl.TabIndex = 18;
            this.paraCountLbl.Text = "labelControl3";
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.Location = new System.Drawing.Point(553, 432);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 15;
            this.addBtn.Text = "新增";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.editBtn.Location = new System.Drawing.Point(383, 432);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(75, 23);
            this.editBtn.TabIndex = 14;
            this.editBtn.Text = "编辑";
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(291, 432);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 12;
            this.btnView.Text = "查看";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // delBtn
            // 
            this.delBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.delBtn.Location = new System.Drawing.Point(468, 432);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(75, 23);
            this.delBtn.TabIndex = 13;
            this.delBtn.Text = "删除";
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // btnViewPosPair
            // 
            this.btnViewPosPair.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewPosPair.Location = new System.Drawing.Point(183, 432);
            this.btnViewPosPair.Name = "btnViewPosPair";
            this.btnViewPosPair.Size = new System.Drawing.Size(86, 23);
            this.btnViewPosPair.TabIndex = 12;
            this.btnViewPosPair.Text = "查看转换对值";
            this.btnViewPosPair.Click += new System.EventHandler(this.btnViewPosPair_Click);
            // 
            // UCParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UCParameter";
            this.Size = new System.Drawing.Size(810, 460);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.paraGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countryNameCmb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paraTypeCmb.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl paraGridControl;
        private DevExpress.XtraGrid.Columns.GridColumn AreaofUse;
        private DevExpress.XtraGrid.Columns.GridColumn CoorTranName;
        private DevExpress.XtraGrid.Columns.GridColumn Defined;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit countryNameCmb;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit paraTypeCmb;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton resetBtn;
        private DevExpress.XtraEditors.SimpleButton searchBtn;
        public DevExpress.XtraEditors.LabelControl paraCountLbl;
        private DevExpress.XtraEditors.SimpleButton addBtn;
        private DevExpress.XtraEditors.SimpleButton editBtn;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton delBtn;
        private DevExpress.XtraTreeList.TreeList treeState;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnViewPosPair;

    }
}
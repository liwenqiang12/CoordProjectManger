namespace CoordinateTransformation
{
    partial class UCPosPair
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
            this.chkHavZ = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelSou = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddSou = new DevExpress.XtraEditors.SimpleButton();
            this.treePosPair = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.chkBegin2 = new DevExpress.XtraEditors.CheckEdit();
            this.grpAdd = new DevExpress.XtraEditors.GroupControl();
            this.btnedtSou = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkHavZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treePosPair)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBegin2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdd)).BeginInit();
            this.grpAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnedtSou.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHavZ
            // 
            this.chkHavZ.Location = new System.Drawing.Point(193, 0);
            this.chkHavZ.Name = "chkHavZ";
            this.chkHavZ.Properties.Caption = "有Z值";
            this.chkHavZ.Size = new System.Drawing.Size(75, 19);
            this.chkHavZ.TabIndex = 2;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelSou);
            this.groupControl1.Controls.Add(this.btnAddSou);
            this.groupControl1.Controls.Add(this.treePosPair);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(693, 264);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "坐标数值对：";
            // 
            // btnDelSou
            // 
            this.btnDelSou.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelSou.Location = new System.Drawing.Point(654, 53);
            this.btnDelSou.Name = "btnDelSou";
            this.btnDelSou.Size = new System.Drawing.Size(23, 23);
            this.btnDelSou.TabIndex = 1;
            this.btnDelSou.Text = "-";
            this.btnDelSou.Click += new System.EventHandler(this.btnDelSou_Click);
            // 
            // btnAddSou
            // 
            this.btnAddSou.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSou.Location = new System.Drawing.Point(654, 24);
            this.btnAddSou.Name = "btnAddSou";
            this.btnAddSou.Size = new System.Drawing.Size(23, 23);
            this.btnAddSou.TabIndex = 1;
            this.btnAddSou.Text = "+";
            this.btnAddSou.Click += new System.EventHandler(this.btnAddSou_Click);
            // 
            // treePosPair
            // 
            this.treePosPair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treePosPair.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn9,
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7});
            this.treePosPair.Location = new System.Drawing.Point(5, 24);
            this.treePosPair.Name = "treePosPair";
            this.treePosPair.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.True;
            this.treePosPair.OptionsClipboard.CopyNodeHierarchy = DevExpress.Utils.DefaultBoolean.True;
            this.treePosPair.Size = new System.Drawing.Size(643, 218);
            this.treePosPair.TabIndex = 0;
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.Caption = "ID";
            this.treeListColumn9.FieldName = "ID";
            this.treeListColumn9.Name = "treeListColumn9";
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "序号";
            this.treeListColumn1.FieldName = "I_XH";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 20;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "源X";
            this.treeListColumn2.FieldName = "SOU_X";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            this.treeListColumn2.Width = 72;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "源y";
            this.treeListColumn3.FieldName = "SOU_Y";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            this.treeListColumn3.Width = 72;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.Caption = "源Z";
            this.treeListColumn4.FieldName = "SOU_Z";
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 73;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.Caption = "目标X";
            this.treeListColumn5.FieldName = "TAR_X";
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.Caption = "目标Y";
            this.treeListColumn6.FieldName = "TAR_Y";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 5;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.Caption = "目标Z";
            this.treeListColumn7.FieldName = "TAR_Z";
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 6;
            // 
            // chkBegin2
            // 
            this.chkBegin2.Location = new System.Drawing.Point(98, 0);
            this.chkBegin2.Name = "chkBegin2";
            this.chkBegin2.Properties.Caption = "首行标题";
            this.chkBegin2.Size = new System.Drawing.Size(75, 19);
            this.chkBegin2.TabIndex = 2;
            // 
            // grpAdd
            // 
            this.grpAdd.Controls.Add(this.chkHavZ);
            this.grpAdd.Controls.Add(this.chkBegin2);
            this.grpAdd.Controls.Add(this.btnedtSou);
            this.grpAdd.Controls.Add(this.labelControl1);
            this.grpAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAdd.Location = new System.Drawing.Point(0, 264);
            this.grpAdd.Name = "grpAdd";
            this.grpAdd.Size = new System.Drawing.Size(693, 71);
            this.grpAdd.TabIndex = 1;
            this.grpAdd.Text = "补充坐标对值：";
            // 
            // btnedtSou
            // 
            this.btnedtSou.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnedtSou.Location = new System.Drawing.Point(89, 34);
            this.btnedtSou.Name = "btnedtSou";
            this.btnedtSou.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnedtSou.Size = new System.Drawing.Size(588, 20);
            this.btnedtSou.TabIndex = 1;
            this.btnedtSou.TextChanged += new System.EventHandler(this.btnedtSou_TextChanged);
            this.btnedtSou.Click += new System.EventHandler(this.btnedtSou_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(84, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "坐标对值文件：";
            // 
            // UCPosPair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grpAdd);
            this.Name = "UCPosPair";
            this.Size = new System.Drawing.Size(693, 335);
            ((System.ComponentModel.ISupportInitialize)(this.chkHavZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treePosPair)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkBegin2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAdd)).EndInit();
            this.grpAdd.ResumeLayout(false);
            this.grpAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnedtSou.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkHavZ;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDelSou;
        private DevExpress.XtraEditors.SimpleButton btnAddSou;
        private DevExpress.XtraTreeList.TreeList treePosPair;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraEditors.CheckEdit chkBegin2;
        private DevExpress.XtraEditors.GroupControl grpAdd;
        private DevExpress.XtraEditors.ButtonEdit btnedtSou;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

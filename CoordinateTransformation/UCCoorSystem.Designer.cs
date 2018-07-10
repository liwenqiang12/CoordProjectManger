namespace CoordinateTransformation
{
    partial class UCCoorSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCCoorSystem));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.coorInfoCtrl = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Control;
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsFind.FindDelay = 100;
            this.treeList1.OptionsFind.FindFilterColumns = "CoorName";
            this.treeList1.OptionsMenu.EnableColumnMenu = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.SelectImageList = this.imageList1;
            this.treeList1.Size = new System.Drawing.Size(358, 197);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.CustomDrawNodeImages += new DevExpress.XtraTreeList.CustomDrawNodeImagesEventHandler(this.treeList1_CustomDrawNodeImages);
            this.treeList1.FilterNode += new DevExpress.XtraTreeList.FilterNodeEventHandler(this.treeList1_FilterNode);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder1.png");
            this.imageList1.Images.SetKeyName(1, "opened_folder.png");
            this.imageList1.Images.SetKeyName(2, "坐标系.png");
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.coorInfoCtrl);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.treeList1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(358, 447);
            this.splitContainerControl1.SplitterPosition = 245;
            this.splitContainerControl1.TabIndex = 1;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // coorInfoCtrl
            // 
            this.coorInfoCtrl.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.coorInfoCtrl.Appearance.Text.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.coorInfoCtrl.Appearance.Text.Options.UseFont = true;
            this.coorInfoCtrl.Appearance.Text.Options.UseTextOptions = true;
            this.coorInfoCtrl.Appearance.Text.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.coorInfoCtrl.Appearance.Text.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.coorInfoCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coorInfoCtrl.EnableToolTips = true;
            this.coorInfoCtrl.Location = new System.Drawing.Point(0, 0);
            this.coorInfoCtrl.Name = "coorInfoCtrl";
            this.coorInfoCtrl.Options.Export.PlainText.ExportFinalParagraphMark = DevExpress.XtraRichEdit.Export.PlainText.ExportFinalParagraphMark.Never;
            this.coorInfoCtrl.Options.Fields.UpdateFieldsInTextBoxes = false;
            this.coorInfoCtrl.Options.VerticalScrollbar.Visibility = DevExpress.XtraRichEdit.RichEditScrollbarVisibility.Hidden;
            this.coorInfoCtrl.Size = new System.Drawing.Size(358, 245);
            this.coorInfoCtrl.TabIndex = 0;
            this.coorInfoCtrl.Click += new System.EventHandler(this.coorInfoCtrl_Click);
            // 
            // UCCoorSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "UCCoorSystem";
            this.Size = new System.Drawing.Size(358, 447);
            this.Load += new System.EventHandler(this.UCCoorSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraRichEdit.RichEditControl coorInfoCtrl;
        private System.Windows.Forms.ImageList imageList1;
    }
}

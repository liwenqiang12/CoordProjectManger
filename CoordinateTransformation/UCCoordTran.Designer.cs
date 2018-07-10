namespace CoordinateTransformation
{
    partial class UCCoordTran
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
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMidProj = new DevExpress.XtraEditors.TextEdit();
            this.lblMidProj = new DevExpress.XtraEditors.LabelControl();
            this.btnEditTarPrj = new DevExpress.XtraEditors.ButtonEdit();
            this.btnEditSouPrj = new DevExpress.XtraEditors.ButtonEdit();
            this.delBtn = new DevExpress.XtraEditors.SimpleButton();
            this.addBtn = new DevExpress.XtraEditors.SimpleButton();
            this.transBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblTransPara2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tarLocationBtnEdit = new DevExpress.XtraEditors.ButtonEdit();
            this.cmbTransPara2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbTransPara = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lnkShili = new DevExpress.XtraEditors.HyperlinkLabelControl();
            this.sourDataGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMidProj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditTarPrj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSouPrj.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarLocationBtnEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransPara2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransPara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourDataGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(71, 16);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 3;
            this.radioGroup1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "shape"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "csv"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "txt")});
            this.radioGroup1.Size = new System.Drawing.Size(540, 25);
            this.radioGroup1.TabIndex = 0;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(13, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "数据格式:";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtMidProj);
            this.panelControl1.Controls.Add(this.lblMidProj);
            this.panelControl1.Controls.Add(this.btnEditTarPrj);
            this.panelControl1.Controls.Add(this.btnEditSouPrj);
            this.panelControl1.Controls.Add(this.delBtn);
            this.panelControl1.Controls.Add(this.addBtn);
            this.panelControl1.Controls.Add(this.transBtn);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.lblTransPara2);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.tarLocationBtnEdit);
            this.panelControl1.Controls.Add(this.cmbTransPara2);
            this.panelControl1.Controls.Add(this.cmbTransPara);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.radioGroup1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(653, 488);
            this.panelControl1.TabIndex = 2;
            // 
            // txtMidProj
            // 
            this.txtMidProj.Location = new System.Drawing.Point(91, 322);
            this.txtMidProj.Name = "txtMidProj";
            this.txtMidProj.Size = new System.Drawing.Size(520, 20);
            this.txtMidProj.TabIndex = 14;
            // 
            // lblMidProj
            // 
            this.lblMidProj.Location = new System.Drawing.Point(18, 326);
            this.lblMidProj.Name = "lblMidProj";
            this.lblMidProj.Size = new System.Drawing.Size(72, 14);
            this.lblMidProj.TabIndex = 13;
            this.lblMidProj.Text = "中转坐标系：";
            // 
            // btnEditTarPrj
            // 
            this.btnEditTarPrj.Location = new System.Drawing.Point(91, 352);
            this.btnEditTarPrj.Name = "btnEditTarPrj";
            this.btnEditTarPrj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEditTarPrj.Size = new System.Drawing.Size(520, 20);
            this.btnEditTarPrj.TabIndex = 12;
            this.btnEditTarPrj.Tag = "COUNTRYNAME";
            this.btnEditTarPrj.Click += new System.EventHandler(this.buttonEdit1_Click);
            // 
            // btnEditSouPrj
            // 
            this.btnEditSouPrj.Location = new System.Drawing.Point(91, 295);
            this.btnEditSouPrj.Name = "btnEditSouPrj";
            this.btnEditSouPrj.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnEditSouPrj.Size = new System.Drawing.Size(520, 20);
            this.btnEditSouPrj.TabIndex = 12;
            this.btnEditSouPrj.Tag = "COUNTRYNAME";
            this.btnEditSouPrj.Click += new System.EventHandler(this.btnEditCountry_Click);
            // 
            // delBtn
            // 
            this.delBtn.Location = new System.Drawing.Point(615, 78);
            this.delBtn.Name = "delBtn";
            this.delBtn.Size = new System.Drawing.Size(28, 23);
            this.delBtn.TabIndex = 6;
            this.delBtn.Text = "-";
            this.delBtn.Click += new System.EventHandler(this.delBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(615, 52);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(28, 23);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "+";
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // transBtn
            // 
            this.transBtn.Location = new System.Drawing.Point(536, 430);
            this.transBtn.Name = "transBtn";
            this.transBtn.Size = new System.Drawing.Size(75, 23);
            this.transBtn.TabIndex = 6;
            this.transBtn.Text = "转换";
            this.transBtn.Click += new System.EventHandler(this.transBtn_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(30, 381);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 14);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "目标位置：";
            // 
            // lblTransPara2
            // 
            this.lblTransPara2.Location = new System.Drawing.Point(20, 437);
            this.lblTransPara2.Name = "lblTransPara2";
            this.lblTransPara2.Size = new System.Drawing.Size(67, 14);
            this.lblTransPara2.TabIndex = 5;
            this.lblTransPara2.Text = "转换参数2：";
            this.lblTransPara2.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(30, 407);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 14);
            this.labelControl4.TabIndex = 5;
            this.labelControl4.Text = "转换参数：";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(7, 355);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(84, 14);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "目标坐标系统：";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 299);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 14);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "源坐标系统：";
            // 
            // tarLocationBtnEdit
            // 
            this.tarLocationBtnEdit.Location = new System.Drawing.Point(91, 378);
            this.tarLocationBtnEdit.Name = "tarLocationBtnEdit";
            this.tarLocationBtnEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tarLocationBtnEdit.Size = new System.Drawing.Size(520, 20);
            this.tarLocationBtnEdit.TabIndex = 4;
            this.tarLocationBtnEdit.Click += new System.EventHandler(this.tarLocationBtnEdit_Click);
            // 
            // cmbTransPara2
            // 
            this.cmbTransPara2.Location = new System.Drawing.Point(91, 431);
            this.cmbTransPara2.Name = "cmbTransPara2";
            this.cmbTransPara2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTransPara2.Size = new System.Drawing.Size(423, 20);
            this.cmbTransPara2.TabIndex = 3;
            this.cmbTransPara2.Visible = false;
            // 
            // cmbTransPara
            // 
            this.cmbTransPara.Location = new System.Drawing.Point(91, 404);
            this.cmbTransPara.Name = "cmbTransPara";
            this.cmbTransPara.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTransPara.Size = new System.Drawing.Size(520, 20);
            this.cmbTransPara.TabIndex = 3;
            this.cmbTransPara.Visible = true;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lnkShili);
            this.groupControl1.Controls.Add(this.sourDataGridControl);
            this.groupControl1.Location = new System.Drawing.Point(11, 52);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(602, 236);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "源数据";
            // 
            // lnkShili
            // 
            this.lnkShili.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkShili.Location = new System.Drawing.Point(525, 2);
            this.lnkShili.Name = "lnkShili";
            this.lnkShili.Size = new System.Drawing.Size(48, 14);
            this.lnkShili.TabIndex = 13;
            this.lnkShili.Text = "文件示例";
            this.lnkShili.Click += new System.EventHandler(this.lnkShili_Click);
            // 
            // sourDataGridControl
            // 
            this.sourDataGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourDataGridControl.Location = new System.Drawing.Point(2, 21);
            this.sourDataGridControl.MainView = this.gridView1;
            this.sourDataGridControl.Name = "sourDataGridControl";
            this.sourDataGridControl.Size = new System.Drawing.Size(598, 213);
            this.sourDataGridControl.TabIndex = 0;
            this.sourDataGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.sourDataGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // UCCoordTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "UCCoordTran";
            this.Size = new System.Drawing.Size(653, 488);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMidProj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditTarPrj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEditSouPrj.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tarLocationBtnEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransPara2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransPara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourDataGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl sourDataGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton delBtn;
        private DevExpress.XtraEditors.SimpleButton addBtn;
        private DevExpress.XtraEditors.SimpleButton transBtn;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ButtonEdit tarLocationBtnEdit;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTransPara;
        private DevExpress.XtraEditors.ButtonEdit btnEditTarPrj;
        private DevExpress.XtraEditors.ButtonEdit btnEditSouPrj;
        private DevExpress.XtraEditors.HyperlinkLabelControl lnkShili;
        private DevExpress.XtraEditors.LabelControl lblTransPara2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTransPara2;
        private DevExpress.XtraEditors.TextEdit txtMidProj;
        private DevExpress.XtraEditors.LabelControl lblMidProj;

    }
}

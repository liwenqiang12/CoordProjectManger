using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CoordinateTransformation
{
    public delegate void TransParamSavedHandler(CoordTrancParamClass trancparam);

    public partial class FormCoordPara : Form
    {
        public event TransParamSavedHandler OnTransParamSaved = null;
        DataRow focusRow = null;
        int iParamId = -1;
        public FormCoordPara(DataRow currRow)
        {
            InitializeComponent();
            focusRow = currRow;
            iParamId = Convert.ToInt32(focusRow["ID"]);
        }    

        private void saveBtn_Click(object sender, EventArgs e)
        {
            CheckBeforeSave();

            object CoorTranName = tranNameTxtEdit.Text,
            Accuracy = AccurCalcEdit.EditValue,
            WKID = WKIDCalcEdit.EditValue,
            AreaofUse = useAreaTxtEdit.Text,
            //Method = tranMethodTxtEdit.Text,

            MaximumLatitude = maxLatCalcEdit.EditValue,
            MinimumLatitude = minLatCalcEdit.EditValue,
            MaximumLongitude = maxLonCalcEdit.EditValue,
            MinimumLongitude = minLonCalcEdit.EditValue,

            dx = dxCalcEdit.EditValue,
            dy = dyCalcEdit.EditValue,
            dz = dzCalcEdit.EditValue,
            rx = rxCalcEdit.EditValue = rxCalcEdit.Enabled ? rxCalcEdit.EditValue : "null",
            ry = ryCalcEdit.EditValue = ryCalcEdit.Enabled ? ryCalcEdit.EditValue : "null",
            rz = rzCalcEdit.EditValue = rzCalcEdit.Enabled ? rzCalcEdit.EditValue : "null",
            ds = dsCalcEdit.EditValue = dsCalcEdit.Enabled ? dsCalcEdit.EditValue : "null",
            X0 = X0CalcEdit.EditValue = X0CalcEdit.Enabled ? X0CalcEdit.EditValue : "null",
            Y0 = Y0CalcEdit.EditValue = Y0CalcEdit.Enabled ? Y0CalcEdit.EditValue : "null",
            Z0 = Z0CalcEdit.EditValue = Z0CalcEdit.Enabled ? Z0CalcEdit.EditValue : "null";
            string countryName = string.Empty ,
                sou_prj = string.Empty ,
                tar_prj = string.Empty;
            int sou_wkid = 0 ,
                tar_wkid =0 ;
            if (this.btnEditCountry.EditValue != null && (CountryClass)this.btnEditCountry.EditValue != null )
            {
                countryName = ((CountryClass)this.btnEditCountry.EditValue).NAME;
            }
            if (this.btnEditSou.EditValue != null && (CoordProjClass)this.btnEditSou.EditValue != null)
            {
                sou_prj = ((CoordProjClass)this.btnEditSou.EditValue).NAME;
                sou_wkid = ((CoordProjClass)this.btnEditSou.EditValue).WKID;
            }
            if (this.btnEditTar.EditValue != null && (CoordProjClass)this.btnEditTar.EditValue != null)
            {
                tar_prj = ((CoordProjClass)this.btnEditTar.EditValue).NAME;
                tar_wkid = ((CoordProjClass)this.btnEditTar.EditValue).WKID;
            }

            string Method = string.Empty;
            switch (paraTypeCmb.EditValue.ToString())
            { 
                case "三参":
                    Method = "3";
                    break;
                case "七参":
                    Method = "7";
                    break;
                case "十参":
                    Method = "10";
                    break;
            }
            try
            {
                string sqlStr = "";
                if (iParamId <=0 )
                {
                    object maxId = AccessHelper.ExecuteScalar("select max(id) + 1 from CoordinatePara", null);
                    iParamId = (int)maxId;
                    sqlStr = string.Format("INSERT INTO CoordinatePara (CoorTranName,Accuracy,WKID,AreaofUse,Method,MaximumLatitude,MinimumLatitude,MaximumLongitude,MinimumLongitude,dx,dy,dz,rx,ry,rz,ds,X0,Y0,Z0,Defined,ID , PARAM_TYPE,SOU_PRJ,SOU_WKID,TAR_PRJ,TAR_WKID,COUNTRYNAME)"
                          + "VALUES('{0}',{1},{2},'{3}','{4}',{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},'{21}','{22}',{23},'{24}',{25},'{26}')",
                          CoorTranName, Accuracy, WKID, AreaofUse, Method, MaximumLatitude, MinimumLatitude, MaximumLongitude, MinimumLongitude, dx, dy, dz, rx, ry, rz, ds, X0, Y0, Z0, true, Convert.ToInt32(maxId)  ,Method,sou_prj,sou_wkid , tar_prj ,tar_wkid , countryName);
                  
                }
                else  
                {
                    sqlStr = string.Format("UPDATE CoordinatePara SET CoorTranName = '{0}'," +
                     "Accuracy = {1}," +
                     "WKID = {2}," +
                     "AreaofUse =  = '{3}'," +
                     "method =  = '{4}'," +
                     "MaximumLatitude = {5}," +
                     "MinimumLatitude = {6}," +
                     "MaximumLongitude = {7}," +
                     "MinimumLongitude = {8}," +
                     "dx = {9}," +
                     "dy = {10}," +
                     "dz = {11}," +
                     "rx = {12}," +
                     "ry = {13}," +
                     "rz = {14}," +
                     "ds = {15}," +
                     "X0 = {16}," +
                     "Y0 = {17}," +
                     "Z0 = {18}, " +
                     "PARAM_TYPE = '{20}', " +
                     "SOU_PRJ = '{21}', " +
                     "SOU_WKID = {22}, " +
                      "TAR_PRJ = '{23}', " +
                       "TAR_WKID = {24}, " +
                        "COUNTRYNAME = '{25}' " +
                     "WHERE ID={19}",
                      CoorTranName, Accuracy, WKID, AreaofUse, Method, MaximumLatitude, MinimumLatitude, MaximumLongitude, MinimumLongitude, dx, dy, dz, rx, ry, rz, ds, X0, Y0, Z0, iParamId, Method, sou_prj, sou_wkid, tar_prj, tar_wkid, countryName);
                }
                if (AccessHelper.ExecuteNonQuery(sqlStr, null) == 1)
                {
                    this.Text = "编辑 转换参数";
                    if (this.OnTransParamSaved != null)
                    {
                        CoordTrancParamClass trancparam = new CoordTrancParamClass();
                        trancparam.WKID =Convert.ToInt32( WKID );
                        trancparam.ID = iParamId;
                        this.OnTransParamSaved(trancparam);
                    }
                    MessageBox.Show("保存成功！", "提示");
                    
                }
                else
                {
                    MessageBox.Show("保存失败！", "提示");
                    if (this.Text.Contains("新增"))
                        iParamId = 0;
                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show("保存失败！\t\n"+err.Message, "提示");
                if (this.Text.Contains("新增"))
                    iParamId = 0;
               
            }            
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Form frm = this.Owner as Form;
            this.Close();
        }

        private void paraTypeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (paraTypeCmb.SelectedIndex == 0)
            {
                rxCalcEdit.Enabled = false; ryCalcEdit.Enabled = false; rzCalcEdit.Enabled = false; dsCalcEdit.Enabled = false;
                X0CalcEdit.Enabled = false; Y0CalcEdit.Enabled = false; Z0CalcEdit.Enabled = false;
            }

            if (paraTypeCmb.SelectedIndex == 1)
            {
                rxCalcEdit.Enabled = true; ryCalcEdit.Enabled = true; rzCalcEdit.Enabled = true; dsCalcEdit.Enabled = true;
                X0CalcEdit.Enabled = false; Y0CalcEdit.Enabled = false; Z0CalcEdit.Enabled = false;
            }
            if (paraTypeCmb.SelectedIndex == 2)
            {
                rxCalcEdit.Enabled = true; ryCalcEdit.Enabled = true; rzCalcEdit.Enabled = true; dsCalcEdit.Enabled = true;
                X0CalcEdit.Enabled = true; Y0CalcEdit.Enabled = true; Z0CalcEdit.Enabled = true;
            }
        }


        private bool CheckBeforeSave()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if ((ctrl is TextEdit) && string.IsNullOrEmpty((ctrl as TextEdit).Text))
                {
                    MessageBox.Show("参数不得为空值！", "提示");
                    return false;
                }

                //if ((ctrl is TarCalcEdit) && (ctrl as CalcEdit).EditValue == null)
                //{
                //    MessageBox.Show("参数不得为空值！", "提示");
                //    return;
                //}
            }

            foreach (Control ctrl in groupBox2.Controls)
            {
                if ((ctrl is CalcEdit) && ctrl.Enabled == true)
                {
                    if ((ctrl as CalcEdit).EditValue == null)
                    {
                        MessageBox.Show("参数不得为空值！", "提示");
                        return false ;
                    }
                }
            }
            return true;
        }

        private void FormCoordPara_Load(object sender, EventArgs e)
        {
            FormLoad();
        }
        void FormLoad()
        {
            //参数类型绑定值
            string[] typeName = { "三参",  "七参", "十参" };
            paraTypeCmb.Properties.Items.AddRange(typeName);
            paraTypeCmb.SelectedIndex = 0;

            object ds = null; 
            object z0 = null;

            if (this.Text.Contains("编辑"))
            {
                foreach (DataColumn colum in focusRow.Table.Columns)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control.HasChildren)
                        {
                            foreach (Control item in control.Controls)
                            {
                                if (item.Tag != null && item.Tag.ToString().ToUpper().Equals(colum.ColumnName.ToUpper()))
                                {
                                    if (item is TextEdit)
                                        (item as TextEdit).EditValue = focusRow[colum.ColumnName];
                                    if (item is CalcEdit)
                                        (item as CalcEdit).EditValue = focusRow[colum.ColumnName];
                                    if (item is TextBox)
                                    {
                                        (item as TextBox).Text = focusRow[colum.ColumnName].ToString();
                                    }
                                    if (colum.ColumnName.ToUpper().Equals("DS"))
                                        ds = focusRow[colum.ColumnName];
                                    if (colum.ColumnName.ToUpper().Equals("Z0"))
                                        z0 = focusRow[colum.ColumnName];
                                }
                            }
                        }

                    }

                }
                if (!(ds is System.DBNull || ds is System.DBNull))
                    paraTypeCmb.SelectedIndex = 1;
                if (!(ds is System.DBNull) && (ds is System.DBNull))
                    paraTypeCmb.SelectedIndex = 2;
            }
            if (this.Text.Contains("查看"))
            {
                foreach (DataColumn colum in focusRow.Table.Columns)
                {
                    foreach (Control control in this.Controls)
                    {
                        if (control.HasChildren)
                        {
                            foreach (Control item in control.Controls)
                            {
                                if (item.Tag != null && item.Tag.ToString().ToUpper().Equals(colum.ColumnName.ToUpper()))
                                {
                                    if (item is TextEdit )
                                    {
                                        (item as TextEdit).EditValue = focusRow[colum.ColumnName];
                                        (item as TextEdit).Properties.ReadOnly = true;
                                    }
                                    if (item is TextBox)
                                    {
                                        (item as TextBox).Text = focusRow[colum.ColumnName].ToString();
                                        (item as TextBox).ReadOnly = true;
                                    }
                                    if (item is CalcEdit)
                                    {
                                        (item as CalcEdit).EditValue = focusRow[colum.ColumnName];
                                        (item as CalcEdit).Properties.ReadOnly = true;
                                    }

                                    if (colum.ColumnName.ToUpper().Equals("DS"))
                                        ds = focusRow[colum.ColumnName];
                                    if (colum.ColumnName.ToUpper().Equals("Z0"))
                                        z0 = focusRow[colum.ColumnName];
                                    
                                }
                            }
                        }

                    }

                }
                if (!(ds is System.DBNull || ds is System.DBNull))
                    paraTypeCmb.SelectedIndex = 1;
                if (!(ds is System.DBNull) && (ds is System.DBNull))
                    paraTypeCmb.SelectedIndex = 2;

                paraTypeCmb.Properties.ReadOnly = true;
                saveBtn.Enabled = false;
            }
            if (this.Text.Contains("新增"))
            {
                object maxId = AccessHelper.ExecuteScalar("select max(wkid) + 1 from CoordinatePara", null);
                WKIDCalcEdit.EditValue = maxId  ;   
            }
           //初始化坐标系统
            CoordProjClass souprojClass = new CoordProjClass();
            souprojClass.NAME = this.focusRow["SOU_PRJ"].ToString();
            souprojClass.WKID = Convert.ToInt32(this.focusRow["SOU_WKID"]);
            this.btnEditSou.EditValue = souprojClass;

            CoordProjClass tarprojClass = new CoordProjClass();
            tarprojClass.NAME = this.focusRow["TAR_PRJ"].ToString();
            tarprojClass.WKID = Convert.ToInt32(this.focusRow["TAR_WKID"]);
            this.btnEditTar.EditValue = tarprojClass;
        }

        private void useAreaTxtEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void buttonEdit1_Properties_Click(object sender, EventArgs e)
        {
            FrmPrjList frmPrj = new FrmPrjList();
            frmPrj.Filter = "type = 'GEOGRAPHIC'";
            frmPrj.InitTreelist();
            frmPrj.OnPrjSelected += new PrjSelectedHandler(frmPrj_OnPrjSelected);
            frmPrj.ShowDialog();
        }

        void frmPrj_OnPrjSelected(object Project)
        {
            //throw new NotImplementedException();
            btnEditSou.EditValue = Project ;
            //btnEditSou.Text = (Project as CoordProjClass).NAME;
        }

        private void btnEdit_Properties_Click(object sender, EventArgs e)
        {
            FrmPrjList frmPrj = new FrmPrjList();
            frmPrj.Filter = "type = 'GEOGRAPHIC'";
            frmPrj.InitTreelist();
            frmPrj.OnPrjSelected += new PrjSelectedHandler(frmPrj_OnPrjSelected1);
            frmPrj.ShowDialog();
        }
        void frmPrj_OnPrjSelected1(object Project)
        {
            //throw new NotImplementedException();
            btnEditTar.EditValue = Project;
            //btnEditTar.Text = (Project as CoordProjClass).NAME;
        }

        private void buttonEdit1_Properties_Click_1(object sender, EventArgs e)
        {
            FrmCountryList frmPrj = new FrmCountryList();
            frmPrj.OnCountrySelected += new CountrySelectedHandler(frmPrj_OnCountrySelected);
            frmPrj.ShowDialog();
        }

        void frmPrj_OnCountrySelected(object Country)
        {
            //throw new NotImplementedException();
            btnEditCountry.EditValue = Country;
            //btnEditCountry.Text = (Country as CountryClass).NAME;
        }
    }
}

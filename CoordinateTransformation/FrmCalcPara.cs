using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CoordinateTransformation
{
    public partial class FrmCalcPara : Form
    {
        private int _wkid = -1;
        CoordTrancParamClass _trancParamClass = null;
        public FrmCalcPara()
        {
            InitializeComponent();
        }

        private void FrmCalcPara_Load(object sender, EventArgs e)
        {
            //参数类型绑定值
            string[] typeName = { "七参" };
            cmbParamType.Properties.Items.AddRange(typeName);
            cmbParamType.SelectedIndex = 0;
            this.ucPosPair1.Init(-1);
        }
        private void btnEditCountry_Click(object sender, EventArgs e)
        {
            FrmPrjList frmPrj = new FrmPrjList();
            frmPrj.InitTreelist();
            frmPrj.OnPrjSelected += new PrjSelectedHandler(frmPrj_OnPrjSelected);
            frmPrj.ShowDialog();
        }
        void frmPrj_OnPrjSelected(object Project)
        {
            //throw new NotImplementedException();
            btnEditCountry.EditValue = Project;
            //btnEditSou.Text = (Project as CoordProjClass).NAME;
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            FrmPrjList frmPrj = new FrmPrjList();
            frmPrj.InitTreelist();
            frmPrj.OnPrjSelected += new PrjSelectedHandler(frmPrj_OnPrjSelected1);
            frmPrj.ShowDialog();
        }
        void frmPrj_OnPrjSelected1(object Project)
        {
            //throw new NotImplementedException();
            buttonEdit1.EditValue = Project;
            //btnEditSou.Text = (Project as CoordProjClass).NAME;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataTable posDt = this.ucPosPair1.GetPosPair();
            if (posDt == null || posDt.Rows.Count < 3)
            {
                MessageBox.Show("请输入至少三组数据");
                return;
            }
            CoordTrans7Param calparam = new CoordTrans7Param();
            //double[,] souPos = new double[9, 1] { { 111.11},{ 39.12}, {12 }, { 118.345}, {40.123},{ 4 }, { 123.111}, {24.334},{ 2 } };
            //double[,] tarPos = new double[9, 1] { { 111.22}, {39.16}, {12 }, { 118.123}, {40.345},{ 6 }, { 123.104}, {24.304},{ 8 } };
            double[,] souPos = new double[posDt.Rows.Count * 3 , 1];
            double[,] tarPos = new double[posDt.Rows.Count * 3, 1] ;
            double sx, sy, sz, tx, ty, tz;
            for (int i = 0; i < posDt.Rows.Count; i++)
            {
                if (!double.TryParse(posDt.Rows[i]["SOU_X"].ToString(), out sx))
                    sx = 0;
                if (!double.TryParse(posDt.Rows[i]["SOU_Y"].ToString(), out sy))
                    sy = 0;
                if (!double.TryParse(posDt.Rows[i]["SOU_Z"].ToString(), out sz))
                    sz = 0;
                if (!double.TryParse(posDt.Rows[i]["TAR_X"].ToString(), out tx))
                    tx = 0;
                if (!double.TryParse(posDt.Rows[i]["TAR_Y"].ToString(), out ty))
                    ty = 0;
                if (!double.TryParse(posDt.Rows[i]["TAR_Z"].ToString(), out tz))
                    tz = 0;
                souPos[i * 3, 0] = sx;
                souPos[i * 3 + 1 , 0] = sy;
                souPos[i * 3 + 2, 0] = sz;
                tarPos[i * 3, 0] = tx;
                tarPos[i * 3 + 1, 0] = ty;
                tarPos[i * 3 + 2, 0] = tz;
            }
            double result = calparam.CalculateTrans7Param(souPos , tarPos);
            this._trancParamClass = new CoordTrancParamClass();
            this._trancParamClass.DX = calparam.dx;
            this._trancParamClass.DY = calparam.dy;
            this._trancParamClass.DZ = calparam.dz;
            this._trancParamClass.DS = calparam.k;
            this._trancParamClass.RX = calparam.rx;
            this._trancParamClass.RY = calparam.ry;
            this._trancParamClass.RZ = calparam.rz;
            this._trancParamClass.Accuracy = result;
            this.memoEdit1.Text = string.Format("dx:{0} dy:{1} dz:{2}\r\nrx:{3} ry:{4} rz:{5}\r\nds:{6}"
                , calparam.dx, calparam.dy, calparam.dz, calparam.rx, calparam.ry, calparam.rz, calparam.k);
            MessageBox.Show("参数计算完成");
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (this._trancParamClass == null )
            {
                MessageBox.Show("请先计算参数！");
                return;
            }
            if(this.btnEditCountry.EditValue == null || this.buttonEdit1.EditValue == null )
            {
                MessageBox.Show("请选择对应坐标系！");
                return;
            }
            bool firstSave = false;//第一次保存
            if (this._wkid == -1)
            {
                this._wkid = Convert.ToInt32(AccessHelper.ExecuteScalar("select max (wkid) from CoordinatePara ", null)) + 1;
                firstSave = true;
            }
            this._trancParamClass.WKID = _wkid;
            this._trancParamClass.Defined = true;
            this._trancParamClass.Method = "CF";
            this._trancParamClass.PARAM_TYPE = "7";
            this._trancParamClass.SOU_PRJ = this.btnEditCountry.Text;
            this._trancParamClass.SOU_WKID = ( this.btnEditCountry.EditValue as CoordProjClass ).WKID;
            this._trancParamClass.TAR_PRJ = this.buttonEdit1.Text;
            this._trancParamClass.TAR_WKID = (this.buttonEdit1.EditValue as CoordProjClass).WKID;
            DataRow datarow = this._trancParamClass.ToDatarow();
            FormCoordPara coorParaFrm = new FormCoordPara(datarow);
            coorParaFrm.OnTransParamSaved += new TransParamSavedHandler(coorParaFrm_OnTransParamSaved);
            coorParaFrm.Text = "编辑 转换参数";
            coorParaFrm.ShowDialog(this);
            this.ucPosPair1.WKID = this._wkid;
            this.ucPosPair1.Save();
        }

        void coorParaFrm_OnTransParamSaved(CoordTrancParamClass trancparam)
        {
            //throw new NotImplementedException();
            this._trancParamClass.ID = trancparam.ID;
            this._trancParamClass.WKID = trancparam.WKID;
            this._wkid = trancparam.WKID;
        }
        
    }
}

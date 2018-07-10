using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraTreeList.Nodes;

namespace CoordinateTransformation
{
    public partial class UCParameter : UserControl
    {
        //IFeatureWorkspace pWorkspace;
        //ITable coorParaTable;
        DataTable countryNameTable;
        DataTable coorParaTable;
        private string _countryFilter = string.Empty ;
        string[] nameArray;
        public UCParameter()
        {
            InitializeComponent();
            InitControl();
        }
        void InitControl()
        {
          
            treeState.DataSource = CommonClass.CountryNameTable;
            treeState.Columns["REGION"].Visible = false;
            treeState.Columns["NAME"].Visible = false;
            treeState.Columns["ENNAME"].Visible = false;
            treeState.Columns["CONTINENT"].Visible = false;
            treeState.KeyFieldName = "ID";
            treeState.ParentFieldName = "PARID";
            treeState.Text = "";
            treeState.BestFitColumns(true);        
           

            ////国家名称绑定值
            //countryNameTable = AccessHelper.ExecuteDataTable("select NAME from CountryName order by ENNAME ", null);
            //List<string> names = new List<string>();
            //foreach (DataRow row in countryNameTable.Rows)
            //{
            //    if (!string.IsNullOrEmpty(row["NAME"].ToString()))
            //        names.Add(row["NAME"].ToString());
            //}
            //nameArray = names.ToArray();
            //countryNameCmb.Properties.Items.AddRange(nameArray);

            ////参数类型绑定值
            //string[] typeName = { "三参", "七参", "十参" };
            //paraTypeCmb.Properties.Items.AddRange(typeName);

            //坐标系列表绑定值
            coorParaTable = AccessHelper.ExecuteDataTable("select * from CoordinatePara", null);
            paraGridControl.DataSource = coorParaTable;
            paraCountLbl.Text = string.Format("共有{0}条记录", coorParaTable.Rows.Count);
            this.ucCoorSystem1.OnPrjSelected += new PrjSelectedHandler(ucCoorSystem1_OnPrjSelected);

        }

        void ucCoorSystem1_OnPrjSelected(object Project)
        {
            //throw new NotImplementedException();
            if (Project == null)
                return;
            CoordProjClass projClass = Project as CoordProjClass;
            gridView1.ActiveFilterString = string.Format(" (sou_wkid = {1} or tar_wkid = {1}) ", _countryFilter  , projClass.WKID ) ;
            paraCountLbl.Text = string.Format("共有{0}条记录", gridView1.RowCount);
        }

        void Search()
        {
            string filter = "";
          
            string countryname = string.Empty;
           
                TreeListNode treeNode = treeState.FocusedNode;
                if (!treeNode.HasChildren)
                {
                    countryname = treeNode.GetValue("ENNAME").ToString();
                }

            if (!string.IsNullOrEmpty(countryname))
            {
                if (filter != "")
                    filter += " and [AreaofUse] like '%" + countryname + "%'";
                else
                    filter = "[AreaofUse] like '%" + countryname + "%'";
            }
            gridView1.ActiveFilterString = filter;
            _countryFilter = filter;
            paraCountLbl.Text = string.Format("共有{0}条记录", gridView1.RowCount);

        }

        //private void resetBtn_Click(object sender, EventArgs e)
        //{
        //    countryNameCmb.Text = "";
        //    countryNameCmb.ClosePopup();
        //    paraTypeCmb.Text = "";
        //    gridView1.ActiveFilterString = null;
        //    paraCountLbl.Text = string.Format("共有{0}条记录", gridView1.RowCount);
        //}

        private void addBtn_Click(object sender, EventArgs e)
        {
            DataRow datarow = this.gridView1.GetFocusedDataRow();
            FormCoordPara coorParaFrm = new FormCoordPara(datarow);
            coorParaFrm.Text = "新增 转换参数";
            coorParaFrm.ShowDialog(this);
            paraGridControl.DataSource = AccessHelper.ExecuteDataTable("select * from CoordinatePara", null);
            Search();
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            DataRow datarow = this.gridView1.GetFocusedDataRow();
            if (!(bool)datarow["Defined"])
            {
                MessageBox.Show("非自定义参数不可编辑!", "提示");
                return;
            }
            FormCoordPara coorParaFrm = new FormCoordPara(datarow);
            coorParaFrm.Text = "编辑 转换参数";
            coorParaFrm.ShowDialog(this);
            paraGridControl.DataSource = AccessHelper.ExecuteDataTable("select * from CoordinatePara", null);
            Search();
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            DataRow datarow = this.gridView1.GetFocusedDataRow();
            if (!(bool)datarow["Defined"])
            {
                MessageBox.Show("非自定义参数不可删除!", "提示");
                return;
            }
            if (AccessHelper.ExecuteNonQuery("delete from CoordinatePara where id=" + datarow["ID"], null) == 1)
            {
                gridView1.DeleteRow(gridView1.FocusedRowHandle);
                gridView1.RefreshData();
                MessageBox.Show("删除成功！", "提示");
            }
            else
                MessageBox.Show("删除失败！", "提示");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DataRow datarow = this.gridView1.GetFocusedDataRow();
            FormCoordPara coorParaFrm = new FormCoordPara(datarow);
            coorParaFrm.Text = "查看 转换参数";
            coorParaFrm.ShowDialog(this);
        }

        private void treeState_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode currNode = treeState.FocusedNode;
            if (currNode == null || currNode.HasChildren) return;

            //string enName = currNode.GetValue("ENNAME").ToString();
            //gridView1.ActiveFilterString = "[AreaofUse] like '%" + enName + "%'";
            //paraCountLbl.Text = string.Format("共有{0}条记录", gridView1.RowCount);

            string cnName = currNode.GetValue("CNNAME").ToString();
            this.ucCoorSystem1.QueryCoordProject( cnName );
        }

        private void treeState_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            if (e.Node.HasChildren)
            {               
                e.SelectImageIndex = 0;
            }
            else
            {
                e.SelectImageIndex = 1;
            }
        }

        private void btnViewPosPair_Click(object sender, EventArgs e)
        {
            DataRow datarow = this.gridView1.GetFocusedDataRow();
            FrmPosPair frm = new FrmPosPair();
            frm.WKID = Convert.ToInt32( datarow["WKID"] );
            frm.ShowDialog(this);
        }

        private void paraGridControl_Click(object sender, EventArgs e)
        {

        }

        private void ucCoorSystem1_Load(object sender, EventArgs e)
        {

        }

    }
}

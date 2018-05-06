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
    public partial class UCFrameParameter : UserControl
    {
        //IFeatureWorkspace pWorkspace;
        //ITable coorParaTable;
        DataTable ITRF_PARATable;
        string[] nameArray;
        public UCFrameParameter()
        {
            InitializeComponent();
            InitControl();
        }
        void InitControl()
        {
            treeState.KeyFieldName = "ID";
            treeState.ParentFieldName = "PARID";
            treeState.PreviewFieldName = "ITRF_NAME";
            treeState.Text = "";
            treeState.DataSource = CommonClass.ITRFTable;
           
            treeState.BestFitColumns(true);        

            //坐标系列表绑定值
            ITRF_PARATable = AccessHelper.ExecuteDataTable("select * from VW_ITRF ORDER BY PARA_ID ", null);
            paraGridControl.DataSource = ITRF_PARATable;
            paraCountLbl.Text = string.Format("共有{0}条记录", ITRF_PARATable.Rows.Count);

        }
        private void Search(string filter )
        {
            
            gridView1.ActiveFilterString = filter;
            paraCountLbl.Text = string.Format("共有{0}条记录", gridView1.RowCount);
        }
        private void treeState_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode currNode = treeState.FocusedNode;
            if (currNode == null || currNode.HasChildren) return;

            string enName = currNode.GetValue("ITRF_NAME").ToString();
            gridView1.ActiveFilterString = "sou_itrf = '" + enName + "' OR tar_itrf = '" + enName + "' ";
            paraCountLbl.Text = string.Format("共有{0}条记录", gridView1.RowCount);
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xlsx|*.xlsx";
            sfd.OverwritePrompt = true;
            sfd.Title = "导出参数";
            sfd.DefaultExt = ".xlsx";
            sfd.ShowDialog(this);
            if (string.IsNullOrWhiteSpace(sfd.FileName))
            {
                return;
            }
            this.gridView1.ExportToXlsx(sfd.FileName);
            MessageBox.Show("导出完成!");
        }
        
       

    }
}

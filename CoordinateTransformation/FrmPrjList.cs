using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace CoordinateTransformation
{
    public delegate void PrjSelectedHandler( object Project ); 
    public partial class FrmPrjList : Form
    {
        public event PrjSelectedHandler OnPrjSelected = null;
        public string Filter = string.Empty;
        public FrmPrjList()
        {
            InitializeComponent();
            //InitTreelist();
        }
        public  void InitTreelist()
        {
            if( string.IsNullOrWhiteSpace( Filter ))
                treeList1.DataSource = CommonClass.CoorSystemTable;
            else
                treeList1.DataSource = CommonClass.GetCoorSystemTable(Filter);
            treeList1.KeyFieldName = "ID";
            treeList1.ParentFieldName = "PARID";
            treeList1.Columns["OLD_NAME"].Visible = false;
            treeList1.Columns["TYPE"].Visible = false;
            treeList1.Columns["WKID"].Visible = false;
            treeList1.Columns["ORGANIZATION"].Visible = false;
            treeList1.Columns["DEFINITION"].Visible = false;
            treeList1.Columns["DESCRIPTION"].Visible = false;
            //treeList1.Columns["GRADE1"].Visible = false;
            //treeList1.Columns["GRADE2"].Visible = false;
            //treeList1.Columns["GRADE3"].Visible = false;
            //treeList1.Columns["GRADE4"].Visible = false;
            treeList1.Columns["I_JB"].Visible = false;
            treeList1.Text = "";
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {

            TreeListNode currNode = treeList1.FocusedNode;
            if (currNode == null || currNode.HasChildren) return;
            CoordProjClass projClass = new CoordProjClass();
            projClass.NAME = currNode.GetValue("NAME").ToString();
            projClass.WKID = Convert.ToInt32( currNode.GetValue("WKID"));
            projClass.DEFINITION = currNode.GetValue("DEFINITION").ToString();
            if (this.OnPrjSelected != null)
                OnPrjSelected(projClass);
        }

        private void treeList1_CustomDrawNodeImages(object sender, DevExpress.XtraTreeList.CustomDrawNodeImagesEventArgs e)
        {
            if (e.Node.HasChildren)
            {
                if (e.Node.Expanded)
                {
                    e.SelectImageIndex = 1;
                    return;
                }
                e.SelectImageIndex = 0;
            }
            else
            {
                e.SelectImageIndex = 2;
            }
        }


    }
}

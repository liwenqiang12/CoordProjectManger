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
    public delegate void CountrySelectedHandler(object Country);
    public partial class FrmCountryList : Form
    {
        public event CountrySelectedHandler OnCountrySelected = null;
        public FrmCountryList()
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
        }

        private void treeState_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode currNode = treeState.FocusedNode;
            if (currNode == null || currNode.HasChildren) return;
            CountryClass country = new CountryClass();
            country.NAME = currNode.GetValue("NAME").ToString();
            country.ENNAME = currNode.GetValue("ENNAME").ToString();
            country.CONTINENT = currNode.GetValue("CONTINENT").ToString();
            if (this.OnCountrySelected != null)
                OnCountrySelected(country);
        }
    }
}

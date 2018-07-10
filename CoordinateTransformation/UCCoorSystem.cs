using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using ESRI.ArcGIS.Framework;
//using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.Geometry;
using DevExpress.XtraTreeList.Nodes;

namespace CoordinateTransformation
{
    public partial class UCCoorSystem : UserControl
    {
        public event PrjSelectedHandler OnPrjSelected = null;
        public UCCoorSystem()
        {
            InitializeComponent();
            treeList1.ActiveFilterEnabled = true;
        }
        void InitTreelist()
        {
            treeList1.DataSource = CommonClass.CoorSystemTable;
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
        public void QueryCoordProject(string CountryName)
        {
            GetNodeVisible(treeList1.Nodes, CountryName);
            treeList1.ExpandAll();
        }
        private bool GetNodeVisible(TreeListNodes nodes ,string filter)
        {
            bool isVisible = false;
            for (int i = 0; i < nodes.Count; i++)
            {
                TreeListNode node = nodes[i];
                if (node.HasChildren)
                {
                    bool isShow = GetNodeVisible(node.Nodes , filter);
                    node.Visible = isShow;
                    if (isShow)
                        isVisible = true;
                }
                else
                {
                    string NodeText = node["CountryName"].ToString();
                    if (NodeText == filter)
                    {
                        node.Visible = true;
                        isVisible = true;
                    }
                    else
                        node.Visible = false;
                }
            }
            return isVisible;
        }
        private void treeList1_FilterNode(object sender, DevExpress.XtraTreeList.FilterNodeEventArgs e)
        {
            string NodeText = e.Node["CountryName"].ToString();
            bool IsVisible = NodeText== "中国";

            if (IsVisible)
            {
                DevExpress.XtraTreeList.Nodes.TreeListNode Node = e.Node.ParentNode;
                while (Node != null)
                {
                    if (!Node.Visible)
                    {
                        Node.Visible = true;
                        Node = Node.ParentNode;
                    }
                    else
                        break;
                }
            }

            e.Node.Visible = IsVisible;
            e.Handled = true;
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            TreeListNode currNode = treeList1.FocusedNode;
            if (currNode == null || currNode.HasChildren) return;

            coorInfoCtrl.Text = string.Empty;
            string coorInfor = currNode.GetValue("DEFINITION").ToString();
            if (string.IsNullOrEmpty(coorInfor)) return;

            string wkid = currNode.GetValue("WKID").ToString();
            string org = currNode.GetValue("ORGANIZATION").ToString();
            coorInfor = coorInfor.Replace("[", "").Replace("]", "");

            if (currNode.GetValue("TYPE") == null) return;
            //地理坐标系
            if (currNode.GetValue("TYPE").ToString().Trim().Equals("GEOGRAPHIC"))
            {
                string[] separator = { "GEOGCS", "DATUM", "SPHEROID", "PRIMEM", "UNIT" };
                string[] info = coorInfor.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string[] name = { "Geographic Coordinate System: ", "Datum: ", "Spheroid: ", "Prime Meridian: ", "Angular Unit: " };

                coorInfoCtrl.Text = name[0] + info[0].Remove(info[0].Length - 1) + "\t\n" + "WKID: " + wkid + "\t\nOrganization: " + org + "\t\n\n";

                for (int i = 1; i < 5; i++)
                {
                    if (info[i].EndsWith(","))
                        info[i] = info[i].Remove(info[i].Length - 1);
                    coorInfoCtrl.Text += name[i] + info[i] + "\t\n";
                }

            }
            //投影坐标系统 
            if (currNode.GetValue("TYPE").ToString().Trim().Equals("PROJECTED"))
            {
                string[] separator = { "PROJCS", "GEOGCS", "DATUM", "SPHEROID", "PRIMEM", "UNIT", "PROJECTION", "PARAMETER" };
                string[] info = coorInfor.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                string[] name ={"Projected Coordinate System: ","Geographic Coordinate System: ","Datum: ","Spheroid: ",
                                   "Prime Meridian: ","Angular Unit: "};


                coorInfoCtrl.Text = name[0] + info[0].Remove(info[0].Length - 1) + "\t\n" + "WKID: " + wkid + "\t\nOrganization: " + org + "\t\n\n";

                for (int i = 6; i < info.Length; i++)
                {
                  
                    if (info[i].EndsWith(","))
                        info[i] = info[i].Remove(info[i].Length - 1);

                    if (i == 6)
                        coorInfoCtrl.Text += "Projection: " + info[i] + "\t\n";
                    else if (i == info.Length - 1)
                        coorInfoCtrl.Text += "Linear Unit: " + info[i] + "\t\n";
                    else
                        coorInfoCtrl.Text += info[i].Split(',')[0].Replace("\"","") + ": " + info[i].Split(',')[1] + "\t\n";        
                       
                }

                coorInfoCtrl.Text += "\t\n";
                for (int i = 1; i < 6; i++)
                {
                    if (info[i].EndsWith(","))
                        info[i] = info[i].Remove(info[i].Length - 1);

                    coorInfoCtrl.Text += name[i] + info[i] + "\t\n";
                }
            }
             CoordProjClass projClass = new CoordProjClass();
            projClass.NAME = currNode.GetValue("NAME").ToString();
            projClass.WKID = Convert.ToInt32( currNode.GetValue("WKID"));
            projClass.DEFINITION = currNode.GetValue("DEFINITION").ToString();
            if (this.OnPrjSelected != null)
            {
                OnPrjSelected(projClass);
            }

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

        private void coorInfoCtrl_Click(object sender, EventArgs e)
        {

        }

        private void UCCoorSystem_Load(object sender, EventArgs e)
        {
//#if DEBUG
//#else
            InitTreelist();
//#endif
        }
    }
}

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
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        { 
           UCCoorSystem ucCoorSystem= new UCCoorSystem();
           ucCoorSystem.Dock = DockStyle.Fill;
           panelCtrl.Controls.Add(ucCoorSystem);    
                    
        }

        private void coordBtn_Click(object sender, EventArgs e)
        {
            if ((panelCtrl.Controls[0] as UCCoorSystem) != null) return;
            panelCtrl.Controls.Clear();
            UCCoorSystem ucCoorSystem = new UCCoorSystem();
            ucCoorSystem.Dock = DockStyle.Fill;
            panelCtrl.Controls.Add(ucCoorSystem);   
        }

        private void paraBtn_Click(object sender, EventArgs e)
        {
          
            if ((panelCtrl.Controls[0] as UCParameter) != null) return;
            panelCtrl.Controls.Clear();
            UCParameter ucParameter = new UCParameter();
            ucParameter.Dock = DockStyle.Fill;
            panelCtrl.Controls.Add(ucParameter);   
        }

   

        private void coordTranBtn_Click(object sender, EventArgs e)
        {
            if ((panelCtrl.Controls[0] as UCCoordTran) != null) return;
            panelCtrl.Controls.Clear();
            UCCoordTran ucCoordTran = new UCCoordTran();
            ucCoordTran.Dock = DockStyle.Fill;
            panelCtrl.Controls.Add(ucCoordTran);   
        }

        private void lblnkCoord_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((panelCtrl.Controls[0] as UCCoorSystem) != null) return;
            panelCtrl.Controls.Clear();
            UCCoorSystem ucCoorSystem = new UCCoorSystem();
            ucCoorSystem.Dock = DockStyle.Fill;
            panelCtrl.Controls.Add(ucCoorSystem);   
        }

        private void lblnkPara_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.mnuTrancPara.ShowPopup(PointToScreen(new Point(lblnkPara.Location.X, lblnkPara.Bottom + 2)));
        }

        private void lblnkCalcPara_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = Application.OpenForms["FrmCalcPara"];
            if (frm == null || frm.IsDisposed)
            {
                FrmCalcPara coorFrm = new FrmCalcPara();
                coorFrm.Show(this);
            }
            else
            {
                frm.Activate();
                frm.WindowState = FormWindowState.Normal;
            }
        }

        private void lblnkCoordTran_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if ((panelCtrl.Controls[0] as UCCoordTran) != null) return;
            //panelCtrl.Controls.Clear();
            //UCCoordTran ucCoordTran = new UCCoordTran();
            //ucCoordTran.Dock = DockStyle.Fill;
            //panelCtrl.Controls.Add(ucCoordTran); 
            Form frm = Application.OpenForms["FrmTrancProj"];
            if (frm == null || frm.IsDisposed)
            {
                FrmTrancProj coorFrm = new FrmTrancProj();
                coorFrm.Show(this);
            }
            else
            {
                frm.Activate();
                frm.WindowState = FormWindowState.Normal;
            }
        }

        private void barbtnParamTranc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((panelCtrl.Controls[0] as UCParameter) != null) return;
            panelCtrl.Controls.Clear();
            UCParameter ucParameter = new UCParameter();
            ucParameter.Dock = DockStyle.Fill;
            panelCtrl.Controls.Add(ucParameter);   
        }

        private void barbtnFrameTranc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((panelCtrl.Controls[0] as UCFrameParameter) != null) return;
            panelCtrl.Controls.Clear();
            UCFrameParameter ucParameter = new UCFrameParameter();
            ucParameter.Dock = DockStyle.Fill;
            panelCtrl.Controls.Add(ucParameter);   
        }      


    }
}

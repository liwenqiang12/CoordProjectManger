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
    public partial class FrmPosPair : Form
    {
        private int _wkid = -1;
        public int WKID 
        {
            set { _wkid = value; }
        }
        public FrmPosPair()
        {
            InitializeComponent();
        }

        private void FrmPosPair_Load(object sender, EventArgs e)
        {
            this.ucPosPair1.Init(this._wkid);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.ucPosPair1.Save();
        }

      
    }
}

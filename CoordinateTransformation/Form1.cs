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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            this.popupMenu1.ShowPopup(PointToScreen(new Point(hyperlinkLabelControl1.Location.X, hyperlinkLabelControl1.Bottom + 2)));
        }
    }
}

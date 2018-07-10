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
    public partial class FormExample : Form
    {
        public FormExample()
        {
            InitializeComponent();
        }
        public void SetTxt(string txt)
        {
            this.memoEdit1.Text = txt ;
        }
    }
}

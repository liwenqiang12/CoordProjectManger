using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CoordinateTransformation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 1;
            string groupFile = @"C:\Users\Administrator\Desktop\地理坐标系划分\txt\坐标分组.txt";
            string[] groups = File.ReadAllLines(groupFile);
            Dictionary<string, int> dicGroup = new Dictionary<string, int>();
            foreach (string group in groups)
            {
                if (string.IsNullOrWhiteSpace(group))
                    continue;
                dicGroup.Add(group.Split('-')[1].Trim().ToUpper(), Convert.ToInt32(group.Split('-')[0].Trim()));
            }
            string[] files = System.IO.Directory.GetFiles(@"C:\Users\Administrator\Desktop\地理坐标系划分\txt", "*.txt");
            string resultFile = "c:\\geo.txt";
            StringBuilder sb = new StringBuilder();
            int parid = 0;
            int secondParid = 0;
            foreach (string filename in files)
            {
                if (Path.GetFileNameWithoutExtension(filename) == "坐标分组")
                    continue;
                string[] strGeos = File.ReadAllLines(filename);
                foreach (string strgeo in strGeos)
                {
                    if (string.IsNullOrWhiteSpace(strgeo))
                        continue;
                    int currentParid = 0;
                    if (dicGroup.Keys.Contains(strgeo.Trim().ToUpper()))
                    {
                        if (dicGroup[strgeo.Trim().ToUpper()] != 1)
                        {
                            currentParid = secondParid;
                        }
                        else
                        {
                            secondParid = index;
                        }
                        parid = index;
                    }
                    else
                        currentParid = parid;
                    sb.Append(string.Format("{0},{1},{2}\r\n",index ,currentParid , strgeo.Trim()));
                    index++;
                }
            }
            File.WriteAllText(resultFile, sb.ToString());
        }
    }
}

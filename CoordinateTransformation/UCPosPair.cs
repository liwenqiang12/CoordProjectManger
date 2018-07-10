using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;

namespace CoordinateTransformation
{
    public partial class UCPosPair : UserControl
    {
        private int _wkid = -1;
        public int WKID
        {
            set { _wkid = value; }
        }
        public UCPosPair()
        {
            InitializeComponent();
        }

        private void btnAddSou_Click(object sender, EventArgs e)
        {
            int ixh = GetMaxXH() + 1;
            DataTable dt = this.treePosPair.DataSource as DataTable;
            System.Data.DataRow row = dt.NewRow();
            row.SetField("I_XH", ixh);
            row.SetField("WKID", this._wkid);
            dt.Rows.Add(row);
            this.treePosPair.DataSource = dt;
            this.treePosPair.RefreshDataSource();

        }

        private int GetMaxXH()
        {
            DataTable dt = this.treePosPair.DataSource as DataTable;
            if (dt == null)
                return -1;

            int ixh = -1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].IsNull("I_XH"))
                    continue;
                int tempxh;
                if (!int.TryParse(dt.Rows[i]["I_XH"].ToString(), out tempxh))
                    continue;
                if (ixh < tempxh)
                    ixh = tempxh;
            }
            return ixh;
        }

        private void btnedtSou_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件|*.txt";
            ofd.Multiselect = false;
            System.Windows.Forms.DialogResult result = ofd.ShowDialog();
            if (System.Windows.Forms.DialogResult.OK != result && System.Windows.Forms.DialogResult.Yes != result)
                return;
            string filename = ofd.FileName;
            if (string.IsNullOrWhiteSpace(filename))
                return;
            btnedtSou.Text = filename;
        }

        private void btnedtSou_TextChanged(object sender, EventArgs e)
        {
            if (btnedtSou.Text == "")
                return;
            string[] sPosPairs = System.IO.File.ReadAllLines(btnedtSou.Text);
            if (sPosPairs == null || sPosPairs.Length == 0)
            {
                MessageBox.Show("请选择正确的文件");
                return;
            }
            int startIndex = 0;
            if (chkBegin2.Checked)
                startIndex = 1;
            if (sPosPairs.Length <= startIndex)
            {
                MessageBox.Show("请选择正确的文件");
                return;
            }
            int ixh = GetMaxXH() + 1;
            DataTable dt = this.treePosPair.DataSource as DataTable;
            double soux, souy, souz, tarx, tary, tarz;
            int errCount = 0;
            for (int i = startIndex; i < sPosPairs.Length; i++)
            {
                souz = 0;
                tarz = 0;
                try
                {
                    string[] parts = sPosPairs[i].Split(',');
                    soux = Convert.ToDouble(parts[1]);
                    souy = Convert.ToDouble(parts[2]);
                    if (chkHavZ.Checked)
                    {
                        souz = Convert.ToDouble(parts[3]);
                        tarx = Convert.ToDouble(parts[4]);
                        tary = Convert.ToDouble(parts[5]);
                        tarz = Convert.ToDouble(parts[6]);
                    }
                    else
                    {
                        tarx = Convert.ToDouble(parts[3]);
                        tary = Convert.ToDouble(parts[4]);
                    }
                }
                catch
                {
                    errCount++;
                    continue;
                }
                System.Data.DataRow row = dt.NewRow();
                row.SetField("I_XH", ixh++);
                row.SetField("WKID", this._wkid);
                row.SetField("SOU_X", soux);
                row.SetField("SOU_Y", souy);
                row.SetField("SOU_Z", souz);
                row.SetField("TAR_X", tarx);
                row.SetField("TAR_Y", tary);
                row.SetField("TAR_Z", tarz);
                dt.Rows.Add(row);
            }
            if (errCount == 0 || DialogResult.OK == MessageBox.Show(string.Format("总计{0}条记录，其中无效记录{1}条,\r\n是否继续添加？点击“OK”，则继续添加，否则不添加。", sPosPairs.Length - startIndex, errCount), "提示", MessageBoxButtons.OKCancel))
            {
                this.treePosPair.DataSource = dt;
                this.treePosPair.RefreshDataSource();
            }
            else
                this.btnedtSou.Text = "";

        }

        private void btnDelSou_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.DialogResult.OK != MessageBox.Show("确定删除该坐标对吗？“删除”则选择“确定”", "提示", MessageBoxButtons.OKCancel))
                return;
            string delid = string.Empty;
            foreach (TreeListNode node in treePosPair.Selection)
            {
                object objId = node.GetValue("ID");
                if (objId == null || string.IsNullOrWhiteSpace(objId.ToString()))
                    continue;
                delid += objId.ToString() + ",";
            }
            if (!string.IsNullOrEmpty(delid))
            {
                AccessHelper.ExecuteNonQuery("delete from T_POS_PAIR where id in (" + delid.TrimEnd(',') + ")", null);
            }
            this.treePosPair.BeginDelete();
            this.treePosPair.DeleteSelectedNodes();
            this.treePosPair.EndDelete();
            this.treePosPair.RefreshDataSource();
        }
        public void Save()
        {
            DataTable dt = this.treePosPair.DataSource as DataTable;
            List<string> sqllist = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                string sqlFd = "";
                string sqlValue = "";
                if (row.IsNull("ID"))//新增
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName.ToUpper() == "ID" || column.ColumnName.ToUpper() == "TRUNC_NAME" || row.IsNull(column))
                            continue;
                        sqlFd += column.ColumnName + ",";
                        sqlValue += (column.ColumnName.ToUpper() == "WKID"? this._wkid.ToString(): row[column].ToString()) + ",";
                    }
                    sqllist.Add(string.Format("insert into T_POS_PAIR ({0}) values ({1})", sqlFd.TrimEnd(','), sqlValue.TrimEnd(',')));
                }
                else
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        if (column.ColumnName.ToUpper() == "ID" || column.ColumnName.ToUpper() == "TRUNC_NAME")
                            continue;
                        sqlFd += column.ColumnName + " = " + (row.IsNull(column) ? "0" 
                            : (column.ColumnName.ToUpper() == "WKID" ? this._wkid.ToString() : row[column].ToString())) + ",";
                    }
                    sqllist.Add(string.Format("update T_POS_PAIR set {0} where id = {1}", sqlFd.TrimEnd(','), row["ID"]));
                }
            }
            if (AccessHelper.ExecuteNonQuery(sqllist, null))
            {
                DataTable posDt = GetPosPair(_wkid);
                if (posDt == null)
                    return;
                this.treePosPair.DataSource = posDt;
                this.treePosPair.RefreshDataSource();
                MessageBox.Show("保存成功");
            }
        }

        public void Init(int wkid )
        {
            this._wkid = wkid;
            DataTable posDt = GetPosPair(_wkid);
            if (posDt == null)
                posDt = new DataTable();
            this.treePosPair.DataSource = posDt;
            this.treePosPair.RefreshDataSource();
        }
        private DataTable GetPosPair(int wkid)
        {
            string sql = "select * from T_POS_PAIR where wkid = " + wkid;
            DataTable dt = AccessHelper.ExecuteDataTable(sql, null);
            return dt;
        }
        /// <summary>
        /// 获取表格中的数值对
        /// </summary>
        /// <returns></returns>
        public DataTable GetPosPair()
        {
            return this.treePosPair.DataSource as DataTable;
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            string templateFolder = System.IO.Path.Combine(Application.StartupPath, "config");
            string filename = System.IO.Path.Combine(templateFolder, "对应参数示例.txt");
            string txt = System.IO.File.ReadAllText(filename,Encoding.Default);
            FormExample frm = new FormExample();
            frm.SetTxt(txt);
            frm.Show();
        }
    }
}

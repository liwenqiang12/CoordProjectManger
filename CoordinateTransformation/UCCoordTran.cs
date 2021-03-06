﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;

namespace CoordinateTransformation
{
    public partial class UCCoordTran : UserControl
    {
        public UCCoordTran()
        {
            InitializeComponent();
        }

        private void btnEditCountry_Click(object sender, EventArgs e)
        {
            FrmPrjList frmPrj = new FrmPrjList();
            frmPrj.InitTreelist();
            frmPrj.OnPrjSelected += new PrjSelectedHandler(frmPrj_OnPrjSelected);
            frmPrj.ShowDialog();
        }
        private void ShowMidProj(bool isShow)
        {
            txtMidProj.Visible = isShow;
            lblMidProj.Visible = isShow;
            lblTransPara2.Visible = isShow;
            cmbTransPara2.Visible = isShow;
        }
        private void ClearMidProj()
        {
            txtMidProj.Text = "";
            txtMidProj.Tag = null;
            cmbTransPara2.EditValue = null;
            cmbTransPara2.Text = "";
        }
        void frmPrj_OnPrjSelected(object Project)
        {
            //throw new NotImplementedException();
            btnEditSouPrj.EditValue = Project;
            //btnEditCountry.Tag = Project;
            btnEditTarPrj.EditValue = null;
            btnEditTarPrj.Text = "";
            ShowMidProj(false);
            ClearMidProj();
            //btnEditSou.Text = (Project as CoordProjClass).NAME;
        }

        private void buttonEdit1_Click(object sender, EventArgs e)
        {
            FrmPrjList frmPrj = new FrmPrjList();
            frmPrj.InitTreelist();
            frmPrj.OnPrjSelected += new PrjSelectedHandler(frmPrj_OnPrjSelected1);
            frmPrj.ShowDialog();
        }
        void frmPrj_OnPrjSelected1(object Project)
        {
            ClearMidProj();
            ShowMidProj(false);
            //throw new NotImplementedException();
            btnEditTarPrj.EditValue = Project;
            this.cmbTransPara.Properties.Items.Clear();
            this.cmbTransPara2.Properties.Items.Clear();
            DataTable coorParaTable = AccessHelper.ExecuteDataTable(string.Format("select * from CoordinatePara where ( SOU_WKID ={0} and TAR_WKID = {1} ) OR ( SOU_WKID ={1} and TAR_WKID = {0} )",
               (btnEditSouPrj.EditValue as CoordProjClass).WKID, (btnEditTarPrj.EditValue as CoordProjClass).WKID), null);
            if (coorParaTable == null || coorParaTable.Rows.Count == 0)//没有直接转换关系，则尝试中转
            {
                coorParaTable = AccessHelper.ExecuteDataTable(string.Format("select sou_wkid , tar_wkid from CoordinatePara where ( SOU_WKID ={0}  ) OR ( TAR_WKID = {0} )",
               (btnEditSouPrj.EditValue as CoordProjClass).WKID), null);
                if (coorParaTable == null || coorParaTable.Rows.Count == 0)
                    return;
                string wkids = string.Empty;
                for (int i = 0; i < coorParaTable.Rows.Count; i++)
                {
                    if ((btnEditSouPrj.EditValue as CoordProjClass).WKID.ToString() == coorParaTable.Rows[i]["sou_wkid"].ToString())
                    {
                        wkids += coorParaTable.Rows[i]["tar_wkid"].ToString() + ",";
                    }
                    else
                        wkids += coorParaTable.Rows[i]["sou_wkid"].ToString() + ",";
                }
                wkids = wkids.Trim(',');
                coorParaTable = AccessHelper.ExecuteDataTable(string.Format("select sou_wkid , tar_wkid from CoordinatePara where ( SOU_WKID in ({0} ) and TAR_WKID = {1} ) OR ( SOU_WKID ={1} and TAR_WKID in ( {0} ) )",
                 wkids, (btnEditTarPrj.EditValue as CoordProjClass).WKID), null);
                if (coorParaTable == null || coorParaTable.Rows.Count == 0)
                    return;
                string midProjid = coorParaTable.Rows[0]["sou_wkid"].ToString() == (btnEditTarPrj.EditValue as CoordProjClass).WKID.ToString() ?
                    coorParaTable.Rows[0]["tar_wkid"].ToString() : coorParaTable.Rows[0]["sou_wkid"].ToString();
                //获取第一条，作为中转坐标系统
                DataTable midProjdt = CommonClass.GetCoorSystemTable("wkid = " + midProjid);
                CoordProjClass souprojClass = new CoordProjClass();
                souprojClass.NAME = midProjdt.Rows[0]["NAME"].ToString();
                souprojClass.WKID = Convert.ToInt32(midProjid);
                souprojClass.DEFINITION = midProjdt.Rows[0]["DEFINITION"].ToString();
                this.txtMidProj.Text = souprojClass.NAME;
                this.txtMidProj.Tag = souprojClass;

                coorParaTable = AccessHelper.ExecuteDataTable(string.Format("select * from CoordinatePara where ( SOU_WKID ={0} and TAR_WKID = {1} ) OR ( SOU_WKID ={1} and TAR_WKID = {0} )",
               (btnEditSouPrj.EditValue as CoordProjClass).WKID, midProjid), null);
                DataTable coorParaTable2 = AccessHelper.ExecuteDataTable(string.Format("select * from CoordinatePara where ( SOU_WKID ={0} and TAR_WKID = {1} ) OR ( SOU_WKID ={1} and TAR_WKID = {0} )",
               (btnEditTarPrj.EditValue as CoordProjClass).WKID, midProjid), null);

                for (int i = 0; i < coorParaTable2.Rows.Count; i++)
                {
                    this.cmbTransPara2.Properties.Items.Add(new CoordTrancParamClass(coorParaTable2.Rows[i]));

                }
                ShowMidProj(true);
            }
            for (int i = 0; i < coorParaTable.Rows.Count; i++)
            {
                this.cmbTransPara.Properties.Items.Add(new CoordTrancParamClass( coorParaTable.Rows[i] ));
                
            }
            //buttonEdit1.Tag = Project;
            //btnEditSou.Text = (Project as CoordProjClass).NAME;
        }

        private void tarLocationBtnEdit_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            if (folder.ShowDialog() == DialogResult.OK || folder.ShowDialog() == DialogResult.Yes)
            {
               tarLocationBtnEdit.EditValue = folder.SelectedPath;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string extStr;
            if (this.radioGroup1.SelectedIndex == 0)
                extStr = "*.shp|*.shp";
            else if (this.radioGroup1.SelectedIndex == 1)
                extStr = "*.csv|*.csv";
            else
                extStr = "*.txt|*.txt";
            OpenFileDialog fld = new OpenFileDialog();
            fld.DefaultExt = extStr;
            fld.Multiselect = true;
            if (fld.ShowDialog() != DialogResult.OK && fld.ShowDialog() == DialogResult.Yes)
                return;
            string[] filenames =  fld.FileNames;
            List<string> lstFile = filenames.ToList<string>();
            sourDataGridControl.DataSource = lstFile;
            sourDataGridControl.RefreshDataSource();
        }

        private void transBtn_Click(object sender, EventArgs e)
        {
            if (sourDataGridControl.DataSource == null || (sourDataGridControl.DataSource as List<string>).Count == 0)
            {
                MessageBox.Show("请选择待转换数据","提示");
                return;
            }
            if (this.btnEditTarPrj.EditValue == null || this.cmbTransPara.EditValue == null )
            {
                MessageBox.Show("请选择坐标系和转换参数", "提示");
                return;
            }
            string tarFolder = this.tarLocationBtnEdit.Text;
            tarFolder = System.IO.Path.Combine(tarFolder, "转换后");
            if( string.IsNullOrWhiteSpace( tarFolder ) || System.IO.Directory.Exists( tarFolder ))
            {
                MessageBox.Show("前选择空文件夹作为转换目标文件夹！", "提示");
                return;
            }
            System.IO.Directory.CreateDirectory(tarFolder);
            CoordTrancParamClass paramClass = this.cmbTransPara.SelectedItem as CoordTrancParamClass;
            if (paramClass.Defined)
            {
                if (!CreateTranseFile(paramClass, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION,this.txtMidProj.Visible?
                    (this.txtMidProj.Tag as CoordProjClass).DEFINITION:
                    (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION))
                    return;
            }
            CoordTrancParamClass paramClass2 = this.cmbTransPara2.SelectedItem as CoordTrancParamClass;
            if (this.txtMidProj.Visible && paramClass2.Defined)
            {
                if (!CreateTranseFile(paramClass2, (this.txtMidProj.Tag as CoordProjClass).DEFINITION, (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION))
                    return;
            }

            List<string> sourceFiles = sourDataGridControl.DataSource as List<string>;
            for (int i = 0; i < sourceFiles.Count; i++)
            {
                string filename = sourceFiles[i];
                string tarFilename = System.IO.Path.Combine(tarFolder, System.IO.Path.GetFileName(filename));
                if (System.IO.Path.GetExtension(filename).Equals(".txt", StringComparison.OrdinalIgnoreCase)
                    || System.IO.Path.GetExtension(filename).Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    string tempshpfile = System.IO.Path.Combine(Application.StartupPath, "lsdata", DateTime.Now.ToString("yyMMddHHmmss") + ".shp");
                    IFeatureClass tempFeatureclass = CreateShapeFile(tempshpfile, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION);
                    InsertPointToShape(tempFeatureclass, filename, true, true);
                    ComReleaser.ReleaseCOMObject(tempFeatureclass);
                    string tempPrjshpfile = System.IO.Path.Combine(Application.StartupPath, "lsdata", DateTime.Now.ToString("yyMMddHHmmss") + "_prj.shp");
                    if (this.txtMidProj.Visible)
                    {
                        string midprjfile = System.IO.Path.Combine(Application.StartupPath, "lsdata", DateTime.Now.ToString("yyMMddHHmmss") + "_midprj.shp");
                        TrancShape(tempshpfile, midprjfile, paramClass, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION, (this.txtMidProj.Tag as CoordProjClass).DEFINITION);
                        TrancShape(midprjfile, tempPrjshpfile, paramClass2, (this.txtMidProj.Tag as CoordProjClass).DEFINITION, (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION);
                    }
                    else
                         TrancShape(tempshpfile, tempPrjshpfile, paramClass, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION, (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION);
                    OutputTxt(tempPrjshpfile, tarFilename);
                }
                else
                {
                    if (this.txtMidProj.Visible)
                    {
                        string midprjfile = System.IO.Path.Combine(Application.StartupPath, "lsdata", DateTime.Now.ToString("yyMMddHHmmss") + "_midprj.shp");
                        TrancShape(filename, midprjfile, paramClass, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION, (this.txtMidProj.Tag as CoordProjClass).DEFINITION);
                        TrancShape(midprjfile, tarFilename, paramClass2, (this.txtMidProj.Tag as CoordProjClass).DEFINITION, (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION);
                    }
                    else
                    TrancShape(filename, tarFilename, paramClass, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION, (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION);
                    
                }
            }
            MessageBox.Show("转换完成");
            //TrancShape(@"C:\Users\Administrator\Desktop\大羊村042-04-040（040\大羊村042-04-040（040\030合并小班）\f0d9cbb1-b7ad-4f88-8e05-a39d19fc456f.mdb\ZYXB_PY",
            //    @"C:\Users\Administrator\Desktop\大羊村042-04-040（040\大羊村042-04-040（040\030合并小班）\f0d9cbb1-b7ad-4f88-8e05-a39d19fc456f.mdb\ZYXB_PY_80", paramClass, (this.btnEditSouPrj.EditValue as CoordProjClass).DEFINITION, (this.btnEditTarPrj.EditValue as CoordProjClass).DEFINITION);
        }
        private bool TrancShape(string sourceShape, string tarShape, CoordTrancParamClass paramClass, string sourcProj, string tarProj)
        {
            string errLog;
            if (!UtilArcgisClass.GPGeoTransformation(sourceShape, sourcProj.Replace("\"", "'"),
                 tarShape, tarProj.Replace("\"", "'"), paramClass.CoorTranName, out errLog))
            {
                MessageBox.Show(errLog);
                return false;
            }
            return true;
        
            //string lsDir = System.IO.Path.Combine(Application.StartupPath, "lsdata");
            //if (!System.IO.Directory.Exists(lsDir))
            //    Directory.CreateDirectory(lsDir);
            //string pyFile = System.IO.Path.Combine(lsDir, "坐标转化方法.py");
            //File.Copy("坐标转化方法.py", pyFile, true);
            //string pyStr = File.ReadAllText(pyFile);
            //pyStr = pyStr.Replace("@转换名称", paramClass.CoorTranName);
            //pyStr = pyStr.Replace("@源坐标系", sourcProj.Replace("\"", "'"));
            //pyStr = pyStr.Replace("@目标坐标系", tarProj.Replace("\"", "'"));
            //pyStr = pyStr.Replace("@源数据", sourceShape);
            //pyStr = pyStr.Replace("@投影后数据", tarShape);
            //File.WriteAllText(pyFile, pyStr, Encoding.Default);
          
            //if (!GoPythonProcess(pyFile, out errLog))
            //{
            //    MessageBox.Show(errLog);
            //    return false;
            //}
            //return true;
        }
        
        private void OutputTxt(string shpfile , string txtPath)
        {
            FileInfo finfo = new FileInfo(shpfile);
            string parFolder = System.IO.Path.GetDirectoryName(shpfile);
            if (!Directory.Exists(parFolder))
                Directory.CreateDirectory(parFolder);
            IWorkspaceFactory shpwf = new ShapefileWorkspaceFactory();
            IFeatureWorkspace featureWs = shpwf.OpenFromFile(parFolder, 0) as IFeatureWorkspace;
            IFeatureClass featureclass = featureWs.OpenFeatureClass(finfo.Name);
            IFeatureCursor cursor = featureclass.Search(null, false);
            IFeature pfeat = cursor.NextFeature();
            StringBuilder sb = new StringBuilder();
            sb.Append("ID,x,y,z\r\n");
            int index = 1;
            while (pfeat != null)
            {
                IPoint pt = pfeat.Shape as IPoint;
                sb.Append(string.Format("{0},{1},{2},{3}\r\n", index++, pt.X, pt.Y, pt.Z));
                pfeat = cursor.NextFeature();
            }
            ComReleaser.ReleaseCOMObject(cursor);
            ComReleaser.ReleaseCOMObject(pfeat);
            ComReleaser.ReleaseCOMObject(featureclass);
            ComReleaser.ReleaseCOMObject(shpwf);
            File.WriteAllText(txtPath, sb.ToString(), Encoding.Default);
        }
        private void InsertPointToShape(IFeatureClass pfetureclass , string txtPath , bool titleFirstRow , bool codeFirstColumn)
        {
            string[] poss = File.ReadAllLines(txtPath);
            if (poss == null || poss.Length == 0)
                return;
            int columIndex = codeFirstColumn ? 1:0;
            List<IPoint> ptList = new List<IPoint>();
            for (int i = titleFirstRow ?1: 0; i < poss.Length; i++)
            {
                try
                {
                    ESRI.ArcGIS.Geometry.IPoint pt = new PointClass();
                    string[] posv = poss[i].Trim().Split(',');
                    pt.X = Convert.ToDouble(posv[columIndex].Trim());
                    pt.Y = Convert.ToDouble(posv[columIndex + 1].Trim());
                    pt.Z = columIndex + 2 > posv.Length - 1 ? 0 : Convert.ToDouble(posv[columIndex + 2].Trim());
                    IZAware pzware = pt as IZAware;
                    pzware.ZAware = true;
                    ptList.Add(pt);
                }
                catch
                { }
            }
            using (ComReleaser comReleas = new ComReleaser())
            {
                IFeatureCursor cursor = pfetureclass.Insert(true);
                comReleas.ManageLifetime(cursor);
                for (int i = 0; i < ptList.Count; i++)
                {
                    IFeatureBuffer featureBuffer = pfetureclass.CreateFeatureBuffer();
                    comReleas.ManageLifetime(featureBuffer);
                    featureBuffer.Shape = ptList[i];
                    cursor.InsertFeature(featureBuffer);
                }
                cursor.Flush();
            }
        }
        private IFeatureClass CreateShapeFile(string shapeFullname, string proj)
        {
            FileInfo finfo = new FileInfo(shapeFullname);
            string parFolder =  System.IO.Path.GetDirectoryName(shapeFullname);
            if (!Directory.Exists(parFolder))
                Directory.CreateDirectory(parFolder);
            IWorkspaceFactory shpwf = new ShapefileWorkspaceFactory();
            IFeatureWorkspace featureWs = shpwf.OpenFromFile(parFolder, 0) as IFeatureWorkspace;
            IFields pFields = new FieldsClass();
            IFieldsEdit pFieldsEdit = pFields as IFieldsEdit;

            //添加几何字段 
            IField pField = new FieldClass();
            IFieldEdit pFieldEdit = pField as IFieldEdit;
            pFieldEdit.Name_2 = "Shape";
            pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;

            IGeometryDef pGeomDef = new GeometryDefClass();
            IGeometryDefEdit pGeomDefEdit = pGeomDef as IGeometryDefEdit;
            pGeomDefEdit.GeometryType_2 = ESRI.ArcGIS.Geometry.esriGeometryType.esriGeometryPoint; //几何类型
            pGeomDefEdit.HasZ_2 = true ;            //是否有Z值
            pGeomDefEdit.SpatialReference_2  = CreateSpatialReference( proj );//设置空间参考
            pFieldEdit.GeometryDef_2 = pGeomDef;
            pFieldsEdit.AddField(pField);
            return  featureWs.CreateFeatureClass(finfo.Name, pFields, null, null, esriFeatureType.esriFTSimple, "SHAPE", null);

        }

        public static ISpatialReference CreateSpatialReference(string strProj)
        {
            string prjfile = System.IO.Path.Combine(Application.StartupPath, "lsdata", DateTime.Now.ToString("HHmmss")+".prj");
            File.WriteAllText(prjfile, strProj);
            ISpatialReferenceFactory pSpatialReferenceFactory = new SpatialReferenceEnvironmentClass();
            ISpatialReference pSpatialReference = pSpatialReferenceFactory.CreateESRISpatialReferenceFromPRJFile(prjfile);
            return pSpatialReference;
        }  
        private bool CreateTranseFile(CoordTrancParamClass paramClass , string sourcProj , string tarProj )
        {
            string trancFile = System.IO.Path.Combine( Application.StartupPath  , "config" , "trancFilePath.txt" );
            string TrancFolder =string.Empty ; // @"C:\Users\Administrator\AppData\Roaming\Esri\Desktop10.2\ArcToolbox\CustomTransformations" ;
            if( System.IO.File.Exists( trancFile ))
            {
                 string temp = System.IO.File.ReadAllText( trancFile );
                if( System.IO.Directory.Exists( temp ))
                    TrancFolder = temp ;
            }
            if( !string.IsNullOrEmpty( TrancFolder ))//删除已有的转换
            {
                if( System.IO.File.Exists( System.IO.Path.Combine( TrancFolder , paramClass.CoorTranName + ".gtf")))
                {
                    try
                    {
                        System.IO.File.Delete( System.IO.Path.Combine( TrancFolder , paramClass.CoorTranName + ".gtf") );
                    }
                    catch{}
                }
            }
            double X_Axis = paramClass.DX, Y_Axis = paramClass.DY, Z_Axis = paramClass.DZ;
            double xr = paramClass.RX, yr = paramClass.RY, zr = paramClass.RZ, scale = paramClass.DS;
            string paramStr = string.Empty ;
            if( xr == 0 && yr == 0 && zr == 0 && scale == 0)
                paramStr = string.Format("GEOGTRAN[METHOD['Geocentric_Translation'],PARAMETER['X_Axis_Translation',{0}],PARAMETER['Y_Axis_Translation',{1}],PARAMETER['Z_Axis_Translation',{2}]]", X_Axis, Y_Axis, Z_Axis);
            else
                paramStr = string.Format("GEOGTRAN[METHOD['Position_Vector'],PARAMETER['X_Axis_Translation',{0}],PARAMETER['Y_Axis_Translation',{1}],PARAMETER['Z_Axis_Translation',{2}],PARAMETER['X_Axis_Rotation',{3}],PARAMETER['Y_Axis_Rotation',{4}],PARAMETER['Z_Axis_Rotation',{5}],PARAMETER['Scale_Difference',{6}]]"
                , X_Axis, Y_Axis, Z_Axis, xr, yr, zr, scale);
            //pyStr = pyStr.Replace("@转换方式", paramStr);
            string errLog;
            if(!UtilArcgisClass.GPCreateCustomGeoTransformation( paramClass.CoorTranName , sourcProj.Replace("\"","'") ,
                tarProj.Replace("\"", "'") ,paramStr , out errLog ) )
            {
                 if (errLog.Contains("ERROR 000258"))//已存在，则记录gtf的存储位置，然后重新创建一次
                {
                   string gtfFile = errLog.Substring( errLog.IndexOf(": 输出 " ) + 5 , errLog.IndexOf(" 已存在" ) );
                   System.IO.File.WriteAllText( trancFile , new System.IO.FileInfo( gtfFile.Trim()).DirectoryName  );
                     return  CreateTranseFile( paramClass ,  sourcProj ,  tarProj );
                }
                else
                 {
                    MessageBox.Show(errLog);
                    return false;
                 }
            }
            return true;
        }
        private bool GoPythonProcess(string pyPath, out string errLog)
        {
            errLog = string.Empty;
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.FileName = @"C:\Python27\ArcGIS10.2\python.exe";
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.StartInfo.Arguments = pyPath;
                //myProcess.StartInfo.Arguments = string.Format(@"-m gpfeature2feature -i {0} -o {1} {2}"
                //    , sourcPath, tarPath, string.IsNullOrWhiteSpace(whereClause) ? "" : " -where " + whereClause);
                myProcess.Start();
                string result = myProcess.StandardOutput.ReadToEnd();
                result = result.Trim().Trim('\n').Trim('\r');
                myProcess.WaitForExit();
                if (result == "1")
                    return true;
                else
                {
                    errLog = result;
                    return false;
                }
            }
            catch (Exception e)
            {
                errLog = e.Message;
            }

            return false;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
           
            gridView1.DeleteSelectedRows();
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0)
                this.lnkShili.Visible = false;
            else
                this.lnkShili.Visible = true;
        }

        private void lnkShili_Click(object sender, EventArgs e)
        {

            string templateFolder = System.IO.Path.Combine( Application.StartupPath, "config");
                string filename = System.IO.Path.Combine(templateFolder, "源坐标示例.txt");
                string txt = System.IO.File.ReadAllText(filename);
                FormExample frm = new FormExample();
                frm.SetTxt(txt);
                frm.Show();
        }
    }
}

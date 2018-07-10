using System;
using System.Collections.Generic;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.DataSourcesGDB;

namespace CoordinateTransformation
{
    public class UtilArcgisClass
    {

        #region AE方法：获取数据库，要素类；删除要素类、删除要素；根据结构添加字段；合并要素
     
        /// <summary>
        /// 创建要素工作空间 
        /// </summary>
        /// <param name="MDBPath"></param>
        /// <returns></returns>
        public static ESRI.ArcGIS.Geodatabase.IFeatureWorkspace CreateAeWorkspace(string MDBPath)
        {
            ESRI.ArcGIS.DataSourcesGDB.AccessWorkspaceFactoryClass pwsf = new ESRI.ArcGIS.DataSourcesGDB.AccessWorkspaceFactoryClass();
            string mdbparentPath =System.IO. Path.GetDirectoryName(MDBPath);
            string mdbName = System.IO.Path.GetFileNameWithoutExtension(MDBPath);
            pwsf.Create(mdbparentPath, mdbName, null, 0);
            ESRI.ArcGIS.Geodatabase.IWorkspace targetWorkspace = pwsf.OpenFromFile(MDBPath, 0);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pwsf);
            return targetWorkspace as ESRI.ArcGIS.Geodatabase.IFeatureWorkspace;
        }

        //获取要素工作空间
        public static ESRI.ArcGIS.Geodatabase.IFeatureWorkspace GetAeWorkspace(string mdbFile)
        {
            ESRI.ArcGIS.Geodatabase.IFeatureWorkspace featureWorkspace;
            ESRI.ArcGIS.Geodatabase.IWorkspaceFactory workspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.AccessWorkspaceFactoryClass();
            featureWorkspace = workspaceFactory.OpenFromFile(mdbFile, 0) as ESRI.ArcGIS.Geodatabase.IFeatureWorkspace;
            //featureClass = featureWorkspace.OpenFeatureClass(featureName);
            //ReleaseAE.ReleaseAEObject(featureWorkspace);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workspaceFactory);
            return featureWorkspace;
        }

        /// <summary>
        /// 使用全AE方法获取AE要素类
        /// </summary>
        /// <param name="featureWorkspace"></param>
        /// <param name="featureClassName"></param>
        /// <returns></returns>
        public static ESRI.ArcGIS.Geodatabase.IFeatureClass OpenAeFeatureclass(ESRI.ArcGIS.Geodatabase.IFeatureWorkspace featureWorkspace, string featureClassName)
        {
            try
            {
                ESRI.ArcGIS.Geodatabase.IFeatureClass tmpfeatureclass = featureWorkspace.OpenFeatureClass(featureClassName);
                if (tmpfeatureclass != null)
                    return tmpfeatureclass;
            }
            catch
            { }
            return null;
        }
        /// <summary>
        /// 删除要素类
        /// </summary>
        /// <param name="featureWorkspace"></param>
        /// <param name="featureClassName"></param>
        public static void DelAeFeatureclass(ESRI.ArcGIS.Geodatabase.IFeatureWorkspace featureWorkspace, string featureClassName)
        {
            try
            {
                ESRI.ArcGIS.Geodatabase.IFeatureClass tmpfeatureclass = featureWorkspace.OpenFeatureClass(featureClassName);
                ESRI.ArcGIS.Geodatabase.IDataset set = tmpfeatureclass as ESRI.ArcGIS.Geodatabase.IDataset;
                set.CanDelete();
                set.Delete();
            }
            catch
            { }
        }
        /// <summary>
        /// 删除要素类
        /// </summary>
        /// <param name="PFeatureclass"></param>
        /// <param name="whereClause"></param>
        public static void DeleteAeFeature(ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatureclass, string whereClause)
        {              
            ESRI.ArcGIS.Geodatabase.IQueryFilter pQueryFilter = new ESRI.ArcGIS.Geodatabase.QueryFilterClass();
            pQueryFilter.WhereClause = whereClause;
            ESRI.ArcGIS.Geodatabase.ITable pTable = pFeatureclass as ESRI.ArcGIS.Geodatabase.ITable;
            pTable.DeleteSearchedRows(pQueryFilter);          
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pQueryFilter);
        }
         /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="PFeatureclass"></param>
        /// <param name="whereClause"></param>
        public static void DeleteAeFeature(ESRI.ArcGIS.Geodatabase.ITable pTable, string whereClause)
        {           
            ESRI.ArcGIS.Geodatabase.IQueryFilter pQueryFilter = new ESRI.ArcGIS.Geodatabase.QueryFilterClass();
            pQueryFilter.WhereClause = whereClause;           
            pTable.DeleteSearchedRows(pQueryFilter);          
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pQueryFilter);
        }
       
       

        /// <summary>
        /// 合并要素图形范围
        /// </summary>
        /// <param name="pFeatureclass">要合并的要素类</param>
        /// <param name="filter">过滤条件</param>
        /// <returns></returns>
        public static IGeometry UnionFeature(ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatureclass, string filter)
        {
            IGeometry geo = null;
            using (ComReleaser comReleaser = new ComReleaser())
            {
                List<IGeometry> geoLst = new List<IGeometry>();
                ESRI.ArcGIS.Geodatabase.IGeoDataset geoDataset = pFeatureclass as ESRI.ArcGIS.Geodatabase.IGeoDataset;
                ESRI.ArcGIS.Geodatabase.IFeatureCursor featureCursor = pFeatureclass.Search(new ESRI.ArcGIS.Geodatabase.QueryFilter { WhereClause = filter }, false);
                ESRI.ArcGIS.Geodatabase.IFeature pFeature = featureCursor.NextFeature();
                while (pFeature != null)
                {
                    geoLst.Add(pFeature.ShapeCopy);
                    if (geoLst.Count == 50)
                    {
                        geo = UnionGeometry(geoLst, geoDataset.SpatialReference);
                        geoLst.Clear();
                        geoLst.Add(geo);
                    }
                    comReleaser.ManageLifetime(pFeature);
                    pFeature = featureCursor.NextFeature();
                }
                if (geoLst.Count == 1)
                    geo = geoLst[0];
                if (geoLst.Count > 1)
                {
                    geo = UnionGeometry(geoLst, geoDataset.SpatialReference);
                }
                IZAware ipZAware = geo as IZAware;
                if (ipZAware.ZAware == true)
                {
                    ipZAware.ZAware = false;
                }
                comReleaser.ManageLifetime(featureCursor);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(featureCursor);  
            }
            return geo;
        }

        private static IGeometry UnionGeometry(List<IGeometry> geoLst, ISpatialReference SpatialReference)
        {
            IGeometry geo = null;
            using (ComReleaser comReleaser = new ComReleaser())
            {
                ESRI.ArcGIS.Geometry.IGeometry geometryBag = new ESRI.ArcGIS.Geometry.GeometryBagClass();
                geometryBag.SpatialReference = SpatialReference;
                ESRI.ArcGIS.Geometry.IGeometryCollection geometryCollection = geometryBag as ESRI.ArcGIS.Geometry.IGeometryCollection;
                object missing = Type.Missing;
                foreach (IGeometry item in geoLst)
                {
                    geometryCollection.AddGeometry(item, ref missing, ref missing);
                }
                ITopologicalOperator unionedPolygon = new PolygonClass();
                unionedPolygon.ConstructUnion(geometryBag as IEnumGeometry);
                geo = unionedPolygon as IGeometry;

                comReleaser.ManageLifetime(geometryBag);
                comReleaser.ManageLifetime(geometryCollection);
            }
            return geo;
        }

        #endregion

        #region AE方法：重置地图文档数据源；获取IDatasetName、IWorkspaceName；
        /// <summary>
        /// 重置mxd文档的数据源
        /// </summary>
        /// <param name="pMapDoc"></param>
        /// <param name="pWs"></param>
        public static void ChangeMxdDataSource(ESRI.ArcGIS.Carto.IMapDocument pMapDoc, ESRI.ArcGIS.Geodatabase.IWorkspace pWs)
        {
            ESRI.ArcGIS.Geodatabase.IWorkspaceName pWsName = GetWorkspaceName(pWs);
            ESRI.ArcGIS.Carto.IMap pMap = pMapDoc.ActiveView.FocusMap;
            ESRI.ArcGIS.Carto.ILayer pLayer = null;
            ESRI.ArcGIS.Carto.IDataLayer pDataLayer = null;
            ESRI.ArcGIS.Geodatabase.IDatasetName pDataName = null;
            for (int i = 0; i < pMap.LayerCount; i++)
            {
                pLayer = pMap.get_Layer(i);
                if (pLayer.Valid == false)
                {
                    if (pLayer is ESRI.ArcGIS.Carto.IDataLayer)
                    {

                        pDataLayer = pLayer as ESRI.ArcGIS.Carto.IDataLayer;
                        try
                        {
                            pDataName = pDataLayer.DataSourceName as ESRI.ArcGIS.Geodatabase.IDatasetName;
                            //获取DatasetName，必须是要替换的工作空间下的                 
                            ESRI.ArcGIS.Geodatabase.IDatasetName pDsName = GetDatasetName(pWs, pDataName.Name);
                            if (pDsName == null) continue;
                            pDataName = pDataLayer.DataSourceName as ESRI.ArcGIS.Geodatabase.IDatasetName;
                            pDataName.WorkspaceName = pWsName;
                            pDataLayer.Connect(pDsName as ESRI.ArcGIS.esriSystem.IName);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pDataName);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pDsName);
                            //pDataName = pDataLayer.DataSourceName as ESRI.ArcGIS.Geodatabase.IDatasetName;   
                        }
                        catch { }
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pDataLayer);
                    }
                }
            }
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pWsName);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(pMap);
            pMapDoc.Save(true, true);
        }

        /// <summary>
        /// 从工作空间下获取到pFeatureClassName对应的 IDatasetName
        /// </summary>
        /// <param name="pWs"></param>
        /// <param name="pFeatureClassName"></param>
        /// <returns></returns>
        public static ESRI.ArcGIS.Geodatabase.IDatasetName GetDatasetName(ESRI.ArcGIS.Geodatabase.IWorkspace pWs, string pFeatureClassName)
        {
            try
            {
                ESRI.ArcGIS.Geodatabase.IEnumDatasetName pDsName = pWs.get_DatasetNames(ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTAny);
                ESRI.ArcGIS.Geodatabase.IDatasetName pDsSetName = pDsName.Next();
                while (pDsSetName != null)
                {
                    //遍历FeatureDataset       
                    if (pDsSetName.Type == ESRI.ArcGIS.Geodatabase.esriDatasetType.esriDTFeatureDataset)
                    {
                        ESRI.ArcGIS.Geodatabase.IEnumDatasetName pDsFtName = pDsSetName.SubsetNames;
                        ESRI.ArcGIS.Geodatabase.IDatasetName pDsSetName1 = pDsFtName.Next();
                        while (pDsSetName1 != null)
                        {
                            if (pDsSetName1.Name == pFeatureClassName)
                            {
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(pDsName);
                                System.Runtime.InteropServices.Marshal.ReleaseComObject(pDsFtName);
                                return pDsSetName1;
                            }
                            pDsSetName1 = pDsFtName.Next();
                        }
                    }
                    else if (pDsSetName.Name == pFeatureClassName)
                    {
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(pDsName);
                        return pDsSetName;
                    }
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(pDsSetName);
                    pDsSetName = pDsName.Next();
                }
                return null;//pDsSetName;          
            }
            catch (Exception ex)
            { return null; }
        }
        /// <summary>
        /// 将workspace 转换为 IWorkspaceName
        /// </summary>
        /// <param name="pWs"></param>
        /// <returns></returns>
        private static ESRI.ArcGIS.Geodatabase.IWorkspaceName GetWorkspaceName(ESRI.ArcGIS.Geodatabase.IWorkspace pWs)
        {
            try
            {
                ESRI.ArcGIS.Geodatabase.IDataset pDs = pWs as ESRI.ArcGIS.Geodatabase.IDataset;
                return (ESRI.ArcGIS.Geodatabase.IWorkspaceName)pDs.FullName; ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region AE方法：GP工具

        public static ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();

        /// <summary>
        /// AE创建SDE文件
        /// </summary>
        /// <param name="server"></param>
        /// <param name="service"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="sdefile"></param>
        /// <returns></returns>
        public static bool CreatArcSdeFile(string server,string service,string username,string password, string sdefile ,ref string errMsg)
        {
            try
            {                                   
                    ESRI.ArcGIS.DataManagementTools.CreateArcSDEConnectionFile pCreat = new ESRI.ArcGIS.DataManagementTools.CreateArcSDEConnectionFile();
                    pCreat.out_folder_path = System.IO.Path.GetDirectoryName(sdefile);
                    pCreat.out_name = System.IO.Path.GetFileName(sdefile);
                    pCreat.server = server;
                    pCreat.service = "sde:oracle11g:" + service;
                    pCreat.username = username;
                    pCreat.password = password;
                    pCreat.save_username_password = "SAVE_USERNAME";
                    pCreat.account_authentication = "DATABASE_AUTH";
                    gp.Execute(pCreat, null);
                   return true ;
            }
            catch(Exception err)
            {
                errMsg= err.Message;
                return false;
            }
        }


        /// <summary>
        /// 使用AE的GP工具实现图层到图层的转换
        /// </summary>
        /// <param name="sourcePath">源数据路径，shape为全路径。数据库路径以mdb为例：C:\测试\test.mdb\zyxb</param>
        /// <param name="tarPath">源数据路径，shape为全路径。数据库路径以mdb为例：C:\测试\test.mdb\zyxbtar</param>
        /// <param name="msgLog"></param>
        /// <returns></returns>
        public static bool GPFeatToFeat(string sourcePath, string tarPath, string filter ,  out string msgLog)
        {
            msgLog = string.Empty;
            ESRI.ArcGIS.Geoprocessor.Geoprocessor gp = new ESRI.ArcGIS.Geoprocessor.Geoprocessor();
            string out_path = tarPath.Substring(0, tarPath.LastIndexOf('\\'));
            string out_name = tarPath.Substring(tarPath.LastIndexOf('\\') + 1);
            try
            {
                //复制到更新小班图层
                ESRI.ArcGIS.ConversionTools.FeatureClassToFeatureClass pFeatToFeat1 = new ESRI.ArcGIS.ConversionTools.FeatureClassToFeatureClass();
                pFeatToFeat1.in_features = sourcePath;
                pFeatToFeat1.out_path = out_path;  //zyxbFeatClass.Workspace.InnerObject as ESRI.ArcGIS.Geodatabase.IWorkspace;
                pFeatToFeat1.out_name = out_name;
                pFeatToFeat1.where_clause = filter;
                gp.Execute(pFeatToFeat1, null);

                if (!ReturnErrMessage(gp, ref msgLog))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                ReturnErrMessage(gp, ref msgLog);
                return false;
            }
            finally
            {
                gp = null;
            }
            msgLog = "";
            return true;
        }
        /// <summary>
        /// 要素类到要素类
        /// </summary>
        /// <param name="sourceFC"></param>
        /// <param name="tarDatabase"></param>
        /// <param name="filter"></param>
        /// <param name="msgLog"></param>
        /// <returns></returns>
        public static bool GPFeatToFeat(ESRI.ArcGIS.Geodatabase.IFeatureClass sourceFC, string tarDatabase,string filter, out string msgLog)
        {
            msgLog = string.Empty;
            
            try
            {
                ESRI.ArcGIS.ConversionTools.FeatureClassToFeatureClass pFeatToFeat = new ESRI.ArcGIS.ConversionTools.FeatureClassToFeatureClass();
                pFeatToFeat.in_features = sourceFC;
                pFeatToFeat.out_path = tarDatabase;
                pFeatToFeat.out_name = sourceFC.AliasName;
                pFeatToFeat.where_clause = filter;
                gp.Execute(pFeatToFeat, null);
                if (!ReturnErrMessage(gp, ref msgLog))
                {
                    return false;
                }

            }
            catch (Exception)
            {
                ReturnErrMessage(gp, ref msgLog);
                return false;
            }            
                 
            msgLog = "";
            return true; 
        }
        /// <summary>
        /// 追加要素
        /// </summary>
        /// <param name="inputFC"></param>
        /// <param name="outputFC"></param>
        /// <param name="fieldPair"></param>
        /// <param name="msgLog"></param>
        /// <returns></returns>
        public static bool GPAppend(string inputFile, string outputFile, ESRI.ArcGIS.Geodatabase.IFeatureClass inputFC, ESRI.ArcGIS.Geodatabase.IFeatureClass outputFC, string fieldPair, out string msgLog)
        {
            msgLog = string.Empty;

            try
            {
                ESRI.ArcGIS.DataManagementTools.Append pAppend = new ESRI.ArcGIS.DataManagementTools.Append();
                gp.OverwriteOutput = false;
                pAppend.inputs = inputFile;
                pAppend.target = outputFile;
                pAppend.schema_type = "NO_TEST";
                pAppend.field_mapping = GetGPFieldMapping(inputFC, outputFC, fieldPair);
                gp.Execute(pAppend, null);
                if (!ReturnErrMessage(gp, ref msgLog))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                ReturnErrMessage(gp, ref msgLog);
                return false;
            }

            msgLog = "";
            return true;
        }
        /// <summary>
        /// 追加要素
        /// </summary>
        /// <param name="inputFC"></param>
        /// <param name="outputFC"></param>
        /// <param name="fieldPair"></param>
        /// <param name="msgLog"></param>
        /// <returns></returns>
        public static bool GPAppend(ESRI.ArcGIS.Geodatabase.IFeatureClass inputFC, ESRI.ArcGIS.Geodatabase.IFeatureClass outputFC, string fieldPair ,out string msgLog)
        {
            msgLog = string.Empty;
            
            try
            {
                ESRI.ArcGIS.DataManagementTools.Append pAppend = new ESRI.ArcGIS.DataManagementTools.Append();
                gp.OverwriteOutput = false;                
                pAppend.inputs = inputFC;
                pAppend.target = outputFC;
                pAppend.schema_type = "NO_TEST";
                pAppend.field_mapping = GetGPFieldMapping(inputFC, outputFC, fieldPair);
                gp.Execute(pAppend, null);
                if (!ReturnErrMessage(gp, ref msgLog))
                {
                    return false;
                }     
            }
            catch (Exception)
            {
                ReturnErrMessage(gp, ref msgLog);
                return false;
            }
            
            msgLog = "";
            return true;
        }

        /// <summary>
        /// 字段匹配
        /// </summary>
        /// <param name="sourceFeatClass"></param>
        /// <param name="targetFeatClass"></param>
        /// <param name="FieldPair"></param>
        /// <returns></returns>
        public static ESRI.ArcGIS.Geoprocessing.IGPFieldMapping GetGPFieldMapping(ESRI.ArcGIS.Geodatabase.IFeatureClass sourceFeatClass,
ESRI.ArcGIS.Geodatabase.IFeatureClass targetFeatClass, string FieldPair)
        {
            ESRI.ArcGIS.Geodatabase.IDataset sourceDataset = sourceFeatClass as ESRI.ArcGIS.Geodatabase.IDataset;
            ESRI.ArcGIS.esriSystem.IName pName = sourceDataset.FullName;
            ESRI.ArcGIS.Geoprocessing.IGPUtilities gputilities = new ESRI.ArcGIS.Geoprocessing.GPUtilitiesClass();
            ESRI.ArcGIS.Geodatabase.IDETable inputTableA = (ESRI.ArcGIS.Geodatabase.IDETable)gputilities.MakeDataElementFromNameObject(pName);

            ESRI.ArcGIS.esriSystem.IArray inputtables = new ESRI.ArcGIS.esriSystem.ArrayClass();
            inputtables.Add(inputTableA);

            ESRI.ArcGIS.Geoprocessing.IGPFieldMapping pGPFieldMapping = new ESRI.ArcGIS.Geoprocessing.GPFieldMappingClass();
            pGPFieldMapping.Initialize(inputtables, null);

            string[] sFieldPairs = FieldPair.Split(';');
            if (sFieldPairs == null)
                return null;

            foreach (string sFieldPair in sFieldPairs)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(sFieldPair))
                        continue;
                    string[] sourceAndtarget = sFieldPair.Split(',');
                    if (sourceAndtarget == null || sourceAndtarget.Length <= 0)
                        continue;
                    string targetFieldName = sourceAndtarget[0];
                    string sourceFieldName = sourceAndtarget[1];
                    int sourceindex = sourceFeatClass.FindField(sourceFieldName);
                    int targetindex = targetFeatClass.FindField(targetFieldName);
                    if (sourceindex < 0 || targetindex < 0)
                        continue;

                    ESRI.ArcGIS.Geoprocessing.IGPFieldMap trackid = new ESRI.ArcGIS.Geoprocessing.GPFieldMapClass();
                    trackid.OutputField = targetFeatClass.Fields.get_Field(targetFeatClass.FindField(targetFieldName));
                    trackid.MergeRule = ESRI.ArcGIS.Geoprocessing.esriGPFieldMapMergeRule.esriGPFieldMapMergeRuleLast;
                    int fieldmap_index = pGPFieldMapping.FindFieldMap(sourceFieldName);
                    ESRI.ArcGIS.Geoprocessing.IGPFieldMap stfid_fieldmap = pGPFieldMapping.GetFieldMap(fieldmap_index);
                    int field_index = stfid_fieldmap.FindInputField(inputTableA, sourceFieldName);
                    ESRI.ArcGIS.Geodatabase.IField inputField = stfid_fieldmap.GetField(field_index);
                    //if (inputField.Name == "STLLZ") 
                    //{
                    //    ESRI.ArcGIS.Geodatabase.IField field = targetFeatClass.Fields.get_Field(targetFeatClass.FindField(targetFieldName));
                    //}
                    trackid.AddInputField(inputTableA, inputField, -1, -1);
                    pGPFieldMapping.AddFieldMap(trackid);
                }
                catch (Exception ex)
                {

                }

            }

            return pGPFieldMapping;
        }
           

       
        /// <summary>
        /// 获取GP日志
        /// </summary>
        /// <param name="pGeoprocessor"></param>
        /// <param name="strReport"></param>
        /// <returns></returns>
        public static bool ReturnErrMessage(ESRI.ArcGIS.Geoprocessor.Geoprocessor pGeoprocessor, ref string strReport)
        {
            ESRI.ArcGIS.Geodatabase.GPMessage pGPMessage = new ESRI.ArcGIS.Geodatabase.GPMessage();
            ESRI.ArcGIS.Geodatabase.GPMessagesClass pGPMessages = new ESRI.ArcGIS.Geodatabase.GPMessagesClass();
            try
            {
                int iNum = 0;
                for (int i = 0; i < pGeoprocessor.MessageCount; i++)
                {
                    int ii = pGeoprocessor.GetReturnCode(i);
                    if (ii != 0)
                    {
                        iNum = iNum + 1;
                    }
                    if (strReport == "")
                    {
                        strReport = pGeoprocessor.GetMessage(i);
                        if (pGPMessages != null)
                        {
                            pGPMessage.Description = string.Format(strReport);
                            pGPMessages.Add(pGPMessage);
                        }
                    }
                    else
                    {
                        strReport = strReport + "\r\n" + pGeoprocessor.GetMessage(i);
                        if (pGPMessages != null)
                        {
                            pGPMessage.Description = string.Format(strReport);
                            pGPMessages.Add(pGPMessage);

                        }
                    }
                }
                if (iNum > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 创建自定义坐标转换
        /// </summary>
        /// <param name="trancName"></param>
        /// <param name="in_coor_system"></param>
        /// <param name="out_coor_system"></param>
        /// <param name="GEOGTRANString"></param>
        /// <param name="msgLog"></param>
        /// <returns></returns>
        public static bool GPCreateCustomGeoTransformation(string trancName, string in_coor_system , string out_coor_system ,
            string GEOGTRANString  , out string msgLog)
        {
            msgLog = string.Empty;

            try
            {
                ESRI.ArcGIS.DataManagementTools.CreateCustomGeoTransformation pAppend = new ESRI.ArcGIS.DataManagementTools.CreateCustomGeoTransformation();
                gp.OverwriteOutput = false;
                pAppend.geot_name = trancName;
                pAppend.in_coor_system = in_coor_system;
                pAppend.out_coor_system = out_coor_system;
                pAppend.custom_geot = GEOGTRANString;
                gp.Execute(pAppend, null);
                if (!ReturnErrMessage(gp, ref msgLog))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                ReturnErrMessage(gp, ref msgLog);
                return false;
            }

            msgLog = "";
            return true;
        }
        
        /// <summary>
        /// 坐标转换
        /// </summary>
        /// <param name="in_dataset"></param>
        /// <param name="in_coor_system"></param>
        /// <param name="out_dataset"></param>
        /// <param name="out_coor_system"></param>
        /// <param name="CustomGeoTransformation"></param>
        /// <param name="msgLog"></param>
        /// <returns></returns>
        public static bool GPGeoTransformation(string in_dataset, string in_coor_system, string out_dataset , string out_coor_system,
            string CustomGeoTransformation, out string msgLog)
        {
            msgLog = string.Empty;

            try
            {
                ESRI.ArcGIS.DataManagementTools.Project pAppend = new ESRI.ArcGIS.DataManagementTools.Project();
                gp.OverwriteOutput = false;
                pAppend.in_dataset = in_dataset;
                pAppend.in_coor_system = in_coor_system;
                pAppend.out_dataset = out_dataset;
                pAppend.out_coor_system = out_coor_system;
                if( !string.IsNullOrEmpty( CustomGeoTransformation ))
                   pAppend.transform_method = CustomGeoTransformation;
                gp.Execute(pAppend, null);
                if (!ReturnErrMessage(gp, ref msgLog))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                ReturnErrMessage(gp, ref msgLog);
                return false;
            }

            msgLog = "";
            return true;
        }
    }
}

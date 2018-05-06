using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CoordinateTransformation
{
   public  class CoordTrancParamClass
    {
        public CoordTrancParamClass()
        { }
        public CoordTrancParamClass(DataRow row )
        {
            Type t = this.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                string datatype = prop.PropertyType.FullName;
                if (datatype == "System.Int32")
                {
                    int iv;
                    if (row[prop.Name] != null && int.TryParse(row[prop.Name].ToString(), out iv))
                    {
                        prop.SetValue(this, iv, null);
                    }
                    else
                        prop.SetValue(this, 0, null);
                       
                }//datatype == ""
                else if (datatype == "System.Double")
                {
                    double dv;
                    if (row[prop.Name] != null && double.TryParse(row[prop.Name].ToString(), out dv))
                    {
                        prop.SetValue(this, dv, null);
                    }
                    else
                        prop.SetValue(this, 0, null);
                }
                else if (datatype == "System.Boolean")
                {
                    bool bv;
                    if (row[prop.Name] != null && Boolean.TryParse(row[prop.Name].ToString(), out bv))
                    {
                        prop.SetValue(this, bv, null);
                    }
                    else
                        prop.SetValue(this, false, null);
                }
                else  if (row[prop.Name] != null )
                    prop.SetValue(this, row[prop.Name], null);
                
            }

        }
        public int ID { get; set; }
        public string CoorTranName { get; set; }
        public int WKID { get; set; }
        public string AreaofUse { get; set; }
        public string Method { get; set; }
        public double Accuracy { get; set; }
        public double MaximumLatitude { get; set; }
        public double MinimumLatitude { get; set; }
        public double MaximumLongitude { get; set; }
        public double MinimumLongitude { get; set; }

        public double DX { get; set; }
        public double DY { get; set; }
        public double DZ { get; set; }
        public double DS { get; set; }

        public double RX { get; set; }
        public double RY { get; set; }
        public double RZ { get; set; }

        public double X0 { get; set; }
        public double Y0 { get; set; }
        public double Z0 { get; set; }
        /// <summary>
        /// 是否自定义转换参数
        /// </summary>
        public bool Defined { get; set; }
        public string SOU_PRJ { get; set; }
        public string TAR_PRJ { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public string PARAM_TYPE { get; set; }
        /// <summary>
        /// 所属国家
        /// </summary>
        public string COUNTRYNAME { get; set; }

        public int SOU_WKID { get; set; }
        public int TAR_WKID { get; set; }
        public override string ToString()
        {
            return CoorTranName;
        }
        
        public DataRow ToDatarow()
        {
            DataTable dt = new DataTable("CoordTrancParam");
            
            Type t = this.GetType();
            System.Reflection.PropertyInfo[] props = t.GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                string datatype = prop.PropertyType.FullName;
                DataColumn idColumn = new DataColumn();
                idColumn.DataType = System.Type.GetType(datatype);
                idColumn.ColumnName = prop.Name;
                dt.Columns.Add(idColumn);
            }

            DataRow datarow = dt.NewRow();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                string datatype = prop.PropertyType.FullName;
                if (datatype == "System.Int32" )
                { 
                    int iv;
                    if (!int.TryParse(prop.GetValue(this, null).ToString(), out iv))
                        continue;
                    if (int.MinValue.Equals(iv) || int.MaxValue.Equals(iv))
                        continue;
                    datarow.SetField(prop.Name, iv);
                }//datatype == ""
                else if (datatype == "System.Double")
                {
                    double dv;
                    if (!double.TryParse(prop.GetValue(this, null).ToString(), out dv))
                        continue;
                    if (double.MinValue.Equals(dv) || double.MaxValue.Equals(dv))
                        continue;
                    datarow.SetField(prop.Name, dv);
                }
                else
                    datarow.SetField(prop.Name, prop.GetValue(this, null));
            }
            return datarow;
        }
    }
}

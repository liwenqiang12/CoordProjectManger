using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ESRI.ArcGIS.Geodatabase;
using System.Windows.Forms;
using System.Data;

namespace CoordinateTransformation
{
   public class CommonClass
   {
        ////国家名称绑定值
        //    countryNameTable = AccessHelper.ExecuteDataTable("select NAME from CountryName", null);
       private static DataTable coorSystemTable;
       public static DataTable CoorSystemTable
       {
           get
           {
               if (coorSystemTable == null)
               {
                   coorSystemTable = AccessHelper.ExecuteDataTable("select * from CoordinateSystem order by ID", null);
               }
               return coorSystemTable;
           }
       }
       public static DataTable GetCoorSystemTable(string filter)
       {
           DataTable 
               coorSystemtb = AccessHelper.ExecuteDataTable("select * from CoordinateSystem where " +filter + " order by ID", null);
           return coorSystemtb;
       }
       private static DataTable countryNameTable;
       public static DataTable CountryNameTable
       {
           get
           {
               if (countryNameTable == null)
               {
                   countryNameTable = AccessHelper.ExecuteDataTable("select * from CountryName order by ID", null);
               }
               return countryNameTable;
           }
       }
       private static DataTable _itrfTable;
       public static DataTable ITRFTable
       {
           get
           {
               if (_itrfTable == null)
               {
                   _itrfTable = AccessHelper.ExecuteDataTable("select * from T_ITRF order by ID", null);
               }
               return _itrfTable;
           }
       }
       
      
   }
}

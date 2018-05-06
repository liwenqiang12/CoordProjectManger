using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoordinateTransformation
{
    class CoordProjClass
    {
        public CoordProjClass()
        { }
        public int WKID { get; set; }
        public string TYPE { get; set; }
        public string GEOGCS { get; set; }
        public string DATUM { get; set; }
        public string SPHEROID { get; set; }
        public string PRIMEM { get; set; }
        public string UNIT { get; set; }
        public string NAME { get; set; }
        /// <summary>
        /// proj定义
        /// </summary>
        public string DEFINITION { get; set; }
        public override string ToString()
        {
            return NAME;
        }
    }
    enum ParamTypeEnum
    {
        PV = 1,//Position Vector  位置矢量法  7参数
        CF = 2//Coordinate Frame 基于地心的七参数转换法

    }
}

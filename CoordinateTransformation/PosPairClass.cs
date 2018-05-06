using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoordinateTransformation
{
    class PosPairClass
    {
        public PosPairClass()
        { }
        public int ID { get; set; }
        public int WKID { get; set; }
        public string TRUNC_NAME { get; set; }
        public int I_XH { get; set; }
        public double SOU_X { get; set; }
        public double SOU_Y { get; set; }
        public double SOU_Z { get; set; }
        public double TAR_X { get; set; }
        public double TAR_Y { get; set; }
        public double TAR_Z { get; set; }
        //public override string ToString()
        //{
        //    return NAME;
        //}
    }
}

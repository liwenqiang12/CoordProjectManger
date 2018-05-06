using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoordinateTransformation
{
    class CountryClass
    {
        public CountryClass()
        { }
        public string NAME { get; set; }
        public string ENNAME { get; set; }
        public string CONTINENT { get; set; }
        public string REGION { get; set; }
        public override string ToString()
        {
            return NAME;
        }
    }
}

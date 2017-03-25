using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openlayer_test.TESTDB
{
    class Town
    {
        public int TownID { get; set; }
        public int CountyID { get; set; }
        public County County { get; set; }
        public string TownName { get; set; }
    }
}

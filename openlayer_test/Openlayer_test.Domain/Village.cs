using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openlayer_test.TESTDB
{
    class Village
    {
        public int VillageID { get; set; }
        public int TownID { get; set; }
        public Town Town { get; set; }
        public string VillageName { get; set; }
    }
}

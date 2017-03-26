using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openlayer_test.TESTDB
{
    public class Table1:DBObject
    {
        public int Table1ID { get; set; }
        public int PlanYear { get; set; }
        public string SUBBASINNA { get; set; }
        public int VillageID { get; set; }
        public Village Village { get; set; }
        public string DisName { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
    }
}

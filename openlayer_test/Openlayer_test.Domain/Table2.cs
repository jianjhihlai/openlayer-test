using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openlayer_test.TESTDB
{
    public class Table2:DBObject
    {
        public int Table2ID { get; set; }
        public string RawFile { get; set; }
        public string EnviFile { get; set; }
        public string TileFile { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double LeftGeo { get; set; }
        public double RightGeo { get; set; }
        public double TopGeo { get; set; }
        public double BottomGeo { get; set; }
        public double Resolution { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string DisName { get; set; }
        public int VillageID { get; set; }
        public Village Village { get; set; }
        public string Basin { get; set; }
        public string Subbasinna { get; set; }
    }
}

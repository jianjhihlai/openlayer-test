using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Openlayer_test.TESTDB.EF;
using Openlayer_test.TESTDB;
using ImportToSQLDB;

namespace sqldbimport
{
    class Program
    {   
        static void Main(string[] args)
        {
            ILogHandler logger = new LogFile();
            logger.LogDir = "log";
            logger.Prefix = DateTime.Today.ToString("yyyyMMdd");
            logger.Subfix = "";
            logger.Ext = ".log";
            if (!System.IO.File.Exists(logger.LogDir))
            {
                System.IO.Directory.CreateDirectory(logger.LogDir);
            }

            if (args != null && args.Length > 1)
            {
                string message = "Start importing";
                Console.WriteLine(message);
                logger.Log(message);
                //印出傳入的參數
                try
                {
                    DBImporter importer = new DBImporter();
                    importer.ImportToDB(args[1].ToString(), args[0].ToString());
                }
                catch (Exception ex)
                {
                    message = "importing halted: " + ex.Message.Replace(Environment.NewLine, " ");
                    Console.WriteLine(message);
                    logger.Log(message);
                }
                message = "import end";
                Console.WriteLine(message);
                logger.Log(message);
            }
            else
            {
                logger.Log("Importing failed because of wrong parameters");
            }

            // Console.ReadKey();
        }

        static void test_ImportTable2()
        {
            DBImporter importer = new DBImporter();
            importer.ImportToDB("Table2", "Table2.csv");
        }

        static void test_ImportTable1()
        {
            DBImporter importer = new DBImporter();
            importer.ImportToDB("Table1", "Table1.csv");
        }

        static void test_SingleAddTable2()
        {
            var table2 = new Openlayer_test.TESTDB.Table2();
            table2.RawFile = @"H:\RAW\RSImage\UAV\Ortho\GIS.FCU_UAV空拍照片-20170223\GIS.FCU_UAV空拍照片\2013\信義霍薩溪\正射\P-hs-20131107-01O.tif";
            table2.EnviFile = @" H:\ENVI\RSImage\UAV\Ortho\20131107_120853299_023501566_13_000_RSImage_UAV_Ortho";
            table2.TileFile = @"http://140.116.249.186/RSImage\UAV\Ortho\20131107_120853299_023501566_13_000_RSImage_UAV_Ortho";
            table2.Lon = 120.853299;
            table2.Lat = 23.501566;
            table2.LeftGeo = 120.8252307;
            table2.RightGeo = 120.8813556;
            table2.TopGeo = 23.53052089;
            table2.BottomGeo = 23.47261206;
            table2.Resolution = 0.5;
            table2.Year = 2013;
            table2.Month = 11;
            table2.Day = 7;
            table2.DisName = "信義霍薩溪";
            table2.Village = new Village();
            table2.Village.VillageName = "神木村";
            table2.Village.Town = new Town();
            table2.Village.Town.TownName = "信義鄉";
            table2.Village.Town.County = new County();
            table2.Village.Town.County.CountyName = "南投縣";
            table2.Basin = " 濁水溪";
            table2.Subbasinna = "鹿林";
            
            var table2_model = new Table2Repository();
            var id = table2_model.Create(table2);
            if (id > 0)
            {
                Console.WriteLine("成功寫入Table2，寫入的ID為：" + id.ToString());
            }
            else
            {
                Console.WriteLine("寫入失敗");
            }
        }

        static void test_SingleAddTable1()
        {
            var table1 = new Openlayer_test.TESTDB.Table1();
            table1.PlanYear = 106;
            table1.SUBBASINNA = "那羅溪";
            table1.Village = new Village();
            table1.Village.VillageName = "義興村";
            table1.Village.Town = new Town();
            table1.Village.Town.TownName = "尖石鄉";
            table1.Village.Town.County = new County();
            table1.Village.Town.County.CountyName = "新竹縣";
            table1.DisName = "新竹縣尖石鄉義興村";
            table1.X = 267041.238402;
            table1.Y = 2732007.49142;
            table1.Lon = 121.168411944;
            table1.Lat = 24.6950106526;
            var table1_model = new Table1Repository();
            var id = table1_model.Create(table1);
            if (id > 0)
            {
                Console.WriteLine("成功寫入Table1，寫入的ID為：" + id.ToString());
            }
            else
            {
                Console.WriteLine("寫入失敗");
            }
        }

        static void test_SingleAddVillage()
        {
            var village_model = new VillageRepository();
            var village = new Village();
            village.VillageName = "安正里";
            var town = new Town();
            town.TownName = "麻豆區";
            var county = new County();
            county.CountyName = "台南市";
            town.County = county;
            village.Town = town;
            var id = village_model.Create(village);
            if (id > 0)
            {
                Console.WriteLine("成功寫入Village，寫入的ID為：" + id.ToString());
            }
            else
            {
                Console.WriteLine("寫入失敗");
            }
        }
    }
}

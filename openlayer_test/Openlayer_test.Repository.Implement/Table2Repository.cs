using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class Table2Repository:ITable2Repository
    {

        public TESTDB.Table2 GetOne(int item_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TESTDB.Table2> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(TESTDB.Table2 item)
        {
            int id = 0;
            TESTDBEntities dbContext = new TESTDBEntities();
            try
            {
                var ef_item = Table2Repository.EFMapper(item);
                if (ef_item != null)
                {
                    dbContext.Table2.AddObject(ef_item);
                    dbContext.SaveChanges();
                    id = ef_item.Table2ID;
                }
            }
            catch
            {
            }
            finally
            {
                dbContext.Dispose();
            }
            return id;
        }

        public int Update(int item_id, TESTDB.Table2 item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int item_id)
        {
            throw new NotImplementedException();
        }

        public int BatchCreate(IEnumerable<TESTDB.Table2> item_list)
        {
            throw new NotImplementedException();
        }

        public int BatchUpdate(IEnumerable<TESTDB.Table2> item_list)
        {
            throw new NotImplementedException();
        }
                
        public static TESTDB.Table2 EFMapper(TESTDB.EF.Table2 ef_item)
        {
            var item = new TESTDB.Table2();
            item.Table2ID = ef_item.Table2ID;
            item.RawFile = ef_item.RawFile;
            item.EnviFile = ef_item.EnviFile;
            item.TileFile = ef_item.TileFile;
            item.Lon = ef_item.Lon;
            item.Lat = ef_item.Lat;
            item.LeftGeo = ef_item.LeftGeo;
            item.RightGeo = ef_item.RightGeo;
            item.TopGeo = ef_item.TopGeo;
            item.BottomGeo = ef_item.BottomGeo;
            item.Resolution = ef_item.Resolution;
            item.Year = ef_item.Year;
            item.Month = ef_item.Month;
            item.Day = ef_item.Day;
            item.DisName = ef_item.DisName;
            item.VillageID = ef_item.VillageID;
            if (ef_item.Basic_Village != null)
            {
                item.Village = VillageRepository.EFMapper(ef_item.Basic_Village);
            }
            item.Basin = ef_item.Basin;
            item.Subbasinna = ef_item.Subbasinna;
            
            return item;
        }

        public static TESTDB.EF.Table2 EFMapper(TESTDB.Table2 item)
        {
            var ef_item = new TESTDB.EF.Table2();
            ef_item.Table2ID = item.Table2ID;
            ef_item.RawFile = item.RawFile;
            ef_item.EnviFile = item.EnviFile;
            ef_item.TileFile = item.TileFile;
            ef_item.Lon = item.Lon;
            ef_item.Lat = item.Lat;
            ef_item.LeftGeo = item.LeftGeo;
            ef_item.RightGeo = item.RightGeo;
            ef_item.TopGeo = item.TopGeo;
            ef_item.BottomGeo = item.BottomGeo;
            ef_item.Resolution = item.Resolution;
            ef_item.Year = item.Year;
            ef_item.Month = item.Month;
            ef_item.Day = item.Day;
            ef_item.DisName = item.DisName;
            if (item.VillageID <= 0 && item.Village != null)
            {
                var village_model = new VillageRepository();
                item.VillageID = village_model.Create(item.Village);
            }
            ef_item.VillageID = item.VillageID;
            ef_item.Basin = item.Basin;
            ef_item.Subbasinna = item.Subbasinna;

            return ef_item;

        }
    }
}

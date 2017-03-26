using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.Repository.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class TownRepository:ITownRepository
    {
        public Town GetOne(int item_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Town> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(Town item)
        {
            int id = 0;
            TESTDBEntities dbContext = new TESTDBEntities();
            try
            {
                var ef_item = TownRepository.EFMapper(item);
                if (ef_item != null)
                {
                    dbContext.Basic_Town.AddObject(ef_item);
                    dbContext.SaveChanges();
                    id = ef_item.TownID;
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

        public int Update(int item_id, Town item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int item_id)
        {
            throw new NotImplementedException();
        }

        public int BatchCreate(IEnumerable<Town> item_list)
        {
            throw new NotImplementedException();
        }

        public int BatchUpdate(IEnumerable<Town> item_list)
        {
            throw new NotImplementedException();
        }

        public static Town EFMapper(Basic_Town ef_item)
        {
            var item = new Town();
            item.TownID = ef_item.TownID;
            item.TownName = ef_item.TownName;
            item.CountyID = ef_item.CountyID;
            if (ef_item.Basic_County != null)
            {
                item.County = CountyRepository.EFMapper(ef_item.Basic_County);
            }
            return item;
        }

        public static Basic_Town EFMapper(Town item)
        {
            var ef_item = new Basic_Town();
            ef_item.TownID = item.TownID;
            ef_item.TownName = item.TownName;
            if (item.CountyID <= 0 && item.County != null)
            {
                var county_model = new CountyRepository();
                item.CountyID = county_model.Create(item.County);
            }
            ef_item.CountyID = item.CountyID;
            return ef_item;
        }
    }
}

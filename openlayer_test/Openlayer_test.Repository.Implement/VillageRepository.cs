using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.Repository.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class VillageRepository:IVillageRepository
    {
        public Village GetOne(int item_id)
        {
            var item = new Village();
            using (var dbContext = new TESTDBEntities())
            {
                var ef_item = dbContext.Basic_Village.FirstOrDefault(obj => obj.VillageID == item_id);
                if (ef_item != null)
                {
                    item = VillageRepository.EFMapper(ef_item);
                }
            }
            return item;
        }

        public IEnumerable<Village> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Village> GetAll(int? town_id)
        {
            var item_list = new List<Village>();
            using (var dbContext = new TESTDBEntities())
            {
                List<Basic_Village> ef_list;
                if (town_id.HasValue)
                {
                    ef_list = dbContext.Basic_Village.Where(obj => obj.TownID == town_id.Value).ToList();
                }
                else
                {
                    ef_list = (from village in dbContext.Basic_Village select village).ToList();
                }
                if (ef_list != null)
                {
                    item_list = VillageRepository.BatchEFMapper(ef_list);
                }

            }
            return item_list;
        }

        public int Create(Village item)
        {
            int id = 0;
            TESTDBEntities dbContext = new TESTDBEntities();
            try
            {
                var ef_item = VillageRepository.EFMapper(item);
                if (ef_item != null)
                {
                    dbContext.Basic_Village.AddObject(ef_item);
                    dbContext.SaveChanges();
                    id = ef_item.VillageID;
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

        public int Update(int item_id, Village item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int item_id)
        {
            throw new NotImplementedException();
        }

        public int BatchCreate(IEnumerable<Village> item_list)
        {
            throw new NotImplementedException();
        }

        public int BatchUpdate(IEnumerable<Village> item_list)
        {
            throw new NotImplementedException();
        }

        public static List<Village> BatchEFMapper(List<Basic_Village> ef_list)
        {
            var item_list = new List<Village>();
            foreach (Basic_Village ef_item in ef_list)
            {
                item_list.Add(VillageRepository.EFMapper(ef_item));
            }
            return item_list;
        }

        public static Village EFMapper(Basic_Village ef_item)
        {
            var item = new Village();
            item.VillageID = ef_item.VillageID;
            item.VillageName = ef_item.VillageName;
            item.TownID = ef_item.TownID;
            if (ef_item.Basic_Town != null)
            {
                item.Town = TownRepository.EFMapper(ef_item.Basic_Town);
            }
            return item;
        }

        public static Basic_Village EFMapper(Village item)
        {
            var ef_item = new Basic_Village();
            ef_item.VillageID = item.VillageID;
            ef_item.VillageName = item.VillageName;
            if (item.TownID <= 0 && item.Town != null)
            {
                var town_model = new TownRepository();
                item.TownID = town_model.Create(item.Town);
            }
            ef_item.TownID = item.TownID;
            return ef_item;
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class Table1Repository:ITable1Repository
    {

        public TESTDB.Table1 GetOne(int item_id)
        {
            var item = new TESTDB.Table1();
            using (var dbContext = new TESTDBEntities())
            {
                var ef_item = dbContext.Table1.FirstOrDefault(obj => obj.Table1ID == item_id);
                if (ef_item != null)
                {
                    item = Table1Repository.EFMapper(ef_item);
                }
            }
            return item;
        }

        public IEnumerable<TESTDB.Table1> GetAll()
        {
            var item_list = new List<TESTDB.Table1>();
            using (var dbContext = new TESTDBEntities())
            {
                var ef_list = dbContext.Table1.ToList();
                foreach (TESTDB.EF.Table1 ef_item in ef_list)
                {
                    item_list.Add(Table1Repository.EFMapper(ef_item));
                }
            }
            return item_list;
        }

        public int Create(TESTDB.Table1 item)
        {
            int id = 0;
            TESTDBEntities dbContext = new TESTDBEntities();
            try
            {
                var ef_item = Table1Repository.EFMapper(item);
                if (ef_item != null)
                {
                    dbContext.Table1.AddObject(ef_item);
                    dbContext.SaveChanges();
                    id = ef_item.Table1ID;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContext.Dispose();
            }
            return id;
        }

        public int Update(TESTDB.Table1 item)
        {
            int id = 0;
            TESTDBEntities dbContext = new TESTDBEntities();
            try
            {
                var ef_item = dbContext.Table1.FirstOrDefault(obj => obj.Table1ID == item.Table1ID);
                if (ef_item != null)
                {
                    Table1Repository.EFMapper(item, ef_item);

                    dbContext.SaveChanges();
                    id = ef_item.Table1ID;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                dbContext.Dispose();
            }
            return id;
        }

        public int Delete(int item_id)
        {
            var ef_item = new TESTDB.EF.Table1 { Table1ID = item_id };
            using (TESTDBEntities dbContext = new TESTDBEntities())
            {
                dbContext.Table1.Attach(ef_item);
                dbContext.Table1.DeleteObject(ef_item);
                dbContext.SaveChanges();
            }
            return item_id;
        }

        public int BatchCreate(IEnumerable<TESTDB.Table1> item_list)
        {
            throw new NotImplementedException();
        }

        public int BatchUpdate(IEnumerable<TESTDB.Table1> item_list)
        {
            throw new NotImplementedException();
        }

        public static void EFMapper(TESTDB.Table1 item, TESTDB.EF.Table1 ef_item)
        {
            ef_item.Table1ID = item.Table1ID;
            ef_item.PlanYear = item.PlanYear;
            ef_item.SUBBASINNA = item.SUBBASINNA;
            
            ef_item.VillageID = item.VillageID;
            ef_item.DisName = item.DisName;
            ef_item.X = item.X;
            ef_item.Y = item.Y;
            ef_item.Lon = item.Lon;
            ef_item.Lat = item.Lat;
        }
                
        public static TESTDB.Table1 EFMapper(TESTDB.EF.Table1 ef_item)
        {
            var item = new TESTDB.Table1();
            item.Table1ID = ef_item.Table1ID;
            item.PlanYear = ef_item.PlanYear;
            item.SUBBASINNA = ef_item.SUBBASINNA;
            item.VillageID = ef_item.VillageID;
            if (ef_item.Basic_Village != null)
            {
                item.Village = VillageRepository.EFMapper(ef_item.Basic_Village);
            }
            item.DisName = ef_item.DisName;
            item.X = ef_item.X;
            item.Y = ef_item.Y;
            item.Lon = ef_item.Lon;
            item.Lat = ef_item.Lat;
            return item;
        }

        public static TESTDB.EF.Table1 EFMapper(TESTDB.Table1 item)
        {
            var ef_item = new TESTDB.EF.Table1();
            ef_item.Table1ID = item.Table1ID;
            ef_item.PlanYear = item.PlanYear;
            ef_item.SUBBASINNA = item.SUBBASINNA;
            if (item.VillageID <= 0 && item.Village != null)
            {
                var village_model = new VillageRepository();
                item.VillageID = village_model.Create(item.Village);
            }
            ef_item.VillageID = item.VillageID;
            ef_item.DisName = item.DisName;
            ef_item.X = item.X;
            ef_item.Y = item.Y;
            ef_item.Lon = item.Lon;
            ef_item.Lat = item.Lat;
            return ef_item;

        }
    }
}

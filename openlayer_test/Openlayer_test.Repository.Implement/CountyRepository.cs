using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class CountyRepository:ICountyRepository
    {
        protected List<Basic_County> _county_list;


        public County GetOne(int item_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<County> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(County item)
        {
            int id = 0;
            TESTDBEntities dbContext = new TESTDBEntities();
            try
            {
                var ef_item = CountyRepository.EFMapper(item);

                if (_county_list == null)
                {
                    _county_list = (from c in dbContext.Basic_County select c).ToList();
                }
                var item_exist = _county_list.FirstOrDefault(c => c.CountyName.Equals(item.CountyName));

                if (item_exist == null)
                {
                    dbContext.Basic_County.AddObject(ef_item);
                    dbContext.SaveChanges();
                    id = item.CountyID = ef_item.CountyID;
                    _county_list.Add(ef_item);
                }
                else
                {
                    id = item.CountyID = item_exist.CountyID;
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

        public int Update(int item_id, County item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int item_id)
        {
            throw new NotImplementedException();
        }

        public int BatchCreate(IEnumerable<County> item_list)
        {
            throw new NotImplementedException();
        }

        public int BatchUpdate(IEnumerable<County> item_list)
        {
            throw new NotImplementedException();
        }

        public static County EFMapper(Basic_County ef_item)
        {
            var item = new County();
            item.CountyID = ef_item.CountyID;
            item.CountyName = ef_item.CountyName;
            return item;
        }

        public static Basic_County EFMapper(County item)
        {
            var ef_item = new Basic_County();
            ef_item.CountyID = item.CountyID;
            ef_item.CountyName = item.CountyName;
            return ef_item;
        }
    }
}

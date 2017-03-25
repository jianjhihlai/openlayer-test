using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.Repository.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class CountyRepository:ICountyRepository
    {

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
            throw new NotImplementedException();
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
    }
}

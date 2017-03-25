using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.Repository.Interface;

namespace Openlayer_test.TESTDB.EF
{
    class TownRepository:ITownRepository
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
            throw new NotImplementedException();
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
    }
}

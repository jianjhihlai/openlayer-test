using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.Repository.Interface;

namespace Openlayer_test.TESTDB.EF
{
    class VillageRepository:IVillageRepository
    {
        public Village GetOne(int item_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Village> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(Village item)
        {
            throw new NotImplementedException();
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
    }
}

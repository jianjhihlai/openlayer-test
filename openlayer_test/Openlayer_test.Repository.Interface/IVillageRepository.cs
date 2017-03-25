using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;

namespace Openlayer_test.Repository.Interface
{
    public interface IVillageRepository
    {
        Village GetOne(int item_id);
        IEnumerable<Village> GetAll();
        int Create(Village item);
        int Update(int item_id, Village item);
        int Delete(int item_id);
        int BatchCreate(IEnumerable<Village> item_list);
        int BatchUpdate(IEnumerable<Village> item_list);
    }
}

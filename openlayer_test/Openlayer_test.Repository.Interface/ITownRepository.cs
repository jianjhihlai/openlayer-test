using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;

namespace Openlayer_test.TESTDB.Interface
{
    public interface ITownRepository
    {
        Town GetOne(int item_id);
        IEnumerable<Town> GetAll();
        int Create(Town item);
        int Update(int item_id, Town item);
        int Delete(int item_id);
        int BatchCreate(IEnumerable<Town> item_list);
        int BatchUpdate(IEnumerable<Town> item_list);
    }
}

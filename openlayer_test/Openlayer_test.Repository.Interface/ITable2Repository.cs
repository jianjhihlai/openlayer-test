using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openlayer_test.TESTDB.Interface
{
    public interface ITable2Repository
    {
        Table2 GetOne(int item_id);
        IEnumerable<Table2> GetAll();
        int Create(Table2 item);
        int Update(int item_id, Table2 item);
        int Delete(int item_id);
        int BatchCreate(IEnumerable<Table2> item_list);
        int BatchUpdate(IEnumerable<Table2> item_list);
    }
}

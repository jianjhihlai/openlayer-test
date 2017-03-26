using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Openlayer_test.TESTDB.Interface
{
    public interface ITable1Repository
    {
        Table1 GetOne(int item_id);
        IEnumerable<Table1> GetAll();
        int Create(Table1 item);
        int Update(int item_id, Table1 item);
        int Delete(int item_id);
        int BatchCreate(IEnumerable<Table1> item_list);
        int BatchUpdate(IEnumerable<Table1> item_list);
    }
}

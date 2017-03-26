using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;

namespace Openlayer_test.TESTDB.Interface
{
    public interface ICountyRepository
    {
        County GetOne(int item_id);
        IEnumerable<County> GetAll();
        int Create(County item);
        int Update(int item_id, County item);
        int Delete(int item_id);
        int BatchCreate(IEnumerable<County> item_list);
        int BatchUpdate(IEnumerable<County> item_list);
    }
}

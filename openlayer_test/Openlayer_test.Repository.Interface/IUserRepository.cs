using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;

namespace Openlayer_test.TESTDB.Interface
{
    public interface IUserRepository
    {
        User GetOne(int item_id);
        User QueryOne(string item_no);
        IEnumerable<User> GetAll();
        int Create(User item);
        int Update(int item_id, User item);
        int Delete(int item_id);
        int BatchCreate(IEnumerable<User> item_list);
        int BatchUpdate(IEnumerable<User> item_list);
    }
}

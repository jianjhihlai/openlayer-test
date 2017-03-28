using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;

namespace Openlayer_test.TESTDB.EF
{
    public class UserRepository : IUserRepository
    {
        public TESTDB.User GetOne(int item_id)
        {
            throw new NotImplementedException();
        }

        public TESTDB.User QueryOne(string item_no)
        {
            var item = new TESTDB.User();
            using (var dbContext = new TESTDBEntities())
            {
                var ef_item = dbContext.User.FirstOrDefault(obj => obj.Account == item_no && obj.IsEnable);
                if (ef_item != null)
                {
                    item = UserRepository.EFMapper(ef_item);
                }
            }
            return item;
        }

        public IEnumerable<TESTDB.User> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create(TESTDB.User item)
        {
            throw new NotImplementedException();
        }

        public int Update(int item_id, TESTDB.User item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int item_id)
        {
            throw new NotImplementedException();
        }

        public int BatchCreate(IEnumerable<TESTDB.User> item_list)
        {
            throw new NotImplementedException();
        }

        public int BatchUpdate(IEnumerable<TESTDB.User> item_list)
        {
            throw new NotImplementedException();
        }

        public static TESTDB.User EFMapper(TESTDB.EF.User ef_item)
        {
            var item = new TESTDB.User();
            item.ID = ef_item.ID;
            item.Account = ef_item.Account;
            item.Password = ef_item.Password;
            item.Name = ef_item.Name;
            item.Email = ef_item.Email;
            item.IsEnable = ef_item.IsEnable;
            item.CreateBy = ef_item.CreateBy;
            item.CreateOn = ef_item.CreateOn;
            item.UpdateBy = ef_item.UpdateBy;
            item.UpdateOn = ef_item.UpdateOn;
            return item;
        }

        public static TESTDB.EF.User EFMapper(TESTDB.User item)
        {
            var ef_item = new TESTDB.EF.User();
            ef_item.ID = item.ID;
            ef_item.Account = item.Account;
            ef_item.Password = item.Password;
            ef_item.Name = item.Name;
            ef_item.Email = item.Email;
            ef_item.IsEnable = item.IsEnable;
            ef_item.CreateBy = item.CreateBy;
            ef_item.CreateOn = item.CreateOn;
            ef_item.UpdateBy = item.UpdateBy;
            ef_item.UpdateOn = item.UpdateOn;
            return ef_item;
        }
    }
}

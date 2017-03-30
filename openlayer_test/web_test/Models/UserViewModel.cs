using System;
using System.Data.Entity;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.Interface;
using Openlayer_test.TESTDB.EF;
using System.Web.Security;

namespace web_test.Models
{
    public class UserViewModel : DbContext
    {
        // 您可以將自訂程式碼新增到這個檔案。變更不會遭到覆寫。
        // 
        // 如果您要 Entity Framework 每次在您變更模型結構描述時
        // 自動卸除再重新產生資料庫，請將下列
        // 程式碼新增到 Global.asax 檔案的 Application_Start 方法中。
        // 注意: 這將隨著每次模型變更而損毀並重新建立您的資料庫。
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<web_test.Models.UserViewModel>());

        IUserRepository _db;

        public UserViewModel() : base("name=UserViewModel")
        {
            _db = new UserRepository();
        }

        public DbSet<Openlayer_test.TESTDB.User> Users { get; set; }

        public int AddUser(Openlayer_test.TESTDB.User user)
        {
            user.Password = CryptographyPassword(user.Password, "test");
            user.IsEnable = true;
            user.CreateBy = 1;
            user.CreateOn = DateTime.Now;
            int id = _db.Create(user);
            return id;
        }

        protected string CryptographyPassword(string password, string salt)
        {

            string cryptographyPassword =

                FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "sha1");



            return cryptographyPassword;

        }
    }
}

using System.Data.Entity;
using Openlayer_test.TESTDB;

namespace web_test.Models
{
    public class Table2Context : DbContext
    {
        // 您可以將自訂程式碼新增到這個檔案。變更不會遭到覆寫。
        // 
        // 如果您要 Entity Framework 每次在您變更模型結構描述時
        // 自動卸除再重新產生資料庫，請將下列
        // 程式碼新增到 Global.asax 檔案的 Application_Start 方法中。
        // 注意: 這將隨著每次模型變更而損毀並重新建立您的資料庫。
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<web_test.Models.Table2Context>());

        public Table2Context() : base("name=Table2Context")
        {
        }

        public DbSet<Table2> Table2 { get; set; }

        public DbSet<Village> Villages { get; set; }
    }
}

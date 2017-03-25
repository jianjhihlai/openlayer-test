using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ImportToSQLDB
{
    public class DBImporter
    {
        ImporterFactory _factory;
        SqlConnection _conn;
        public DBImporter(ImporterFactory factory, string connection_string)
        {
            _factory = factory;
            _conn = new SqlConnection(connection_string);
        }

        public bool ImportToDB(string type, string csv_file)
        {
            bool is_success = true;
            ITableImporter importer = _factory.GetImporter(type);
            DataTable data = importer.ParseCSVToDataTable(csv_file);
            importer.ImportExecute(data);
            return is_success;
        }
    }
}

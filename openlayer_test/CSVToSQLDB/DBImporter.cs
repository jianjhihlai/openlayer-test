using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Openlayer_test.TESTDB;

namespace ImportToSQLDB
{
    public class DBImporter
    {

        public bool ImportToDB(string type, string file_path)
        {
            bool is_success = true;
            var parser = new FileParser(file_path);
            
            if (type == "Table1")
            {
                Table1Importer importer = new Table1Importer();
                var data = parser.ParseFile<Table1>();
                importer.Import(data);
            }
            else
            {
                Table2Importer importer = new Table2Importer();
                var data = parser.ParseFile<Table2>();
                importer.Import(data);
            }
            return is_success;
        }
    }
}

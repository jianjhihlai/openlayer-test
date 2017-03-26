using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ImportToSQLDB
{
    public class Table1Importer:ITableImporter
    {
        public DataTable ParseCSVToDataTable(string csv_file)
        {
            throw new NotImplementedException();
        }

        public void ImportExecute(System.Data.DataTable data)
        {
            throw new NotImplementedException();
        }
    }
}

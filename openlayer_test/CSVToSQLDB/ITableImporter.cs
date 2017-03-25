using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ImportToSQLDB
{
    interface ITableImporter
    {
        DataTable ParseCSVToDataTable(string csv_file);
        void ImportExecute(DataTable data);
    }
}

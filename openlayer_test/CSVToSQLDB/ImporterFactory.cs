using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportToSQLDB
{
    public class ImporterFactory
    {
        public ITableImporter GetImporter(string table_type)
        {
            ITableImporter importer;
            switch (table_type)
            {
                case "Table1":
                    importer = new Table1Importer();
                    break;
                case "Table2":
                    importer = new Table2Importer();
                    break;
                default:
                    importer = null;
                    break;
            }
            return importer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Openlayer_test.TESTDB;
using Openlayer_test.TESTDB.EF;

namespace ImportToSQLDB
{
    public class Table1Importer
    {
        int _count_success = 0;
        int _count_fail = 0;
        public void Import(List<Openlayer_test.TESTDB.Table1> data_list)
        {
            var repository = new Table1Repository();
            foreach (Openlayer_test.TESTDB.Table1 data in data_list)
            {
                if (repository.Create(data) > 0)
                {
                    _count_success++;
                }
                else
                {
                    _count_fail++;
                }
            }
        }
    }
}

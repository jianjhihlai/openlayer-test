using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportToSQLDB
{
    class ExcelReader:IFileReader
    {
        string _file = "";
        public ExcelReader(string file_path)
        {
            _file = file_path;
        }
        public bool IsEnd()
        {
            throw new NotImplementedException();
        }

        public string[] ReadFields()
        {
            throw new NotImplementedException();
        }
    }
}

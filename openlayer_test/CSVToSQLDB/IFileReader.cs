using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImportToSQLDB
{
    public interface IFileReader
    {
        bool IsEnd();
        string[] ReadFields();
    }
}

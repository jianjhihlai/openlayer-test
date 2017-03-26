using System;
using System.Collections.Generic;
using System.Text;

namespace sqldbimport
{
    interface ILogHandler
    {
        void Log(string Message);
        Boolean Enabled { get; set; }
        String Prefix { get; set; }
        String Main { get; set; }
        String Subfix { get; set; }
        String Ext { get; set; }
        String LogDir { get; set; }
        String LogFileFullPath { get; }
        String LogFileName { get; }
        void Delete();
    }
}

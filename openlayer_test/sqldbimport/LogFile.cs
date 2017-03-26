using System;
using System.Collections.Generic;
using System.IO;

namespace sqldbimport
{
    public class LogFile:ILogHandler
    {
        string _prefix = "";
        string _main = "";
        string _subfix = "log";
        string _ext = ".txt";
        string _dir = @"D:\temp";
        Boolean _enabled = true;

        #region ILogHandler 成員

        public void Log(string Message)
        {
            if (Enabled)
            {
                using (StreamWriter w = File.AppendText(LogFileFullPath))
                {
                    Log(Message, w);
                }
            }
        }

        public Boolean Enabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
            }
        }

        public string Prefix
        {
            get
            {
                return _prefix;
            }
            set
            {
                _prefix = value;
            }
        }
        public string Main
        {
            get
            {
                return _main;
            }
            set
            {
                _main = value;
            }
        }

        public string Subfix
        {
            get
            {
                return _subfix;
            }
            set
            {
                _subfix = value;
            }
        }

        public string Ext
        {
            get
            {
                return _ext;
            }
            set
            {
                _ext = value;
            }
        }
        public string LogDir
        {
            get
            {
                return _dir;
            }
            set
            {
                _dir = value;
            }
        }
        public string LogFileFullPath
        {
            get
            {
                return LogDir + "\\" + LogFileName;
            }
        }
        public string LogFileName
        {
            get
            {
                return Prefix + Subfix + Ext;
            }
        }

        public void Delete()
        {
            File.Delete(LogFileFullPath);
        }
        #endregion
        public void Log(string logMessage, TextWriter w)
        {
            if (Enabled)
            {
                w.WriteLine("{0} {1}\t{2}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString(), logMessage);
            }
        }
    }
}

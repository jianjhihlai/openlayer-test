using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Openlayer_test.TESTDB;
using Microsoft.VisualBasic.FileIO;

namespace ImportToSQLDB
{
    class CSVReader:IFileReader
    {
        TextFieldParser _csvReader;

        public CSVReader(string path)
        {
            _csvReader = new TextFieldParser(path, System.Text.Encoding.GetEncoding("big5"));
            _csvReader.SetDelimiters(new string[] { "," });
            _csvReader.HasFieldsEnclosedInQuotes = true;
        }

        public string[] ReadFields()
        {
            return _csvReader.ReadFields();
        }

        public bool IsEnd()
        {
            return _csvReader.EndOfData;
        }
    }
}

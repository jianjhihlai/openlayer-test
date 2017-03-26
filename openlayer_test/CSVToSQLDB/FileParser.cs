using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Openlayer_test.TESTDB;
using System.IO;

namespace ImportToSQLDB
{
    public class FileParser
    {
        IFileReader _reader;


        public FileParser(string file_path)
        {
            string ext_name = Path.GetExtension(file_path);
            switch (ext_name)
            {
                case ".csv":
                    _reader = new CSVReader(file_path);
                    break;
                case ".xlsx":
                    _reader = new ExcelReader(file_path);
                    break;
            }
        }

        public List<T> ParseFile<T>() where T: DBObject, new()
        {
            List<T> data_list = new List<T>();
            string[] colFields = _reader.ReadFields();
            while (!_reader.IsEnd())
            {
                string[] fieldData = _reader.ReadFields();
                T dataRow = new T();
                Village village = new Village();
                Town town = new Town();
                County county = new County();

                //Making empty value as null
                for (int i = 0; i < colFields.Length; i++)
                {
                    if (colFields[i].Trim().ToUpper().Equals("VILLAGE"))
                    {
                        village.VillageName = fieldData[i].Trim();
                    }
                    else if (colFields[i].Trim().ToUpper().Equals("TOWN"))
                    {
                        town.TownName = fieldData[i].Trim();
                    }
                    else if (colFields[i].Trim().ToUpper().Equals("COUNTY"))
                    {
                        county.CountyName = fieldData[i].Trim();
                    }
                    else
                    {
                        PropertyDescriptor property = TypeDescriptor.GetProperties(typeof(T))[colFields[i]];
                        try
                        {
                            string val = fieldData[i].Trim();
                            if (property.PropertyType.Equals(typeof(string)))
                            {
                                property.SetValue(dataRow, val);
                            }
                            else if (property.PropertyType.Equals(typeof(Boolean)))
                            {
                                bool value = false;
                                value = val.ToLower().StartsWith("true");
                                property.SetValue(dataRow, value);
                            }
                            else if (property.PropertyType.Equals(typeof(int)))
                            {
                                int value = String.IsNullOrEmpty(val) ? 0 : int.Parse(val);
                                property.SetValue(dataRow, value);
                            }
                            else if (property.PropertyType.Equals(typeof(double)))
                            {
                                double value = 0.0d;
                                if (!String.IsNullOrEmpty(val))
                                {
                                    value = Convert.ToDouble(val);
                                }
                                property.SetValue(dataRow, value);
                            }
                            else if (property.PropertyType.Equals(typeof(DateTime)))
                            {
                                DateTime value = String.IsNullOrEmpty(val)
                                    ? DateTime.MinValue
                                    : DateTime.Parse(val);
                                property.SetValue(dataRow, value);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                town.County = county;
                village.Town = town;
                PropertyDescriptor village_prop = TypeDescriptor.GetProperties(typeof(T))["Village"];
                village_prop.SetValue(dataRow, village);
                data_list.Add(dataRow);
            }
            return data_list;
        }
    }
}

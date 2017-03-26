using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using Openlayer_test.TESTDB.EF;
using Openlayer_test.TESTDB;

namespace sqldbimport
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                //印出程式的名稱
                Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
                //印出傳入的參數
                Console.WriteLine(args[0].ToString());
            }
            string connectionString = String.Format("{0}",
                ConfigurationManager.ConnectionStrings["TESTDB"]
            );
            
            Console.WriteLine(connectionString);
            var village_model = new VillageRepository();
            var village = new Village();
            village.VillageName = "安正里";
            var town = new Town();
            town.TownName = "麻豆區";
            var county = new County();
            county.CountyName = "台南市";
            town.County = county;
            village.Town = town;
            var id = village_model.Create(village);
            if (id > 0)
            {
                Console.WriteLine("成功寫入，寫入的ID為：" + id.ToString());
            }
            else
            {
                Console.WriteLine("寫入失敗");
            }
            Console.ReadKey();
        }

        static DataTable ParseCSVToDataTable(string csv_file)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return csvData;
        }
    }
}

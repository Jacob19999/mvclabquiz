// Written By Jacob Tang. Using visual basic File IO. 

using System;
using System.Data;
using Microsoft.VisualBasic.FileIO;

namespace File
{
    public class FileGateway
    {

        public DataTable GetDataTabletFromCSVFile(string path)
        {
            DataTable dt = new DataTable();

            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();

                    foreach (string column in colFields)
                    {

                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        dt.Columns.Add(datecolumn);
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
                        dt.Rows.Add(fieldData);
                    }
                }
            }
            catch (Exception ex)
            {
                string err = "File Not Found.";
            }
            return dt;
        }

        public void PrintDataTable(DataTable Table)
        {
            foreach (DataRow dataRow in Table.Rows)
            {
                foreach (var item in dataRow.ItemArray)
                {
                    System.Diagnostics.Debug.WriteLine(item);
                }
            }

        }
    }

}

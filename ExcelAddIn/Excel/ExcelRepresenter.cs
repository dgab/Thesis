using Microsoft.Office.Interop.Excel;
using System;
using System.Runtime.InteropServices;
using Data = System.Data;

namespace ExcelAddIn.Excel
{
    class ExcelRepresenter
    {
        public Application Application { get; private set; }
        public Workbook Workbook { get; private set; }
        public Worksheet Worksheet { get; private set; }


        public ExcelRepresenter()
        {

        }

        public static ExcelRepresenter GetCurrentWorkSheet()
        {
            ExcelRepresenter excel = new ExcelRepresenter();
            excel.Application = (Application)Marshal.GetActiveObject("Excel.Application");
            //excel.Application.Visible = true;
            excel.Workbook = (Workbook)excel.Application.ActiveWorkbook;
            excel.Worksheet = (Worksheet)excel.Workbook.ActiveSheet;
            return excel;
        }

        public Data.DataTable GetSelectedCells()
        {
            Range selected = Application.Selection as Range;
            Data.DataTable table = new Data.DataTable();
            if (selected != null)
            {
                object[,] data = selected.Value2 as object[,];

                for (int i = 1; i <= selected.Columns.Count; i++)
                {
                    var Column = new Data.DataColumn();
                    Column.DataType = System.Type.GetType("System.String");
                    Column.ColumnName = i.ToString();
                    table.Columns.Add(Column);

                    for (int j = 1; j <= selected.Rows.Count; j++)
                    {
                        string cellVal;

                        try
                        {
                            cellVal = (string)(data[j, i]);
                        }
                        catch (InvalidCastException)
                        {
                            var ConvertVal = (double)(data[j, i]);
                            cellVal = ConvertVal.ToString();
                        }


                        if (i == 1)
                        {

                            var row = table.NewRow();
                            row[i.ToString()] = cellVal;
                            table.Rows.Add(row);
                        }
                        else
                        {

                            var row = table.Rows[j - 1];
                            row[i.ToString()] = cellVal;
                        }
                    }
                }
            }
            return table;

        }

    }
}

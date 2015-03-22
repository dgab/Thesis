using ExcelAddIn.Exceptions;
using Microsoft.Office.Interop.Excel;
using Data = System.Data;

namespace ExcelAddIn.Excel
{
    class ExcelRepresenter : IExcelRepresenter
    {
        public Application Application
        {
            get
            {
                return ThisAddIn.CurrentApplication;
            }
        }

        public Workbook ActiveWorkbook
        {
            get
            {
                return this.Application.ActiveWorkbook;
            }
        }
        public Worksheet ActiveWorksheet
        {
            get
            {
                return (Worksheet)this.ActiveWorkbook.ActiveSheet;
            }
        }

        public Data.DataTable ConvertSelectedRangeToDataTable()
        {
            Data.DataTable table = new Data.DataTable();

            Range rng = Application.Selection as Range;

            if (rng == null)
            {
                throw new RangeWasNullException("No range was selected.");
            }

            int colCount = rng.Columns.Count;
            int rowCount = rng.Rows.Count;

            for (int i = 0; i < colCount; i++)
            {
                Data.DataColumn dc = new Data.DataColumn();
                table.Columns.Add(dc);
            }
            for (int i = 1; i <= rowCount; i++)
            {
                Data.DataRow dr = table.NewRow();
                for (int j = 1; j <= colCount; j++)
                {
                    dr[j - 1] = ((Range)rng.Cells[i, j]).Value2;
                }
                table.Rows.Add(dr);
            }

            return table;
        }
    }
}

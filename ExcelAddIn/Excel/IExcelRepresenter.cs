using Microsoft.Office.Interop.Excel;
using Data = System.Data;

namespace ExcelAddIn.Excel
{
    interface IExcelRepresenter
    {
        Application Application { get;  }

        Workbook ActiveWorkbook { get;  }

        Worksheet ActiveWorksheet { get;  }

        Data.DataTable ConvertSelectedRangeToDataTable();
    }
}

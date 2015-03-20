using System;

namespace ExcelAddIn.Excel
{
    class RangeWasNullException : Exception
    {
        public RangeWasNullException()
            : base() { }

        public RangeWasNullException(string message)
            : base(message) { }

        public RangeWasNullException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public RangeWasNullException(string message, Exception innerException)
            : base(message, innerException) { }

        public RangeWasNullException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}

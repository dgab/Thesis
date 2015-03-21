using System;

namespace ExcelAddIn.Test
{
    class InvalidNumberOfColumnsException : Exception
    {
        public InvalidNumberOfColumnsException()
            : base() { }

        public InvalidNumberOfColumnsException(string message)
            : base(message) { }

        public InvalidNumberOfColumnsException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public InvalidNumberOfColumnsException(string message, Exception innerException)
            : base(message, innerException) { }

        public InvalidNumberOfColumnsException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}

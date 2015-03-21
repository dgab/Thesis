
namespace ExcelAddIn.Test
{
    class TestResult
    {
        public int Row { get; private set; }

        public double Error { get; private set; }
        public TestResult(int row, double error)
        {
            this.Row = row;
            this.Error = error;
        }
    }
}

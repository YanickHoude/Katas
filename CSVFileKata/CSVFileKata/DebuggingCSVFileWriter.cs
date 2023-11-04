namespace CSVFileKata
{
    public class DebuggingCSVFileWriter : ICustomerCSVFileWriter
    {
        private ICustomerCSVFileWriter _csvFileWriter;
        private ICustomerCSVFileWriter _debugCsvFileWriter;

        public DebuggingCSVFileWriter(ICustomerCSVFileWriter csvFileWriter, ICustomerCSVFileWriter debugCsvFileWriter)
        {
            _csvFileWriter = csvFileWriter;
            _debugCsvFileWriter = debugCsvFileWriter;
        }


        public void Write(string filename, List<Customer> customers)
        {

        }
    }
}
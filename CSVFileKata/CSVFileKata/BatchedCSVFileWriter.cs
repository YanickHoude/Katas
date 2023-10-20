namespace CSVFileKata
{
    public class BatchedCSVFileWriter
    {
        private ICustomerCSVFileWriter _csvFileWriter;

        public BatchedCSVFileWriter(ICustomerCSVFileWriter csvFileWriter)
        {
            _csvFileWriter = csvFileWriter;
        }

        public void Write(string filename, List<Customer> customers)
        {
            var baseFileName = Path.GetFileNameWithoutExtension(filename);
            _csvFileWriter.Write(baseFileName + "1.csv", customers);
        }
    }
}
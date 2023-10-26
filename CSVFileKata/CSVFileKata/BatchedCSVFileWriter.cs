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

            if (customers.Count > 10)
            {
                _csvFileWriter.Write(baseFileName + "1.csv", customers.Take(10).ToList());
                _csvFileWriter.Write(baseFileName + "2.csv", customers.Skip(10).ToList());

            }
            else
            {
                _csvFileWriter.Write(baseFileName + "1.csv", customers);

            }

        }
    }
}
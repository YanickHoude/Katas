namespace CSVFileKata
{
    public class BatchedCSVFileWriter
    {
        private ICustomerCSVFileWriter _csvFileWriter;
        private int _batchSize;

        public BatchedCSVFileWriter(int batchSize, ICustomerCSVFileWriter csvFileWriter)
        {
            _csvFileWriter = csvFileWriter;
            _batchSize = batchSize;
        }

        public void Write(string filename, List<Customer> customers)
        {
            var baseFileName = Path.GetFileNameWithoutExtension(filename);
            var fileNumber = 1;

            for (int i = 0; i < customers.Count; i = i + _batchSize)
            {
                _csvFileWriter.Write(baseFileName + fileNumber.ToString() + ".csv", customers.Skip(i).Take(_batchSize).ToList());
                fileNumber++;
            }
        }
    }
}
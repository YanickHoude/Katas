namespace CSVFileKata
{
    public class DeduplicatingCSVFileWriter : ICustomerCSVFileWriter
    {
        private ICustomerCSVFileWriter _csvFileWrtier;

        public DeduplicatingCSVFileWriter(ICustomerCSVFileWriter csvFileWriter)
        {
            this._csvFileWrtier = csvFileWriter;
        }

        public void Write(string filename, List<Customer> customers)
        {
            var uniqueCustomers = customers.DistinctBy(customer => customer.Name).ToList();
            _csvFileWrtier.Write(filename, uniqueCustomers);
        }
    }
}
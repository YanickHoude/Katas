namespace CSVFileKata
{
    public interface ICustomerCSVFileWriter
    {
        void Write(string filename, List<Customer> customers);

    }
}
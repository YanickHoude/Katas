using System;
namespace CSVFileKata
{
    public class CustomerCSVFileWriter: ICustomerCSVFileWriter
    {
        private readonly IFileSystem _fileSystem;

        public CustomerCSVFileWriter(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Write(string filename, List<Customer> customers)
        {
            foreach (var c in customers)
            {
                if(c.Name != "" && c.ContactNumber != "")
                {
                    _fileSystem.WriteLine(filename, c.ToString());
                }
            }
        }
    }
}


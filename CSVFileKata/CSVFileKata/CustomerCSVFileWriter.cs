using System;
namespace CSVFileKata
{
    public class CustomerCSVFileWriter
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
                _fileSystem.WriteLine(filename, c.ToString());
            }
        }
    }
}


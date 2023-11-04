using CSVFileKata;
using NUnit.Framework;

namespace CSVFileKataTests
{
    public class FakeCSVFileWriter : ICustomerCSVFileWriter
    {
        public List<(string Filename, List<Customer> Customers)> Calls { get; private set; } = new();

        public void Write(string filename, List<Customer> customers)
        {
            Calls.Add((filename, customers));
        }

        //could be used to replace all the duplicated "Assert" code in our tests
        public void AssertCustomersWereWrittenToFile(string expectedFilename, List<Customer> expectedCustomers)
        {
            var call = Calls.Where(call => call.Filename == expectedFilename);
            Assert.IsTrue(call.Any(), $"No call made for this filename {expectedFilename}");
            CollectionAssert.AreEquivalent(expectedCustomers, call.First().Customers);
        }
    }
}
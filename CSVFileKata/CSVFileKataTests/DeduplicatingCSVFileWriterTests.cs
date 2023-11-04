using NUnit.Framework;
using NSubstitute;
using CSVFileKata;

namespace CSVFileKataTests
{
	[TestFixture]
	public class DeduplicatingCSVFileWriterTests
	{
        [TestFixture]
        public class UniqueCustomers
        {
            [Test]
            public void Given12Customers()
            {
                //arrange
                var customers = CreateUniqueCustomers(12);
                var csvFileWriter = CreateFakeCSVFileWriter();
                var filename = "customers.csv";
                var sut = new DeduplicatingCSVFileWriter(csvFileWriter);

                //act
                sut.Write(filename, customers);

                //assert
                csvFileWriter.AssertCustomersWereWrittenToFile("customers.csv", customers);
            }
        }

        [Test]
        public void Given2DuplicateCustomers()
        {
            //arrange
            var originalCustomer = new Customer { Name = "Dan", ContactNumber = "1" };
            var duplicateCustomer = new Customer { Name = "Dan", ContactNumber = "2" };
            var customers = new List<Customer>
            {
                originalCustomer,
                duplicateCustomer
            };

            var csvFileWriter = CreateFakeCSVFileWriter();
            var filename = "customers.csv";
            var sut = new DeduplicatingCSVFileWriter(csvFileWriter);

            //act
            sut.Write(filename, customers);

            //assert
            csvFileWriter.AssertCustomersWereWrittenToFile("customers.csv", new List<Customer> { originalCustomer });
        }

        private static FakeCSVFileWriter CreateFakeCSVFileWriter()
        {
            return new FakeCSVFileWriter();
        }

        private static List<Customer> CreateUniqueCustomers(int numCustomers)
        {
            return new CustomerListBuilder().WithCustomers(numCustomers).Build();
        }
    }
}


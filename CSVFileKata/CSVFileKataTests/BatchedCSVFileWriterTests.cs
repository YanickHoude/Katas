using NUnit.Framework;
using NSubstitute;
using CSVFileKata;
using Castle.Core.Resource;

namespace CSVFileKataTests
{
	public class BatchedCSVFileWriterTests
	{
        public class Write
        {
            public class SingleFile
            {
                [Test]
                public void Given2Customers_ShouldWriteCustomersDataAsCSVLineToFilenameWithConcatenated1()
                {
                    //arrange
                    var customers = new List<Customer>
                {
                    GenerateCustomer("a","1"),
                    GenerateCustomer("b","2"),

                };

                    var csvFileWriter = Substitute.For<ICustomerCSVFileWriter>();
                    var fileName = "customers.csv";
                    var sut = new BatchedCSVFileWriter(csvFileWriter);

                    //act
                    sut.Write(fileName, customers);

                    //assert
                    csvFileWriter.Received(1).Write("customers1.csv", customers);
                }

                [Test]
                public void Given6Customers_ShouldWriteCustomersDataAsCSVLineToFilenameWithConcatenated1()
                {
                    //arrange
                    var customers = new List<Customer>
                    {
                        GenerateCustomer("a","1"),
                        GenerateCustomer("b","2"),
                        GenerateCustomer("c","3"),
                        GenerateCustomer("d","4"),
                        GenerateCustomer("e","5"),
                        GenerateCustomer("f","6"),

                    };

                    var csvFileWriter = Substitute.For<ICustomerCSVFileWriter>();
                    var fileName = "customers.csv";
                    var sut = new BatchedCSVFileWriter(csvFileWriter);

                    //act
                    sut.Write(fileName, customers);

                    //assert
                    csvFileWriter.Received(1).Write("customers1.csv", customers);
                }

            }

            public class MultipleFiles
            {
                [Test]
                public void Given12custuomers_ShouldWriteFirst10CustomersToFilenameWithConcatenated1AndWriteRemaining2CustomersToFilenameWithConcatenated2()
                {
                    //arrange
                    var customers = new List<Customer>
                    {
                        GenerateCustomer("a","1"),
                        GenerateCustomer("b","2"),
                        GenerateCustomer("c","3"),
                        GenerateCustomer("d","4"),
                        GenerateCustomer("e","5"),
                        GenerateCustomer("f","6"),
                        GenerateCustomer("g","7"),
                        GenerateCustomer("h","8"),
                        GenerateCustomer("i","9"),
                        GenerateCustomer("j","10"),
                        GenerateCustomer("k","11"),
                        GenerateCustomer("l","12")
                    };

                    var csvFileWriter = new FakeCSVFileWriter();
                    var filename = "customers.csv";
                    var sut = new BatchedCSVFileWriter(csvFileWriter);

                    //act
                    sut.Write(filename, customers);

                    //assert
                    //Assert.AreEqual(2, csvFileWriter.Calls.Count());
                    Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                    CollectionAssert.AreEquivalent(customers.Take(10).ToList(), csvFileWriter.Calls[0].Customers);

                    //Assert.AreEqual(2, csvFileWriter.Calls.Count());
                    Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                    CollectionAssert.AreEquivalent(customers.Skip(10).ToList(), csvFileWriter.Calls[1].Customers);


                    //csvFileWriter.Received(1).Write("customers1.csv", customers.Take(10).ToList());
                    //csvFileWriter.Received(1).Write("customers2.csv", customers.Skip(10).ToList());

                }

                private class FakeCSVFileWriter: ICustomerCSVFileWriter
                {
                    public List<(string Filename, List<Customer> Customers)> Calls { get; private set; } = new();

                    public void Write(string filename, List<Customer> customers)
                    {
                        Calls.Add((filename, customers));
                    }
                }

            }



            //[Test]
            //public void Given12Customers_ShouldWriteFirst10CustomersDataAsCSVLinesToFirstProvidedFileAndLast2CustomersDataToSecondProvidedFile()
            //{
            //    //arrange
            //    var customers = new List<Customer>
            //{
            //    GenerateCustomer("a","1"),
            //    GenerateCustomer("b","2"),
            //    GenerateCustomer("c","3"),
            //    GenerateCustomer("d","4"),
            //    GenerateCustomer("e","5"),
            //    GenerateCustomer("f","6"),
            //    GenerateCustomer("g","7"),
            //    GenerateCustomer("h","8"),
            //    GenerateCustomer("i","9"),
            //    GenerateCustomer("j","10"),
            //    GenerateCustomer("k","11"),
            //    GenerateCustomer("l","12")
            //};

            //    var csvFileWriter = Substitute.For<ICustomerCSVFileWriter>();
            //    var fileName = "cust.csv";
            //    var sut = new BatchedCSVFileWriter();

            //    //act
            //    sut.Write(fileName, customers);

            //    //assert
            //    AssertCustomersWereWritten(csvFileWriter, "cust1.csv", customers.Take(10));
            //    AssertCustomersWereWritten(csvFileWriter, "cust2.csv", customers.Skip(10).Take(2));

            //}
        }



        //Class Constructors
        private static CustomerCSVFileWriter CreateCustomerCsvFileWriter(IFileSystem fileSystem)
        {
            return new CustomerCSVFileWriter(fileSystem);
        }

        private static Customer GenerateCustomer(string name, string contactNumber)
        {
            return new Customer
            {
                Name = name,
                ContactNumber = contactNumber
            };
        }

        private static IFileSystem CreateMockFileSystem()
        {
            return Substitute.For<IFileSystem>();
        }
    }
}
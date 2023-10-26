using NUnit.Framework;
using NSubstitute;
using CSVFileKata;
using Castle.Core.Resource;
using System;

namespace CSVFileKataTests
{
    public class BatchedCSVFileWriterTests
    {
        public class Write
        {
            [TestFixture]
            public class BatchSize1500
            {
                public class SingleFile
                {
                    [Test]
                    public void Given10Customers()
                    {
                        //arrange
                        var customers = GenerateCustomerList(10);
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var filename = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(1500, csvFileWriter);

                        //act
                        sut.Write(filename, customers);

                        //assert
                        Assert.AreEqual(1, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(0).Take(1500).ToList(), csvFileWriter.Calls[0].Customers);
                    }
                }

                public class TwoFiles
                {
                    [Test]
                    public void Given1501Customers()
                    {
                        //arrange
                        var customers = GenerateCustomerList(1501);
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var filename = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(1500, csvFileWriter);

                        //act
                        sut.Write(filename, customers);

                        //assert
                        Assert.AreEqual(2, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(0).Take(1500).ToList(), csvFileWriter.Calls[0].Customers);
                        Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(1500).Take(1500).ToList(), csvFileWriter.Calls[1].Customers);
                    }

                    [Test]
                    public void Given3000Customers()
                    {
                        //arrange
                        var customers = GenerateCustomerList(3000);
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var filename = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(1500, csvFileWriter);

                        //act
                        sut.Write(filename, customers);

                        //assert
                        Assert.AreEqual(2, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(0).Take(1500).ToList(), csvFileWriter.Calls[0].Customers);
                        Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(1500).Take(1500).ToList(), csvFileWriter.Calls[1].Customers);
                    }
                }
            }

            [TestFixture]
            public class BatchSize10
            {
                [TestFixture]
                public class SingleFile
                {
                    [Test]
                    public void Given2Customers()
                    {
                        //arrange
                        var customers = GenerateCustomerList(2);
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var fileName = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                        //act
                        sut.Write(fileName, customers);

                        //assert
                        Assert.AreEqual(1, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers, csvFileWriter.Calls[0].Customers);
                    }

                    [Test]
                    public void Given6Customers()
                    {
                        //arrange
                        var customers = GenerateCustomerList(6);
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var fileName = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                        //act
                        sut.Write(fileName, customers);

                        //assert
                        Assert.AreEqual(1, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers, csvFileWriter.Calls[0].Customers);
                    }

                    [Test]
                    public void Given10Customers()
                    {
                        //arrange
                        var customers = GenerateCustomerList(10);
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var fileName = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                        //act
                        sut.Write(fileName, customers);

                        //assert
                        Assert.AreEqual(1, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers, csvFileWriter.Calls[0].Customers);
                    }

                }

                public class MultipleFiles
                {
                    public class TwoFiles
                    {
                        [Test]
                        public void Given12Customers()
                        {
                            //arrange
                            var customers = GenerateCustomerList(12);
                            var csvFileWriter = CreateFakeCSVFileWriter();
                            var filename = "customers.csv";
                            BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                            //act
                            sut.Write(filename, customers);

                            //assert
                            Assert.AreEqual(2, csvFileWriter.Calls.Count());
                            Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                            CollectionAssert.AreEquivalent(customers.Take(10).ToList(), csvFileWriter.Calls[0].Customers);
                            Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                            CollectionAssert.AreEquivalent(customers.Skip(10).ToList(), csvFileWriter.Calls[1].Customers);

                        }

                        [Test]
                        public void Given20Customers()
                        {
                            //arrange
                            var customers = GenerateCustomerList(20);
                            var csvFileWriter = CreateFakeCSVFileWriter();
                            var filename = "customers.csv";
                            BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                            //act
                            sut.Write(filename, customers);

                            //assert
                            Assert.AreEqual(2, csvFileWriter.Calls.Count());
                            Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                            CollectionAssert.AreEquivalent(customers.Take(10).ToList(), csvFileWriter.Calls[0].Customers);
                            Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                            CollectionAssert.AreEquivalent(customers.Skip(10).ToList(), csvFileWriter.Calls[1].Customers);

                        }
                    }

                    public class ThreeFiles
                    {
                        [Test]
                        public void Given21custuomers()
                        {
                            //arrange
                            var customers = GenerateCustomerList(21);
                            var csvFileWriter = CreateFakeCSVFileWriter();
                            var filename = "customers.csv";
                            BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                            //act
                            sut.Write(filename, customers);

                            //assert
                            Assert.AreEqual(3, csvFileWriter.Calls.Count());
                            Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                            CollectionAssert.AreEquivalent(customers.Take(10).ToList(), csvFileWriter.Calls[0].Customers);
                            Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                            CollectionAssert.AreEquivalent(customers.Skip(10).Take(10).ToList(), csvFileWriter.Calls[1].Customers);
                            Assert.AreEqual("customers3.csv", csvFileWriter.Calls[2].Filename);
                            CollectionAssert.AreEquivalent(customers.Skip(20).Take(10).ToList(), csvFileWriter.Calls[2].Customers);
                        }

                        [Test]
                        public void Given30custuomers()
                        {
                            //arrange
                            var customers = GenerateCustomerList(30);
                            var csvFileWriter = CreateFakeCSVFileWriter();
                            var filename = "customers.csv";
                            BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(10, csvFileWriter);

                            //act
                            sut.Write(filename, customers);

                            //assert
                            Assert.AreEqual(3, csvFileWriter.Calls.Count());
                            Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                            CollectionAssert.AreEquivalent(customers.Take(10).ToList(), csvFileWriter.Calls[0].Customers);
                            Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                            CollectionAssert.AreEquivalent(customers.Skip(10).Take(10).ToList(), csvFileWriter.Calls[1].Customers);
                            Assert.AreEqual("customers3.csv", csvFileWriter.Calls[2].Filename);
                            CollectionAssert.AreEquivalent(customers.Skip(20).Take(10).ToList(), csvFileWriter.Calls[2].Customers);
                        }
                    }
                }
            }

            private static BatchedCSVFileWriter CreateBatchedCSVFileWriter(int batchSize, FakeCSVFileWriter csvFileWriter)
            {
                return new BatchedCSVFileWriter(batchSize, csvFileWriter);
            }

            private static FakeCSVFileWriter CreateFakeCSVFileWriter()
            {
                return new FakeCSVFileWriter();
            }

            private class FakeCSVFileWriter : ICustomerCSVFileWriter
            {
                public List<(string Filename, List<Customer> Customers)> Calls { get; private set; } = new();

                public void Write(string filename, List<Customer> customers)
                {
                    Calls.Add((filename, customers));
                }
            }

            private static CustomerCSVFileWriter CreateCustomerCsvFileWriter(IFileSystem fileSystem)
            {
                return new CustomerCSVFileWriter(fileSystem);
            }

            private static List<Customer> GenerateCustomerList(int numberOfCustomers)
            {
                var customerList = new List<Customer>();
                var seed = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                for (int i = 0; i < numberOfCustomers; i++)
                {
                    var cust = new string(Enumerable.Repeat(chars, 10).Select
                        (s => s[seed.Next(s.Length)]).ToArray());

                    customerList.Add(GenerateCustomer(cust, seed.Next().ToString()));
                }

                return customerList;
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
}
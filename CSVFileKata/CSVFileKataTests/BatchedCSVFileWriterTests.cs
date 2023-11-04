using NUnit.Framework;
using NSubstitute;
using CSVFileKata;
using Castle.Core.Resource;
using System;

namespace CSVFileKataTests
{
    public partial class BatchedCSVFileWriterTests
    {
        public partial class Write
        {
            [TestFixture]
            public class DifferentBatchSize
            {
                public class SingleFile
                {
                    [Test]
                    public void Given10Customers_BatchSize100()
                    {
                        //arrange
                        var customers = new CustomerListBuilder().WithCustomers(10).Build();
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var filename = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(100, csvFileWriter);

                        //act
                        sut.Write(filename, customers);

                        //assert
                        Assert.AreEqual(1, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(0).Take(100).ToList(), csvFileWriter.Calls[0].Customers);
                    }
                }

                public class TwoFiles
                {
                    [Test]
                    public void Given10Customers_BatchSize5()
                    {
                        //arrange
                        var customers = new CustomerListBuilder().WithCustomers(10).Build();
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var filename = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(5, csvFileWriter);

                        //act
                        sut.Write(filename, customers);

                        //assert
                        Assert.AreEqual(2, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(0).Take(5).ToList(), csvFileWriter.Calls[0].Customers);
                        Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(5).Take(5).ToList(), csvFileWriter.Calls[1].Customers);
                    }

                    [Test]
                    public void Given100CustomersBatchSize80()
                    {
                        //arrange
                        var customers = new CustomerListBuilder().WithCustomers(100).Build();
                        var csvFileWriter = CreateFakeCSVFileWriter();
                        var filename = "customers.csv";
                        BatchedCSVFileWriter sut = CreateBatchedCSVFileWriter(80, csvFileWriter);

                        //act
                        sut.Write(filename, customers);

                        //assert
                        Assert.AreEqual(2, csvFileWriter.Calls.Count());
                        Assert.AreEqual("customers1.csv", csvFileWriter.Calls[0].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(0).Take(80).ToList(), csvFileWriter.Calls[0].Customers);
                        Assert.AreEqual("customers2.csv", csvFileWriter.Calls[1].Filename);
                        CollectionAssert.AreEquivalent(customers.Skip(80).Take(80).ToList(), csvFileWriter.Calls[1].Customers);
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
                        var customers = new CustomerListBuilder().WithCustomers(2).Build();
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
                        var customers = new CustomerListBuilder().WithCustomers(6).Build();
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
                        var customers = new CustomerListBuilder().WithCustomers(10).Build();
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
                            var customers = new CustomerListBuilder().WithCustomers(12).Build();
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
                            var customers = new CustomerListBuilder().WithCustomers(20).Build();
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
                            var customers = new CustomerListBuilder().WithCustomers(21).Build();
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
                            var customers = new CustomerListBuilder().WithCustomers(30).Build();
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

            private static CustomerCSVFileWriter CreateCustomerCsvFileWriter(IFileSystem fileSystem)
            {
                return new CustomerCSVFileWriter(fileSystem);
            }

            private static IFileSystem CreateMockFileSystem()
            {
                return Substitute.For<IFileSystem>();
            }
        }
    }
}
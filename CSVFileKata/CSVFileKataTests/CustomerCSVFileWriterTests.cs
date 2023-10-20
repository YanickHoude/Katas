using NUnit.Framework;
using NSubstitute;
using CSVFileKata;

namespace CSVFileKataTests;

//The KATA:
//

//SOLID:
//Single Responsibility
//Open/Closed
//Liskob Principle
//Interface Segragation
//Dependency Inversion

[TestFixture]
public class CustomerCSVFileWriterTests
{
    [TestFixture]
    public class Write
    {
        [Test]
        public void GivenCustomerWithNoNameOrContactNumber_ShouldWriteNothing()
        {
            //arrange
            Customer customer = GenerateCustomer("", "");

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);

            //act
            sut.Write("customer.csv", new List<Customer> { customer });

            //assert
            fileSystem.DidNotReceive().WriteLine("customer.csv", $"{customer}");

        }

        [Test]
        public void GivenNoCustomers_ShouldWriteNothing()
        {

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);

            //act
            sut.Write("customer.csv", new List<Customer> { });

            //assert
            fileSystem.DidNotReceive().WriteLine("customer.csv", Arg.Any<string>());
        }

        [Test]
        public void GivenNull_ShouldWriteNothing()
        {

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);

            //act
            var ex = Assert.Throws<NullReferenceException>(() => sut.Write("customer.csv", null));


            //assert
            StringAssert.Contains("Object reference not set to an instance of an object", ex!.Message);
        }

        [Test]
        public void GivenOneCustomer_ShouldWriteCustomerDataAsCSVLineToProvidedFile()
        {
            //arragne
            Customer customer = GenerateCustomer("Yanick Houde", "12345678");

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);

            //act
            sut.Write("customer.csv", new List<Customer> { customer });

            //assert
            AssertCustomerWasWrittenToFile(fileSystem, "customer.csv", customer);

        }


        [Test]
        public void GivenTwoCustomers_ShouldWriteBothCustomersDataAsCSVLinesToProvidedFile()
        {
            //arrange
            var customer1 = GenerateCustomer("Brandon Clark", "11111111");
            var customer2 = GenerateCustomer("Daniel Tsyplenkov", "87654321");

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);


            //act
            sut.Write("cust.csv", new List<Customer> { customer1, customer2 });

            //assert
            AssertCustomerWasWrittenToFile(fileSystem, "cust.csv", customer1);
            AssertCustomerWasWrittenToFile(fileSystem, "cust.csv", customer2);
        }

        [Test]
        public void GivenThreeCustomers_ShouldWriteAllCustomersDataAsCSVLinesToProvidedFile()
        {
            //arrange
            var customer1 = GenerateCustomer("Bob Burger", "8384934");
            var customer2 = GenerateCustomer("Daniel San", "3213512");
            var customer3 = GenerateCustomer("Bang Bang", "3241232");

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);

            //act
            sut.Write("cust1.csv", new List<Customer> { customer1, customer2, customer3 });

            //assert
            AssertCustomerWasWrittenToFile(fileSystem, "cust1.csv", customer1);
            AssertCustomerWasWrittenToFile(fileSystem, "cust1.csv", customer2);
            AssertCustomerWasWrittenToFile(fileSystem, "cust1.csv", customer3);
        }

        [Test]
        public void GivenCustomers_ShouldWriteOnlyCustomersDataAsCSVLinesToProvidedFile()
        {
            //arrange
            var customer1 = GenerateCustomer("J Bigs", "8384934");
            var customer2 = GenerateCustomer("Poo butt", "3213512");

            var fileSystem = CreateMockFileSystem();
            var sut = CreateCustomerCsvFileWriter(fileSystem);

            //act
            sut.Write("cust1.csv", new List<Customer> { customer1, customer2 });

            //assert
            fileSystem.Received(2).WriteLine("cust1.csv", Arg.Any<string>());
            AssertCustomerWasWrittenToFile(fileSystem, "cust1.csv", customer1);
            AssertCustomerWasWrittenToFile(fileSystem, "cust1.csv", customer2);
        }

        //Assert Functions

        public void AssertCustomerWasWrittenToFile(IFileSystem fileSystem, string fileName, Customer customer)
        {
            fileSystem.Received(1).WriteLine(fileName, $"{customer.Name},{customer.ContactNumber}");
        }

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


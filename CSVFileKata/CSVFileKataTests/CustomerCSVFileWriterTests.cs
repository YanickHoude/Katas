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
    [Test]
    public void Write_GivenOneCustomer_ShouldWriteCustomerDataAsCSVLineToProvidedFile()
    {
        //arragne
        Customer customer = GenerateCustomer("Yanick Houde", "12345678");

        var fileSystem = CreateMockFileSystem();
        var sut = CreateCustomerCsvFileWriter(fileSystem);

        //act
        sut.Write("customer.csv", new List<Customer> { customer });

        //assert
        fileSystem.Received(1).WriteLine("customer.csv", $"{customer.Name},{customer.ContactNumber}");
    }


    [Test]
    public void Write_GivenTwoCustomers_ShouldWriteBothCustomersDataAsCSVLinesToProvidedFile()
    {
        //arrange
        var customer1 = GenerateCustomer("Brandon Clark", "11111111");
        var customer2 = GenerateCustomer("Daniel Tsyplenkov", "87654321");

        var fileSystem = CreateMockFileSystem();
        var sut = CreateCustomerCsvFileWriter(fileSystem);


        //act
        sut.Write("cust.csv", new List<Customer> { customer1, customer2 });

        //assert
        fileSystem.Received(1).WriteLine("cust.csv", "Brandon Clark,11111111");
        fileSystem.Received(1).WriteLine("cust.csv", "Daniel Tsyplenkov,87654321");
    }

    [Test]
    public void Write_GivenThreeCustomers_ShouldWriteAllCustomersDataAsCSVLinesToProvidedFile()
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
        fileSystem.Received(1).WriteLine("cust1.csv", "Bob Burger,8384934");
        fileSystem.Received(1).WriteLine("cust1.csv", "Daniel San,3213512");
        fileSystem.Received(1).WriteLine("cust1.csv", "Bang Bang,3241232");
    }


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


using System.Diagnostics;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorKataTests
{
    //1. Strictly practice TDD: Red, Green, Refactor
    //2. Clean Code is required:
    //2.1. Intention-revealing names
    //2.2. DRY
    //2.3. SOLID
    //3. No use of the debugger or Console.Write or Console.WriteLine is allowed. 3.1. Make use of a learning test to focus on the troublesome code.

    [TestFixture]
    public class StringCalculatorTest
    {
        [TestCase("",0)]
        [TestCase("     ", 0)]
        [TestCase("           ", 0)]
        public void Add_GivenEmptyString_ShouldReturn0(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Assign
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_GivenSingleNumber_ShouldReturnThatNumber(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Assign
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1,2", 3)]
        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        public void Add_GivenUnknownCommaSeperatedNumbers_ShouldReturnSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Assign
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1\n2", 3)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2,3\n4", 10)]
        public void Add_GivenUnknownCommaOrNewLineSeperatedNumbers_ShouldReturnSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Assign
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestCase("//;\n1//2", 3)]
        [TestCase("//*\n1\n2*3", 6)]
        [TestCase("//*\n1,2,3,4", 10)]
        public void Add_GivenDeliminatorAndUknownNumbers_ShouldReturnSumOfNumbers(string numbers, int expected)
        {
            //Arrange
            var sut = new StringCalculator();

            //Assign
            var actual = sut.Add(numbers);

            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
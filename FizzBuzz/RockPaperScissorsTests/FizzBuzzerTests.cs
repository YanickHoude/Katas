using NUnit.Framework;
using FizzBuzz;
using System;

//1. You can only write production code to make a failing unit test pass
//2. You cannot write anymore of a unit test if its failing already
//3. You can only write production code that is sufficient to pass one failing unit test

//RED --> GREEN --> Read & Reflect --> Refactor

namespace FizzBuzzTests
{
    [TestFixture]
    public class FizzBuzzerTests
    {
        [TestFixture]
        public class Go
        {
            [TestFixture]
            public class WhenDivisibleBy3
            {
                [TestCase(6, "Fizz")]
                [TestCase(9, "Fizz")]
                public void ShouldReturnFizz(int num, string expected)
                {
                    //arrange
                    var sut = new FizzBuzzer();

                    //act
                    var actual = sut.Go(num);

                    //assert
                    Assert.AreEqual(expected, actual);
                }
            }

            [TestFixture]
            public class WhenDivisibleBy5
            {
                [TestCase(10, "Buzz")]
                [TestCase(20, "Buzz")]
                public void ShouldReturnBuzz(int num, string expected)
                {
                    //arrange
                    var sut = new FizzBuzzer();

                    //act
                    var actual = sut.Go(num);

                    //assert
                    Assert.AreEqual(expected, actual);
                }
            }

            [TestFixture]
            public class WhenDivisibleBy3and5
            {
                [TestCase(15, "FizzBuzz")]
                [TestCase(30, "FizzBuzz")]
                [TestCase(75, "FizzBuzz")]
                public void ShouldReturnFizzBuzz(int num, string expected)
                {
                    //arrange
                    var sut = new FizzBuzzer();

                    //act
                    var actual = sut.Go(num);

                    //assert
                    Assert.AreEqual(expected, actual);
                }
            }

            [TestFixture]
            public class WhenDivisibleBy3andPrime
            {
                [TestCase(3, "FizzWhizz")]
                public void ShouldReturnFizzWhizz(int num, string expected)
                {
                    //arrange
                    var sut = new FizzBuzzer();

                    //act
                    var actual = sut.Go(num);

                    //assert
                    Assert.AreEqual(expected, actual);
                }
            }

            [TestFixture]
            public class WhenDivisibleBy5andPrime
            {
                [TestCase(5, "BuzzWhizz")]
                public void ShouldReturnFizzWhizz(int num, string expected)
                {
                    //arrange
                    var sut = new FizzBuzzer();

                    //act
                    var actual = sut.Go(num);

                    //assert
                    Assert.AreEqual(expected, actual);
                }
            }

            [TestFixture]
            public class WhenNotDivisibleBy3or5andNotPrime
            {
                [TestCase(4, 4)]
                public void ShouldReturnNumber(int num, int expected)
                {
                    //arrange
                    var sut = new FizzBuzzer();

                    //act
                    var actual = sut.Go(num);

                    //assert
                    Assert.AreEqual(expected, actual);
                }
            }

        }

    }
}
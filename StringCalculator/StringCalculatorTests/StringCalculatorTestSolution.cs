using System;
using NUnit.Framework;
using StringCalculatorKata;


namespace StringCalculatorKataTests
{
    [TestFixture]
    public class StringCalculatorTestSolution
    {
        public class Add
        {

            public class NoNumbers
            {

                [TestCase("", 0)]
                [TestCase("    ", 0)]
                [TestCase(null, 0)]
                public void ShouldReturn0(string numbers, int expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assing
                    var actual = sut.Add(numbers);

                    //assert
                    Assert.AreEqual(actual, expected);

                }
            }

            public class OneNumber
            {
                [TestCase("0", 0)]
                [TestCase("1", 1)]
                [TestCase("1", 1)]
                public void ShouldReturnThatNumber(string numbers, int expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assing
                    var actual = sut.Add(numbers);

                    //assert
                    Assert.AreEqual(actual, expected);

                }
            }

            public class ManyNumbers
            {
                [TestCase("1,2,3,4", 10)]
                [TestCase("1,2", 3)]
                [TestCase("5,15,20", 40)]
                public void ShouldReturnSumOfThoseNumbers(string numbers, int expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assing
                    var actual = sut.Add(numbers);

                    //assert
                    Assert.AreEqual(actual, expected);

                }

                [TestCase("1\n2,3,4", 10)]
                [TestCase("1\n2", 3)]
                [TestCase("5\n15\n20", 40)]
                public void SeperatedByNewLine_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assing
                    var actual = sut.Add(numbers);

                    //assert
                    Assert.AreEqual(actual, expected);

                }

            }

            public class CustomDelimiter
            {
                [TestCase("//;\n1;2", 3)]
                [TestCase("//}\n1}2}3}4", 10)]
                [TestCase("//;\n1,256", 257)]
                public void SeperatedByNewLine_ShouldReturnSumOfThoseNumbers(string numbers, int expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assing
                    var actual = sut.Add(numbers);

                    //assert
                    Assert.AreEqual(actual, expected);

                }
            }

            public class NegativeNumbers
            {
                //[Ignore("backout")] --> ignore the test
                [TestCase("-1", "negatives are not allowed: -1")]
                [TestCase("-1,10", "negatives are not allowed: -1")]
                public void OneNegative_ShouldThrowException(string numbers, string expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assign
                    var exception = Assert.Throws<Exception>(() => sut.Add(numbers));

                    //assert
                    Assert.IsNotNull(exception);
                    Assert.AreEqual(expected, exception?.Message);

                }

                [TestCase("-1,-10", "negatives are not allowed: -1,-10")]
                [TestCase("-1,-10,-60", "negatives are not allowed: -1,-10,-60")]
                [TestCase("-1,10,-10,-60", "negatives are not allowed: -1,-10,-60")]

                public void ManyNegativeNumbers_ShouldThrowException(string numbers, string expected)
                {
                    //arrange
                    var sut = CreateStringCalculator();

                    //assign
                    var exception = Assert.Throws<Exception>(() => sut.Add(numbers));

                    //assert
                    Assert.IsNotNull(exception);
                    Assert.AreEqual(expected, exception?.Message);

                }
            }

            [Test]
            public void Learning()
            {
                Assert.AreEqual("-1,-10,-60", string.Join(",", new string[] { "-1", "-10", "-60" }));

            }

        }

        private static StringCalculatorSolution CreateStringCalculator()
        {
            return new StringCalculatorSolution();
        }
    }
            
}


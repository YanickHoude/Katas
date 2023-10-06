using NUnit.Framework;
using AgeCalculatorKata;


//1. You can only write production code to make a failing unit test pass
//2. You cannot write anymore of a unit test if its failing already
//3. You can only write production code that is sufficient to pass one failing unit test

//RED --> GREEN --> Read & Reflect --> Refactor

//Naming: Meaningless --> Specific --> Meaningful --> General

namespace AgeCalculatorKataTests
{
    [TestFixture]
    public class AgeCalculatorTests
    {
        [TestCase("1996/05/06", "2022/10/10", 26)]
        [TestCase("1997/05/06", "2020/10/10", 23)]
        [TestCase("1996/05/06", "2023/05/06", 27)]
        public void GivenOnOrAfterBirthDate_ShouldReturnDifferenceInYears(DateTime Birth, DateTime Target, int expected)
        {
            //arrange
            var sut = new AgeCalculator();

            //act
            var actual = sut.getAge(Birth, Target);

            //assert
            Assert.AreEqual(expected, actual);

        }

        [TestCase("1996/05/06", "2023/03/03", 26)]
        [TestCase("1996/05/06", "2023/05/03", 26)]
        public void GiveBeforeBirthDate_ShouldReturnDifferenceInYearsMinus1(DateTime Birth, DateTime Target, int expected)
        {
            //arrange
            var sut = new AgeCalculator();

            //act
            var actual = sut.getAge(Birth, Target);

            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}
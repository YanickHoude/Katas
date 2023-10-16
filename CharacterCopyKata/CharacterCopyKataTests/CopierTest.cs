using NSubstitute;
using NUnit.Framework;
using CharacterCopyKata;

namespace CharacterCopyKataTests
{
    //TestDoubles: Fakes, Stubs, Mocks
    //Functionality:
    // - no char before new line
    // - single char before new line (DONE)
    // - two char before new line
    // - many char before new line
    // - repeated char before new line
    // - the order of char before new line
    // - charactres after new line should not be written


    [TestFixture]
    public class CopierTest
    {
        public class Copy
        {
            [TestCase(" ", '\n')]
            [TestCase(null, '\n')]
            [TestCase('\n')]
            public void GivenNoCharBeforeNewLine_ShouldNotWriteChar(char firstChar, params char[] nextChars)
            {
                //arrange
                ISource source = CreateSource(firstChar, nextChars);
                source.ReadChar().Returns('\n');
                IDestination destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(0).WriteChar(Arg.Any<char>()); //make sure nothing was written


            }

            [TestCase('a', '\n')]
            [TestCase('!', '\n')]
            [TestCase('B', '\n')]
            public void GivenSingleCharBeforeNewLine_ShouldWriteThatChar(char firstChar, params char[] nextChars)
            {
                //arrange
                ISource source = CreateSource(firstChar, nextChars);
                source.ReadChar().Returns(firstChar, nextChars);
                IDestination destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(1).WriteChar(firstChar); //make sure we receive the letter 'a'
                destination.Received(1).WriteChar(Arg.Any<char>()); //make sure we only receive one call


            }

            [TestCase('a', 'b', '\n')]
            [TestCase('a', 'A', '\n')]
            [TestCase('B', '!', '\n')]
            public void GivenTwoCharBeforeNewLine_ShouldWriteTwoChar(char firstChar, params char[] nextChars)
            {
                //arrange
                var source = CreateSource(firstChar, nextChars);
                source.ReadChar().Returns(firstChar, nextChars);
                var destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(1).WriteChar(firstChar); //make sure we receive first char
                destination.Received(1).WriteChar(nextChars[0]); //make sure we receive second char
                destination.Received(2).WriteChar(Arg.Any<char>()); //make sure we only receive one call


            }

            [TestCase('a', 'b', '\n')]
            [TestCase('a', 'b', 'c', '\n')]
            [TestCase('B', '!','\n')]
            public void GivenMultipleCharBeforeNewLine_ShouldWriteThoseChar(char firstChar, params char[] nextChars)
            {
                //arrange
                var source = CreateSource(firstChar, nextChars);
                source.ReadChar().Returns(firstChar, nextChars);
                var destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(1).WriteChar(firstChar); //make sure we receive the let
                destination.Received(1).WriteChar(Arg.Any<char>()); //make sure we only receive one call


            }

            public ISource CreateSource(char firstChar, char[] nextChars)
            {
                var source = Substitute.For<ISource>();
                return source;
            }

            public IDestination CreateDestination()
            {
                return Substitute.For<IDestination>();
            }
        }

    }
}


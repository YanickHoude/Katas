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
            [Test]
            public void GivenNoCharBeforeNewLine_ShouldNotWriteChar()
            {
                //arrange
                var source = CreateSource('\n');
                var destination = CreateDestination();  
                var sut = CreateSut(source, destination);

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
                var source = CreateSource(firstChar, nextChars);
                var destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(1).WriteChar(firstChar); //make sure we receive the letter 'a'
                destination.Received(1).WriteChar(Arg.Any<char>()); //make sure we only receive one call
            }

            [Test]
            public void GivenTwoCharBeforeNewLine_ShouldWriteTwoChar()
            {
                //arrange
                var source = CreateSource('x','y','\n');
                var destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(2).WriteChar(Arg.Any<char>()); //make sure we only receive one call
                destination.Received(1).WriteChar('x'); //make sure we receive first char
                destination.Received(1).WriteChar('y'); //make sure we receive second char
                


            }

            [Test]
            public void GivenMultipleCharBeforeNewLine_ShouldWriteThoseChar()
            {
                //arrange
                var source = CreateSource('x', 'y', 'a', 'b', '\n');
                var destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(4).WriteChar(Arg.Any<char>()); //make sure we only receive one call
                destination.Received(1).WriteChar('x'); //make sure we receive first char
                destination.Received(1).WriteChar('y'); //make sure we receive second char
                destination.Received(1).WriteChar('a'); //make sure we receive third char
                destination.Received(1).WriteChar('b'); //make sure we receive fourth char
            }

            [Test]
            public void ShouldWriteThoseCharInOrder()
            {
                //arrange
                var source = CreateSource('x', 'y', 'a', 'b', '\n');
                var destination = CreateDestination();
                var sut = new Copier(source, destination);

                //act
                sut.Copy();

                //assert
                NSubstitute.Received.InOrder(() =>
                {
                    destination.WriteChar('x');
                    destination.WriteChar('y');
                    destination.WriteChar('a');
                    destination.WriteChar('b');
                });


                destination.Received(4).WriteChar(Arg.Any<char>()); //make sure we only receive one call
                destination.Received(1).WriteChar('x'); //make sure we receive first char
                destination.Received(1).WriteChar('y'); //make sure we receive second char
                destination.Received(1).WriteChar('a'); //make sure we receive third char
                destination.Received(1).WriteChar('b'); //make sure we receive fourth char
            }

            [Test]
            public void AfterNewLine_GivenAnyCharacters_NothingWasWritten()
            {
                //arrange
                var source = CreateSource('\n', 'a', 'b','c');
                var destination = CreateDestination();
                var sut = CreateSut(source, destination);

                //act
                sut.Copy();

                //assert
                destination.Received(0).WriteChar(Arg.Any<char>()); //make sure nothing was written
            }

            public ISource CreateSource(char firstChar, params char[] nextChars)
            {
                var source = Substitute.For<ISource>();
                source.ReadChar().Returns(firstChar, nextChars);
                return source;
            }

            public IDestination CreateDestination()
            {
                return Substitute.For<IDestination>();
            }

            public Copier CreateSut(ISource source, IDestination destination)
            {
                return new Copier(source, destination);
            }

        }

    }
}


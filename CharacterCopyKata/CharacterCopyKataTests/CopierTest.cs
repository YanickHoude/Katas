using NSubstitute;
using NUnit.Framework;

namespace CharacterCopyKataTests
{
    //TestDoubles: Fakes, Stubs, Mocks

    [TestFixture]
    public class CopierTest
    {
        [Test]
        public void Copy_Given_Should(char firstChar, char nextChars)
        {
            //arrange
            var source = Substitute.For<ISource>();
            source.ReadChar().Returns(firstChar,nextChars);

            var destination = Substitute.For<IDestination>();

            var sut = new Copier(source, destination);

            //act
            sut.Copy();

            //assert
            destination.Received(1).WriteChar('a'); //make sure we receive the letter 'a'
            destination.Received(1).WriteChar(Arg.Any<char>()); //make sure we only receive one call


        }

        //[Test]
        //public void Learning()
        //{
        //    var source = Substitute.For<ISource>();
        //    source.ReadChar().Returns('a', 'b');

        //    var x = source.ReadChar();
        //    var y = source.ReadChar();
        //}
    }

    public class Copier
    {
        private readonly IDestination destination;

        public Copier(ISource source, IDestination destination)
        {
            this.destination = destination;
        }

        public void Copy()
        {
            destination.WriteChar('a');
            //throw new NotImplementedException();
        }
    }

    public interface IDestination
    {
        void WriteChar(char v);
    }

    public interface ISource
    {
        char ReadChar();
    }
}


using NUnit.Framework;
using RockPaperScissors;
using System;

//1. You can only write production code to make a failing unit test pass
//2. You cannot write anymore of a unit test if its failing already
//3. You can only write production code that is sufficient to pass one failing unit test

//RED --> GREEN --> Read & Reflect --> Refactor

namespace RockPaperScissorsTests
{
    [TestFixture]
    public class MatchTests
    {
        [TestFixture]
        public class Play
        {
            [TestFixture]
            public class PaperBeatsRock
            {
                [Test]
                public void GivenPlayerPaper_OpponentRock_ShouldReturnPlayerWins()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Paper, PlayerMoves.Rock);

                    //assert
                    Assert.AreEqual(Outcomes.PlayerWins, actual);

                }

                [Test]
                public void GivenPlayerRock_OpponentPaper_ShouldReturnPlayerLoses()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Rock, PlayerMoves.Paper);

                    //assert
                    Assert.AreEqual(Outcomes.PlayerLoses, actual);

                }

            }

            [TestFixture]
            public class RockBeatsScissors
            {
                [Test]
                public void GivenPlayerRock_OpponentScissors_ShouldReturnPlayerWins()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Rock, PlayerMoves.Scissors);

                    //assert
                    Assert.AreEqual(Outcomes.PlayerWins, actual);

                }

                [Test]
                public void GivenPlayerScissors_OpponentRock_ShouldReturnPlayerLoses()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Scissors, PlayerMoves.Rock);

                    //assert
                    Assert.AreEqual(Outcomes.PlayerLoses, actual);

                }
            }

            [TestFixture]
            public class ScissorsBeatsPaper
            {
                [Test]
                public void GivenPlayerPaper_OpponentScissors_ShouldReturnPlayerLoses()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Paper, PlayerMoves.Scissors);

                    //assert
                    Assert.AreEqual(Outcomes.PlayerLoses, actual);

                }

                [Test]
                public void GivenPlayerScissors_OpponentPaper_ShouldReturnPlayerWins()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Scissors, PlayerMoves.Paper);

                    //assert
                    Assert.AreEqual(Outcomes.PlayerWins, actual);

                }
            }


            [TestFixture]
            public class SameMovesTie
            {
                [Test]
                public void GivenPlayerPaper_OpponenetPaper_ShouldReturnTie()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Paper, PlayerMoves.Paper);

                    //assert
                    Assert.AreEqual(Outcomes.Tie, actual);

                }

                [Test]
                public void GivenPlayerRock_OpponenetRock_ShouldReturnTie()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Rock, PlayerMoves.Rock);

                    //assert
                    Assert.AreEqual(Outcomes.Tie, actual);

                }

                [Test]
                public void GivenPlayerScissors_OpponenetScissors_ShouldReturnTie()
                {
                    //arrange
                    var sut = StartMatch();

                    //act
                    var actual = sut.Play(PlayerMoves.Scissors, PlayerMoves.Scissors);

                    //assert
                    Assert.AreEqual(Outcomes.Tie, actual);

                }
            }

        }
       

        public static Match StartMatch()
        {
            return new Match();
        }

    }

}
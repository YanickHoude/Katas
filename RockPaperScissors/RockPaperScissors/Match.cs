using System;
using System.Collections.Generic;

namespace RockPaperScissors
{

    //this is the production code
    public class Match
    {
        private List<(PlayerMoves, PlayerMoves)> wins = new()
        {
            (PlayerMoves.Rock,PlayerMoves.Scissors),
            (PlayerMoves.Paper, PlayerMoves.Rock),
            (PlayerMoves.Scissors, PlayerMoves.Paper),
        };

        public object Play(PlayerMoves playerMove, PlayerMoves opponentMove)
        {
            //tie
            if (playerMove == opponentMove)
                return Outcomes.Tie;

            //Wins
            if (wins.Contains((playerMove, opponentMove)))
                return Outcomes.PlayerWins;

            //Loses
            return Outcomes.PlayerLoses;
        }
    }

    public enum PlayerMoves
    {
        Paper,
        Rock,
        Scissors
    }

    public enum Outcomes
    {
        PlayerLoses,
        PlayerWins,
        Tie
    }
}

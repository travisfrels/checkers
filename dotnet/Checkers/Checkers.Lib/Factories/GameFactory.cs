using Checkers.Lib.Models;

namespace Checkers.Lib.Factories
{
    public static class GameFactory
    {
        public const int NUM_SQUARES = 100;
        public const int NUM_CHECKERS = 40;

        public static Game CreateGame()
        {
            var game = new Game
            {
                Board = BoardFactory.CreateBoard(NUM_SQUARES),
                Checkers = CheckerFactory.CreateCheckers(NUM_CHECKERS),
                Player1 = PlayerFactory.CreatePlayer(Game.PLAYER_1_ID),
                Player2 = PlayerFactory.CreatePlayer(Game.PLAYER_2_ID)
            };

            game.Board.Squares[1].CheckerID = 0;
            game.Board.Squares[3].CheckerID = 1;
            game.Board.Squares[5].CheckerID = 2;
            game.Board.Squares[7].CheckerID = 3;
            game.Board.Squares[9].CheckerID = 4;
            game.Board.Squares[10].CheckerID = 5;
            game.Board.Squares[12].CheckerID = 6;
            game.Board.Squares[14].CheckerID = 7;
            game.Board.Squares[16].CheckerID = 8;
            game.Board.Squares[18].CheckerID = 9;
            game.Board.Squares[21].CheckerID = 10;
            game.Board.Squares[23].CheckerID = 11;
            game.Board.Squares[25].CheckerID = 12;
            game.Board.Squares[27].CheckerID = 13;
            game.Board.Squares[29].CheckerID = 14;
            game.Board.Squares[30].CheckerID = 15;
            game.Board.Squares[32].CheckerID = 16;
            game.Board.Squares[34].CheckerID = 17;
            game.Board.Squares[36].CheckerID = 18;
            game.Board.Squares[38].CheckerID = 19;

            game.Board.Squares[61].CheckerID = 20;
            game.Board.Squares[63].CheckerID = 21;
            game.Board.Squares[65].CheckerID = 22;
            game.Board.Squares[67].CheckerID = 23;
            game.Board.Squares[69].CheckerID = 24;
            game.Board.Squares[70].CheckerID = 25;
            game.Board.Squares[72].CheckerID = 26;
            game.Board.Squares[74].CheckerID = 27;
            game.Board.Squares[76].CheckerID = 28;
            game.Board.Squares[78].CheckerID = 29;
            game.Board.Squares[81].CheckerID = 30;
            game.Board.Squares[83].CheckerID = 31;
            game.Board.Squares[85].CheckerID = 32;
            game.Board.Squares[87].CheckerID = 33;
            game.Board.Squares[89].CheckerID = 34;
            game.Board.Squares[90].CheckerID = 35;
            game.Board.Squares[92].CheckerID = 36;
            game.Board.Squares[94].CheckerID = 37;
            game.Board.Squares[96].CheckerID = 38;
            game.Board.Squares[98].CheckerID = 39;

            game.ActivePlayerId = 1;

            return game;
        }
    }
}

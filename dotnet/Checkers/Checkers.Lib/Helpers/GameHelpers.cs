using Checkers.Lib.Enum;
using Checkers.Lib.Models;
using System.Linq;

namespace Checkers.Lib.Helpers
{
    public static class GameHelpers
    {
        public const int PLAYER_1_KING_ROW = 9;
        public const int PLAYER_2_KING_ROW = 0;

        public static Game ApplyMove(this Game game, Move move)
        {
            if (!game.IsValidMove(move)) { return game; }

            var clone = game.Clone();

            var checkerSquare = clone.Board.GetSquareByChecker(move.CheckerID);

            Square landSquare = null;
            Square captureSquare = null;

            switch (move.MoveType)
            {
                case MoveType.Slide:
                    landSquare = clone.Board.GetNextSquareInDirection(checkerSquare, move.MoveDirection);
                    break;
                case MoveType.Jump:
                    captureSquare = clone.Board.GetNextSquareInDirection(checkerSquare, move.MoveDirection);
                    landSquare = clone.Board.GetNextSquareInDirection(captureSquare, move.MoveDirection);
                    break;
            }

            landSquare.CheckerID = move.CheckerID;
            checkerSquare.CheckerID = Square.EMPTY;

            if (captureSquare != null)
            {
                var player = game.GetPlayerById(move.PlayerID);
                player.Captures = player.Captures.Append(captureSquare.CheckerID).ToArray();
                captureSquare.CheckerID = Square.EMPTY;
            }

            if (clone.CanKingChecker(move.CheckerID))
            {
                clone.Checkers[move.CheckerID].IsKing = true;
            }

            if (move.MoveType == MoveType.Jump && clone.GetJumpMovesForPlayerAndChecker(move.PlayerID, move.CheckerID).Any())
            {
                clone.ActivePlayerId = move.PlayerID;
            }
            else
            {
                clone.ActivePlayerId = (clone.ActivePlayerId == clone.Player1.ID) ? clone.Player2.ID : clone.Player1.ID;
            }

            return clone;
        }

        public static bool IsValidMove(this Game game, Move move)
        {
            if (game == null || game.Board == null || move == null) { return false; }

            if (move.PlayerID != Game.PLAYER_1_ID && move.PlayerID != Game.PLAYER_2_ID) { return false; }
            if (move.PlayerID != game.ActivePlayerId) { return false; }

            if (move.CheckerID < Game.MIN_CHECKER_ID || move.CheckerID > Game.MAX_CHECKER_ID) { return false; }

            var player = game.GetPlayerById(move.PlayerID);
            if (player == null) { return false; }

            if (!player.OwnsChecker(move.CheckerID)) { return false; }

            var checkersSquare = game.Board.GetSquareByChecker(move.CheckerID);
            if (checkersSquare == null) { return false; }

            Square landSquare = null;

            if (move.MoveType == MoveType.Slide)
            {
                landSquare = game.Board.GetNextSquareInDirection(checkersSquare, move.MoveDirection);
            }

            if (move.MoveType == MoveType.Jump)
            {
                var captureSquare = game.Board.GetNextSquareInDirection(checkersSquare, move.MoveDirection);
                if (captureSquare == null) { return false; }
                if (captureSquare.IsEmpty()) { return false; }
                if (player.OwnsChecker(captureSquare.CheckerID)) { return false; }

                landSquare = game.Board.GetNextSquareInDirection(captureSquare, move.MoveDirection);
            }

            if (landSquare == null) { return false; }

            return landSquare.CanPlaceChecker();
        }

        public static Game Clone(this Game game)
        {
            if (game == null) { return game; }

            return new Game
            {
                Board = game.Board.Clone(),
                Checkers = game.Checkers.Select(checker => checker.Clone()).ToArray(),
                Player1 = game.Player1.Clone(),
                Player2 = game.Player2.Clone(),
                ActivePlayerId = game.ActivePlayerId
            };
        }

        public static Player GetPlayerById(this Game game, int playerId)
        {
            if (game == null || game.Player1 == null || game.Player2 == null) { return null; }
            return game.Player1.ID == playerId ? game.Player1 : game.Player2;
        }

        public static bool CanKingChecker(this Game game, int checkerId)
        {
            if (game == null || game.Board == null || game.Player1 == null || game.Player2 == null) { return false; }

            if (checkerId < Game.MIN_CHECKER_ID || checkerId > Game.MAX_CHECKER_ID) { return false; }

            var coordinate = game.Board.GetCoordinateOfSquare(game.Board.GetSquareByChecker(checkerId));
            if (coordinate == null) { return false; }

            if (game.Player1.OwnsChecker(checkerId) && coordinate.Row == PLAYER_1_KING_ROW) { return true; }
            if (game.Player2.OwnsChecker(checkerId) && coordinate.Row == PLAYER_2_KING_ROW) { return true; }

            return false;
        }

        public static Move[] GetJumpMovesForPlayerAndChecker(this Game game, int playerId, int checkerId)
        {
            if (!game.IsPlayersChecker(playerId, checkerId)) { return new Move[0]; }

            if (game.Checkers[checkerId].IsKing)
            {
                return new Move[]
                {
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.NorthEast, CheckerID = checkerId },
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.NorthWest, CheckerID = checkerId },
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.SouthWest, CheckerID = checkerId },
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.SouthEast, CheckerID = checkerId }
                };
            }

            if (playerId == Game.PLAYER_1_ID)
            {
                return new Move[]
                {
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.SouthWest, CheckerID = checkerId },
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.SouthEast, CheckerID = checkerId }
                };
            }

            if (playerId == Game.PLAYER_2_ID)
            {
                return new Move[]
                {
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.NorthEast, CheckerID = checkerId },
                    new Move { PlayerID = playerId, MoveType = MoveType.Jump, MoveDirection = MoveDirection.NorthWest, CheckerID = checkerId },
                };
            }

            return new Move[0];
        }

        public static bool IsPlayersChecker(this Game game, int playerId, int checkerId)
        {
            if (game == null || game.Board == null) { return false; }
            if (playerId != Game.PLAYER_1_ID && playerId != Game.PLAYER_2_ID) { return false; }
            if (checkerId < Game.MIN_CHECKER_ID || checkerId > Game.MAX_CHECKER_ID) { return false; }

            var player = game.GetPlayerById(playerId);
            if (player == null) { return false; }

            if (!game.Board.HasChecker(checkerId)) { return false; }
            if (!player.OwnsChecker(checkerId)) { return false; }

            return true;
        }
    }
}

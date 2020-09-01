using Checkers.Lib.Models;

namespace Checkers.Lib.Helpers
{
    public static class SquareHelpers
    {
        public static bool IsPlayable(this Square square)
        {
            if (square == null) { return false; }
            return square.CheckerID != Square.NOT_PLAYABLE;
        }

        public static bool IsEmpty(this Square square)
        {
            if (square == null) { return true; }
            return square.CheckerID == Square.EMPTY;
        }

        public static bool CanPlaceChecker(this Square square)
        {
            return square.IsPlayable() && square.IsEmpty();
        }

        public static bool HasChecker(this Square square, int checkerId)
        {
            return square.IsPlayable() && !square.IsEmpty() && square.CheckerID == checkerId;
        }

        public static Square Clone(this Square square)
        {
            if (square == null) { return square; }
            return new Square
            {
                CheckerID = square.CheckerID
            };
        }
    }
}

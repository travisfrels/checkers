using Checkers.Lib.Models;

namespace Checkers.Lib.Factories
{
    public static class SquareFactory
    {
        public const int MIN_INDEX = 0;
        public const int MAX_INDEX = 99;

        public static bool IsIndexPlayable(int index)
        {
            if (index < MIN_INDEX || index > MAX_INDEX) { return false; }

            var coordinate = CoordinateFactory.CreateCoordinateFromIndex(index);
            if (coordinate.Row % 2 == 0)
            {
                if (coordinate.Column % 2 == 0) { return false; }
                return true;
            }

            if (coordinate.Column % 2 == 0) { return true; }
            return false;
        }

        public static Square CreateSquareFromIndex(int index)
        {
            return new Square
            {
                CheckerID = IsIndexPlayable(index) ? Square.EMPTY : Square.NOT_PLAYABLE
            };
        }
    }
}

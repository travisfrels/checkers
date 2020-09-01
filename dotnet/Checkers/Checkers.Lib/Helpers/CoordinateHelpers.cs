using Checkers.Lib.Enum;
using Checkers.Lib.Factories;
using Checkers.Lib.Models;

namespace Checkers.Lib.Helpers
{
    public static class CoordinateHelpers
    {
        public static Coordinate TranslateNorthEast(this Coordinate coordinate)
        {
            if (coordinate == null) { return null; }
            return CoordinateFactory.CreateCoordinateFromRowAndColumn(coordinate.Row - 1, coordinate.Column + 1);
        }

        public static Coordinate TranslateNorthWest(this Coordinate coordinate)
        {
            if (coordinate == null) { return null; }
            return CoordinateFactory.CreateCoordinateFromRowAndColumn(coordinate.Row - 1, coordinate.Column - 1);
        }

        public static Coordinate TranslateSouthWest(this Coordinate coordinate)
        {
            if (coordinate == null) { return null; }
            return CoordinateFactory.CreateCoordinateFromRowAndColumn(coordinate.Row + 1, coordinate.Column - 1);
        }

        public static Coordinate TranslateSouthEast(this Coordinate coordinate)
        {
            if (coordinate == null) { return null; }
            return CoordinateFactory.CreateCoordinateFromRowAndColumn(coordinate.Row + 1, coordinate.Column + 1);
        }

        public static Coordinate Translate(this Coordinate coordinate, MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.NorthEast:
                    return coordinate.TranslateNorthEast();
                case MoveDirection.NorthWest:
                    return coordinate.TranslateNorthWest();
                case MoveDirection.SouthWest:
                    return coordinate.TranslateSouthWest();
                case MoveDirection.SouthEast:
                    return coordinate.TranslateSouthEast();
            }
            return null;
        }
    }
}

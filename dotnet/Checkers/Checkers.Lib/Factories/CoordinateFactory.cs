using Checkers.Lib.Models;

namespace Checkers.Lib.Factories
{
    public static class CoordinateFactory
    {
        public static int GetRowFromIndex(int index)
        {
            if (index < 0 || index > 99) { return -1; }
            return index / 10;
        }

        public static int GetColumnFromIndex(int index)
        {
            if (index < 0 || index > 99) { return -1; }
            return index % 10;
        }

        public static int GetIndexFromRowAndColumn(int row, int column)
        {
            if (row < 0 || row > 9) { return -1; }
            if (column < 0 || column > 9) { return -1; }
            return (row * 10) + column;
        }

        public static Coordinate CreateCoordinateFromIndex(int index)
        {
            return new Coordinate
            {
                Row = GetRowFromIndex(index),
                Column = GetColumnFromIndex(index),
                Index = index
            };
        }

        public static Coordinate CreateCoordinateFromRowAndColumn(int row, int column)
        {
            return new Coordinate
            {
                Row = row,
                Column = column,
                Index = GetIndexFromRowAndColumn(row, column)
            };
        }
    }
}

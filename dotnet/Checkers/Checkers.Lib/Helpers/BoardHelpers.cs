using Checkers.Lib.Enum;
using Checkers.Lib.Factories;
using Checkers.Lib.Models;
using System;
using System.Linq;

namespace Checkers.Lib.Helpers
{
    public static class BoardHelpers
    {
        public static bool HasChecker(this Board board, int checkerId)
        {
            if (board == null || board.Squares == null) { return false; }
            return board.Squares.Any(square => square.HasChecker(checkerId));
        }

        public static Square GetSquareByChecker(this Board board, int checkerId)
        {
            if (!board.HasChecker(checkerId)) { return null; }
            return board.Squares.First(square => square.HasChecker(checkerId));
        }

        public static int GetIndexOfSquare(this Board board, Square square)
        {
            if (board == null || square == null) { return -1; }
            return Array.IndexOf(board.Squares, square);
        }

        public static Coordinate GetCoordinateOfSquare(this Board board, Square square)
        {
            return CoordinateFactory.CreateCoordinateFromIndex(board.GetIndexOfSquare(square));
        }

        public static Square GetSquareByCoordinate(this Board board, Coordinate coordinate)
        {
            if (board == null || board.Squares == null || coordinate == null) { return null; }
            return board.Squares[coordinate.Index];
        }

        public static Square GetNextSquareInDirection(this Board board, Square square, MoveDirection moveDirection)
        {
            return board.GetSquareByCoordinate(board.GetCoordinateOfSquare(square).Translate(moveDirection));
        }

        public static Board Clone(this Board board)
        {
            if (board == null) { return null; }
            return new Board
            {
                Squares = board.Squares.Select(square => square.Clone()).ToArray()
            };
        }
    }
}

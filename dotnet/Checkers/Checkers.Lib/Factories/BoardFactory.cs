using Checkers.Lib.Models;
using System.Linq;

namespace Checkers.Lib.Factories
{
    public static class BoardFactory
    {
        public static Board CreateBoard(int numSquares)
        {
            return new Board
            {
                Squares = Enumerable
                    .Range(0, numSquares)
                    .Select(i => SquareFactory.CreateSquareFromIndex(i))
                    .ToArray()
            };
        }
    }
}

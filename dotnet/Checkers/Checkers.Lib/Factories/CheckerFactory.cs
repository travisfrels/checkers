using Checkers.Lib.Models;
using System.Linq;

namespace Checkers.Lib.Factories
{
    public static class CheckerFactory
    {
        public static Checker[] CreateCheckers(int numCheckers)
        {
            return Enumerable
                .Range(0, numCheckers)
                .Select(i => new Checker { IsKing = false })
                .ToArray();
        }
    }
}

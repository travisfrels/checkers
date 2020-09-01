using Checkers.Lib.Models;

namespace Checkers.Lib.Helpers
{
    public static class CheckerHelpers
    {
        public static Checker Clone(this Checker checker)
        {
            if (checker == null) { return checker; }
            return new Checker { IsKing = checker.IsKing };
        }
    }
}

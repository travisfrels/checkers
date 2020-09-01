using Checkers.Lib.Models;
using System.Linq;

namespace Checkers.Lib.Helpers
{
    public static class PlayerHelpers
    {
        public static bool OwnsChecker(this Player player, int checkerId)
        {
            if (player == null) { return false; }
            return (player.ID == 1 && checkerId >= 0 && checkerId <= 19) || (player.ID == 2 && checkerId >= 20 && checkerId <= 39);
        }

        public static bool HasCapturedChecker(this Player player, int checkerId)
        {
            if (player == null || player.Captures == null) { return false; }
            return player.Captures.Any(x => x == checkerId);
        }

        public static bool CanCaptureChecker(this Player player, int checkerId)
        {
            if (player.OwnsChecker(checkerId) || player.HasCapturedChecker(checkerId)) { return false; }
            return true;
        }

        public static Player Clone(this Player player)
        {
            if (player == null) { return player; }

            return new Player
            {
                ID = player.ID,
                Captures = (int[])player.Captures.Clone()
            };
        }
    }
}

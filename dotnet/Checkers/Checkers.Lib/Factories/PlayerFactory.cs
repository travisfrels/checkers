using Checkers.Lib.Models;

namespace Checkers.Lib.Factories
{
    public static class PlayerFactory
    {
        public static Player CreatePlayer(int playerId)
        {
            return new Player
            {
                ID = playerId,
                Captures = new int[0]
            };
        }
    }
}

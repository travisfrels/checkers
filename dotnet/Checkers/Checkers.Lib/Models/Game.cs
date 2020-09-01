namespace Checkers.Lib.Models
{
    public class Game
    {
        public const int PLAYER_1_ID = 1;
        public const int PLAYER_2_ID = 2;

        public const int MIN_CHECKER_ID = 0;
        public const int MAX_CHECKER_ID = 39;

        public Board Board { get; set; }
        public Checker[] Checkers { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public int ActivePlayerId { get; set; }
    }
}

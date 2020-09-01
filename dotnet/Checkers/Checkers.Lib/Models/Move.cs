using Checkers.Lib.Enum;

namespace Checkers.Lib.Models
{
    public class Move
    {
        public int PlayerID { get; set; }
        public MoveType MoveType { get; set; }
        public MoveDirection MoveDirection { get; set; }
        public int CheckerID { get; set; }
    }
}

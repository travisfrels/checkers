using Checkers.Lib.Enum;
using Checkers.Lib.Factories;
using Checkers.Lib.Helpers;
using Checkers.Lib.Models;
using System;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = GameFactory.CreateGame();
            var quit = false;
            while(!quit)
            {
                Console.WriteLine($"Enter move for player {game.ActivePlayerId}");
                var command = Console.ReadLine();
                if (string.Compare(command, "quit", true) == 0) { quit = true; }
                else { game = game.ApplyMove(new Move { PlayerID = game.ActivePlayerId, CheckerID = 15, MoveType = MoveType.Slide, MoveDirection = MoveDirection.SouthEast }); }
            }
        }
    }
}

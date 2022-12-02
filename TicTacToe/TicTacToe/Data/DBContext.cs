using TicTacToe.Account;
using TicTacToe.Games;

namespace TicTacToe.Data
{
    internal static class DbContext
    {
        public static readonly List<GameAccount> Users = new();
        public static readonly List<Game> Histories = new();
        public static readonly Queue<Game> GameQueue = new();
    }
}
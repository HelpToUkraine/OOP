using Newtonsoft.Json;
using TicTacToe.Account;
using TicTacToe.Games;
using static System.IO.File;

namespace TicTacToe.Data
{
    internal static class DbContext
    {
        private static readonly JsonSerializerSettings Settings = DataSerialize.Settings;
        private const string AccountPath = DataSerialize.AccountPath;
        private const string GamePath = DataSerialize.GamePath;

        public static readonly List<GameAccount> Users = new();
        public static readonly List<Game> Histories = new();

        static DbContext()
        {
            try
            {
                Users = JsonConvert.DeserializeObject<List<GameAccount>>(ReadAllText(AccountPath), Settings)
                        ?? new List<GameAccount>();
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                Histories = JsonConvert.DeserializeObject<List<Game>>(ReadAllText(GamePath), Settings)
                            ?? new List<Game>();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
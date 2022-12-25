using TicTacToe.Data;
using TicTacToe.Account;

namespace TicTacToe.Services
{
    internal static class UserService
    {
        public static void Add(GameAccount user)
        {
            DbContext.Users.Add(user);
        }

        public static List<GameAccount> Get()
        {
            return DbContext.Users;
        }

        public static GameAccount GetByName(string name)
        {
            return DbContext.Users.First(x => x.UserName == name);
        }

        public static bool IsUserExist(string name)
        {
            return DbContext.Users.Exists(x => x.UserName == name);
        }

        public static IEnumerable<string> GetNames()
        {
            return DbContext.Users.Select(x => x.UserName).ToList();
        }

        public static int GetMaxRating()
        {
            return DbContext.Users.Max(x => x.CurrentRating);
        }
    }
}
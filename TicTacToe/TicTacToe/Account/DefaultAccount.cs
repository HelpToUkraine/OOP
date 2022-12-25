using Newtonsoft.Json;
using TicTacToe.Enum;
using TicTacToe.Games;

namespace TicTacToe.Account;

public class DefaultAccount : GameAccount
{
    public DefaultAccount(string userName) : base(userName, AccountType.Default)
    {
    }

    [JsonConstructor]
    public DefaultAccount(string userName, List<HistoryGame> historyGames) : base(userName, AccountType.Default, historyGames)
    {
    }

    protected override int GetBonus(int rating)
    {
        return rating;
    }
}
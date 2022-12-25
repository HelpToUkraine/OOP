using Newtonsoft.Json;
using TicTacToe.Enum;
using TicTacToe.Games;

namespace TicTacToe.Account;

public class VipAccount : GameAccount
{
    public VipAccount(string userName) : base(userName, AccountType.Vip)
    {
    }

    [JsonConstructor]
    public VipAccount(string userName, List<HistoryGame> historyGames) : base(userName, AccountType.Vip, historyGames)
    {
    }

    protected override int GetBonus(int rating)
    {
        return GetWinStreakCount() >= 2 && rating != 0 ? rating + 2 : rating;
    }
}
using Newtonsoft.Json;
using TicTacToe.Enum;
using TicTacToe.Games;

namespace TicTacToe.Account;

public class PremiumAccount : GameAccount
{
    public PremiumAccount(string userName) : base(userName, AccountType.Premium)
    {
    }

    [JsonConstructor]
    public PremiumAccount(string userName, List<HistoryGame> historyGames) : base(userName, AccountType.Premium, historyGames)
    {
    }

    protected override int GetBonus(int rating)
    {
        return GetWinStreakCount() == 0 ? rating : rating * 2; /*if loose rating; else rating*2 */
    }
}
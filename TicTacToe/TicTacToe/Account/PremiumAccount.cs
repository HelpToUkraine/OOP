using TicTacToe.Enum;

namespace TicTacToe.Account;

public class PremiumAccount : GameAccount
{
    public PremiumAccount(string userName) : base(userName, AccountType.Premium)
    {
    }

    protected override int GetBonus(int rating)
    {
        return WinStreakCount == 0 ? rating / 2 : rating * 2; /*if loose rating/2; else rating*2 */
    }
}
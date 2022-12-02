using TicTacToe.Enum;

namespace TicTacToe.Account;

public class VipAccount : GameAccount
{
    public VipAccount(string name) : base(name, AccountType.Vip)
    {
    }


    protected override int GetBonus(int rating)
    {
        return WinStreakCount >= 2 && rating != 0 ? rating + 2 : rating;
    }
}
using TicTacToe.Enum;

namespace TicTacToe.Account;

public class DefaultAccount : GameAccount
{
    public DefaultAccount(string userName) : base(userName, AccountType.Default)
    {
    }

    protected override int GetBonus(int rating)
    {
        return rating;
    }
}
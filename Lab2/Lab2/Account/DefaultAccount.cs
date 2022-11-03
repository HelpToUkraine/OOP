namespace Lab2.Account;

public class DefaultAccount : GameAccount
{
    public DefaultAccount(string userName)
        : base(userName)
    {
    }

    protected override int GetBonus(int rating)
    {
        return rating;
    }
}
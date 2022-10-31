namespace Lab2.Account;

public class Account : GameAccount
{
    public Account(string userName)
        : base(userName)
    {

    }

    public override int GetBonus(int rating)
    {
        return rating;
    }
}
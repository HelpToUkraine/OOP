namespace Lab2.Account;

public class VipAccount : GameAccount
{
    public VipAccount(string name)
        : base(name)
    {

    }

    public override int GetBonus(int rating)
    {
        return WinStreakCount >= 2 ? rating + 2 : rating;
    }

}
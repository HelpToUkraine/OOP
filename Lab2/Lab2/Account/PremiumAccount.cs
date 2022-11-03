namespace Lab2.Account;

public class PremiumAccount : GameAccount
{
    public PremiumAccount(string userName)
        : base(userName)
    {
    }

    protected override int GetBonus(int rating)
    {
        return WinStreakCount == 0 ? rating / 2 : rating * 2; /*if loose rating/2; else rating*2 */
    }
}
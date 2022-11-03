namespace Lab2.Account;

public static class AccountFactory
{
    public static GameAccount CreateDefaultAccount(string userName)
    {
        return new DefaultAccount(userName);
    }

    public static GameAccount CreateVipAccount(string userName)
    {
        return new VipAccount(userName);
    }

    public static GameAccount CreatePremiumAccount(string userName)
    {
        return new PremiumAccount(userName);
    }
}
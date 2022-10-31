namespace Lab2.Account;

public static class AccountFactory
{
    public static GameAccount CreateAccount(string userName)
    {
        return new Account(userName);
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
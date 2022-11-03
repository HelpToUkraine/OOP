using Lab2.Account;
using Lab2.Games;

namespace Lab2;

public static class Run
{
    public static void Main(string[] args)
    {
        var player1 = AccountFactory.CreateDefaultAccount("Kirgo");
        var player2 = AccountFactory.CreateVipAccount("Scam");
        var player3 = AccountFactory.CreatePremiumAccount("Solify");

        var game0 = GameFactory.CreateStandartGame(player1, player2, 3);
        var game1 = GameFactory.CreateStandartGame(player1, player2);
        var game2 = GameFactory.CreateStandartGame(player2, player3);
        var game3 = GameFactory.CreateStandartGame(player3, player2, 2);

        var game4 = GameFactory.CreateTrainGame(player1, player2);
        var game5 = GameFactory.CreateSingleGame(player1, 2);
        var game6 = GameFactory.CreateSingleGame(player3, 4);

        player1.GetStats();
        player2.GetStats();
        player3.GetStats();

        GameAccount.GetAccountsInfo();
    }
}
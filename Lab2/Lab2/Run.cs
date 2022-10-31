using Lab2.Account;
using Lab2.Games;

namespace Lab2;

public static class Run
{
    public static void Main(string[] args)
    {

        var player1 = AccountFactory.CreateAccount("Kirgo");
        var player2 = AccountFactory.CreateVipAccount("Scam");
        var player3 = AccountFactory.CreatePremiumAccount("Solify");


        var game1 = GameFactory.CreateStandartGame(player1, player2);
        var game2 = GameFactory.CreateTrainGame(player1, player2);
        var game3 = GameFactory.CreateSingleGame(player1);
        var game4 = GameFactory.CreateSingleGame(player1);
        var game5 = GameFactory.CreateSingleGame(player1);

        /*var player1 = new GameAccount("Kirgo");
        var player2 = new GameAccount("Scam");
        var player3 = new GameAccount("Solify");*/

        /*var game = new Game(player2, player3, 3);
        var game1 = new Game(player2, player3);
        var game3 = new Game(player2, player3);
        var game4 = new Game(player2, player3);
        var game5 = new Game(player2, player3);
        var game2 = new Game(player2, player3, 4);*/

        player1.GetStats();
        player2.GetStats();

        GameAccount.GetAccountsInfo();

    }

}

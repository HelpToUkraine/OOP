namespace Lab1;

public static class Run
{
    public static void Main(string[] args)
    {
        var player1 = new GameAccount("Kirgo");
        var player2 = new GameAccount("Scam");
        var player3 = new GameAccount("Solify");

        var game = new Game(player1, player2, 3);
        var game1 = new Game(player1, player2);
        var game2 = new Game(player1, player2, 4);

        player1.GetStats();
        player2.GetStats();

        GameAccount.GetAccountsInfo();

    }
}

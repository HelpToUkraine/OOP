using System.Text;
using TicTacToe.Account;
using TicTacToe.Games;
using TicTacToe.Services;

namespace TicTacToe;

public static class Run
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;     /*for print unicode symbols*/

        var player1 = AccountFactory.CreateDefaultAccount("Kirgo");
        var player2 = AccountFactory.CreateVipAccount("Scam");
        var player3 = AccountFactory.CreatePremiumAccount("Solify");

        GameFactory.CreateStandartGame(player1, player2, 6);
        GameFactory.CreateSingleGame(player3, 4);
        GameFactory.CreateTrainGame(player2, player1);
        GameFactory.CreateStandartGame(player2, player3);
        GameFactory.CreateStandartGame(player3, player2, 4);

        Menu();
    }


    private static void Menu()
    {
        while (true)
        {
            Console.Write($"\nChoose what you want to do: \n" +
                          $"1. Start play next game \n" +
                          $"2. Get all games info \n" +
                          $"3. Get all accounts info \n" +
                          $"4. Get all names \n" +
                          $"5. Get max rating \n" +
                          $"6. Get all game ids \n" +
                          $"Other. Exit \n" +
                          $"Your choice: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    try
                    {
                        GameService.GetQueue().Dequeue().Play();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("No games in queue");
                    }
                    break;
                case "2":
                    GameAccount.GetGamesInfo();
                    break;
                case "3":
                    GameAccount.GetAccountsInfo();
                    break;
                case "4":
                    Console.WriteLine("Name accounts: " + string.Join(", ", UserService.GetNames()));
                    break;
                case "5":
                    Console.WriteLine("Max rating from all users: " + UserService.GetMaxRating());
                    break;
                case "6":
                    Console.WriteLine("IDs: " + string.Join(", ", GameService.GetIDs()));
                    break;
                default:
                    Console.WriteLine("Thank you, see you later!");
                    return;
            }
        }
    }
}
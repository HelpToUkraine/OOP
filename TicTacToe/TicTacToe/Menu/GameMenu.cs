using TicTacToe.Account;
using TicTacToe.Data;
using TicTacToe.Games;
using TicTacToe.Services;
namespace TicTacToe.Menu;

public static class GameMenu
{
    public static void Start()
    {
        while (true)
        {
            Console.Write($"\nChoose what you want to do: \n" +
                          $"1. Create new game \n" +
                          $"2. Get all games info \n" +
                          $"3. Get all accounts info \n" +
                          $"4. Get all names \n" +
                          $"5. Get max rating \n" +
                          $"6. Get all game ids \n" +
                          $"7. Create account \n" +
                          $"Other. Exit \n" +
                          $"Your choice: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    label:
                    Console.Write($"\nWhich game do yo want to create: \n" +
                                  $"1. StandartGame\n" +
                                  $"2. TrainGame\n" +
                                  $"3. SingleGame\n" +
                                  $"Your choice: ");

                    var typeGame = Console.ReadLine();
                    GameAccount player;
                    GameAccount opponent;
                    int inputRating;
                    switch (typeGame)
                    {
                        case "1":
                            player = GetAccountForGame();
                            opponent = GetAccountForGame();
                            inputRating = SetOurRating();

                            standart:
                            switch (inputRating)
                            {
                                case int.MaxValue:

                                    GameFactory.CreateStandartGame(player, opponent).Play();
                                    if (Rematch())
                                    {
                                        goto standart;
                                    }
                                    break;

                                default:
                                    GameFactory.CreateStandartGame(player, opponent, inputRating).Play();
                                    if (Rematch())
                                    {
                                        goto standart;
                                    }
                                    break;

                            }

                            break;

                        case "2":
                            player = GetAccountForGame();
                            opponent = GetAccountForGame();

                            training:
                            GameFactory.CreateTrainingGame(player, opponent).Play();
                            if (Rematch())
                            {
                                goto training;
                            }
                            break;

                        case "3":
                            player = GetAccountForGame();
                            inputRating = SetOurRating();

                            singe:
                            switch (inputRating)
                            {
                                case int.MaxValue:
                                    GameFactory.CreateSingleGame(player).Play();
                                    if (Rematch())
                                    {
                                        goto singe;
                                    }
                                    break;

                                default:
                                    GameFactory.CreateSingleGame(player, inputRating).Play();
                                    if (Rematch())
                                    {
                                        goto singe;
                                    }
                                    break;
                            }
                            break;

                        default:
                            Console.WriteLine("Error input, pls try again");
                            goto label;
                    }

                    break;

                case "2":
                    GameAccount.GetGamesInfo();
                    break;
                case "3":
                    GameAccount.GetAccountsInfo();
                    break;
                case "4":
                    Console.WriteLine("\nName accounts: " + string.Join(", ", UserService.GetNames()));
                    break;
                case "5":
                    try
                    {
                        Console.WriteLine("\nMax rating from all users: " + UserService.GetMaxRating());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Don't have any user");
                    }

                    break;
                case "6":
                    Console.WriteLine("\nIDs: " + string.Join(", ", GameService.GetIDs()));
                    break;

                default:
                    DataSerialize.SaveData();
                    Console.WriteLine("Thank you, see you later!");
                    return;
            }
        }
    }

    private static int SetOurRating()
    {
        label:
        Console.Write($"\nDo you want to set rating for game? \n" +
                      $"1. Yes \n" +
                      $"2. No \n" +
                      $"Your choice: ");
        var inputRating = Console.ReadLine();
        switch (inputRating)
        {
            case "1": return GetInputRating();
            case "2": return int.MaxValue;
            default:
                Console.WriteLine("Error input");
                goto label;
        }
    }

    private static int GetInputRating()
    {
        while (true)
        {
            Console.Write("Enter your game rating: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var rating))
            {
                return rating;
            }

            Console.WriteLine("Error input\n");
        }
    }

    private static GameAccount CreateAccount(string name)
    {
        label:
        Console.Write($"\nWhich type of account you want to create: \n" +
                      $"1. Default\n" +
                      $"2. Premium\n" +
                      $"3. Vip\n" +
                      $"Your choice: ");
        var typeAccount = Console.ReadLine();
        switch (typeAccount)
        {
            case "1":
                return AccountFactory.CreateDefaultAccount(name);
            case "2":
                return AccountFactory.CreatePremiumAccount(name);
            case "3":
                return AccountFactory.CreateVipAccount(name);
            default:
                Console.WriteLine("Error input");
                goto label;
        }
    }

    private static GameAccount GetAccountForGame()
    {
        Console.Write("\nEnter player's name: ");
        var playerName = Console.ReadLine()!;

        try
        {
            var account = UserService.GetByName(playerName);
            Console.WriteLine($"Welcome back, {account.UserName} happy to see you!");
            return account;
        }
        catch (Exception)
        {
            Console.WriteLine("We don't have this user, we will create new account for you");
            return CreateAccount(playerName);
        }
    }

    private static bool Rematch()
    {
        label:
        Console.Write($"\nDo you want to play again? \n" +
                      $"1. Yes \n" +
                      $"2. No \n" +
                      $"Your choice: ");
        switch (Console.ReadLine())
        {
            case "1": return true;
            case "2": return false;
            default:
                Console.WriteLine("Error input");
                goto label;
        }
    }
}
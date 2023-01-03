using Newtonsoft.Json;
using TicTacToe.Account;
using TicTacToe.Enum;

namespace TicTacToe.Games;

public class StandartGame : Game
{
    [JsonConstructor]
    public StandartGame(GameAccount player, GameAccount opponent) : base(player, opponent, GameType.Standart)
    {
    }

    public StandartGame(GameAccount player, GameAccount opponent, int rating) : base(player, opponent, rating, GameType.Standart)
    {
    }

    public override int GetRating => Rating;
}
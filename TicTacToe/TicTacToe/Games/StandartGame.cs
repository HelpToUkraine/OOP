using TicTacToe.Account;
using TicTacToe.Enum;

namespace TicTacToe.Games;

public class StandartGame : Game
{
    public StandartGame(GameAccount player, GameAccount opponent) : base(player, opponent, GameType.StandartGame)
    {
    }

    public StandartGame(GameAccount player, GameAccount opponent, int rating) : base(player, opponent, rating, GameType.StandartGame)
    {
    }

    public override int GetRating => Rating;
}
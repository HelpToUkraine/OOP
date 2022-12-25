using TicTacToe.Account;
using TicTacToe.Enum;

namespace TicTacToe.Games;

public class TrainingGame : Game
{
    public TrainingGame(GameAccount player, GameAccount opponent) : base(player, opponent, 0, GameType.TrainingGame)
    {
    }

    public override int GetRating => 0;
}
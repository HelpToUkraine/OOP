using TicTacToe.Account;
using TicTacToe.Enum;

namespace TicTacToe.Games;

public class TrainingGame : Game
{
    public TrainingGame(GameAccount player, GameAccount opponent) : base(player, opponent, GameType.TrainingGame)
    {
    }

    public override int GetRating => 0;
}
using Lab2.Account;

namespace Lab2.Games;

public class TrainingGame : Game
{
    public TrainingGame(GameAccount player, GameAccount opponent) : base(player, opponent, 0)
    {
    }

    public override int GetRating => 0;
}
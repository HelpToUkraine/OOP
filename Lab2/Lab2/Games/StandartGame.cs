using Lab2.Account;

namespace Lab2.Games;

public class StandartGame : Game
{
    public StandartGame(GameAccount player, GameAccount opponent) : base(player, opponent)
    {
    }

    public StandartGame(GameAccount player, GameAccount opponent, int rating) : base(player, opponent, rating)
    {
    }

    public override int GetRating => Rating;
}
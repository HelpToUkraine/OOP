using Lab2.Account;

namespace Lab2.Games;

public class SingleGame : Game
{
    public SingleGame(GameAccount player) : base(player)
    {

    }

    public SingleGame(GameAccount player, int rating) : base(player, rating)
    {

    }

    /*public override int GetRating(GameAccount account)
    {
        return account.GetBonus(Rating);
    } */
}
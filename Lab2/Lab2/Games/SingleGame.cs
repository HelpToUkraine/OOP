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

    protected override void Play()
    {
        if (IsWinPlayer())
        {
            Player.WinGame(this);
        }
        else
        {
            Player.LoseGame(this);
        }
    }

    protected override int Rating
    {
        get => _rating;
        private protected init
        {
            if (value < 0)
            {
                throw new ArgumentException("Error: 'rating can't have negative value'");
            }

            if (value > Player.CurrentRating)
            {
                throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
            }

            _rating = value;
        }
    }

    public override int GetRating => Rating;
}
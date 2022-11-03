using Lab2.Account;

namespace Lab2.Games;

public abstract class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/

    private protected int _rating = 2; /* default value game rating */
    public readonly int GameId;
    public readonly GameAccount Player;
    public readonly GameAccount Opponent = null!;

    protected virtual int Rating
    {
        get => _rating;
        private protected init
        {
            if (value < 0)
            {
                throw new ArgumentException("Error: 'rating can't have negative value'");
            }

            if (value > Player.CurrentRating || value > Opponent.CurrentRating)
            {
                throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
            }

            _rating = value;
        }
    }

    protected Game(GameAccount player)
    {
        Player = player;
        GameId = _id++;
        Play();
    }

    protected Game(GameAccount player, int rating)
    {
        Player = player;
        Rating = rating;
        GameId = _id++;
        Play();
    }

    protected Game(GameAccount player, GameAccount opponent)
    {
        Player = player;
        Opponent = opponent;
        GameId = _id++;
        Play();
    }

    protected Game(GameAccount player, GameAccount opponent, int rating)
    {
        Player = player;
        Opponent = opponent;
        Rating = rating;
        GameId = _id++;
        Play();
    }


    protected virtual void Play()
    {
        if (IsWinPlayer())
        {
            Player.WinGame(this);
            Opponent.LoseGame(this);
        }
        else
        {
            Opponent.WinGame(this);
            Player.LoseGame(this);
        }
    }

    private protected static bool IsWinPlayer()
    {
        return new Random().Next(2) < 1;
    }

    public static string GetObjectType(object o) /* example: Game.Games.SingleGame ---> SingleGame */
    {
        return o.GetType().ToString().Split('.')[2];
    }

    public abstract int GetRating { get; }
}
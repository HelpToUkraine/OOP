using TicTacToe.Account;
using TicTacToe.Enum;
using TicTacToe.Field;
using TicTacToe.Services;

namespace TicTacToe.Games;

public abstract class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/
    private protected int _rating = 2; /* default value game rating */

    public readonly int GameId;
    public readonly GameType Type;
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

    protected Game(GameAccount player, GameType type)
    {
        Player = player;
        Type = type;
        GameId = _id++;
        GameService.Add(this);
        GameService.AddToQueue(this);
    }

    protected Game(GameAccount player, int rating, GameType type)
    {
        Player = player;
        Rating = rating;
        Type = type;
        GameId = _id++;
        GameService.Add(this);
        GameService.AddToQueue(this);
    }

    protected Game(GameAccount player, GameAccount opponent, GameType type)
    {
        CheckToPlayHimself(player, opponent);
        Player = player;
        Opponent = opponent;
        Type = type;
        GameId = _id++;
        GameService.Add(this);
        GameService.AddToQueue(this);
    }

    protected Game(GameAccount player, GameAccount opponent, int rating, GameType type)
    {
        CheckToPlayHimself(player, opponent);
        Player = player;
        Opponent = opponent;
        Rating = rating;
        Type = type;
        GameId = _id++;
        GameService.Add(this);
        GameService.AddToQueue(this);
    }

    public virtual void Play()
    {
        var result = IsWinPlayer();
        switch (result)
        {
            case GameStatus.Win:
                Player.WinGame(this);
                Opponent.LoseGame(this);
                break;
            case GameStatus.Lose:
                Opponent.WinGame(this);
                Player.LoseGame(this);
                break;
            case GameStatus.Draw:
                Player.DrawGame(this);
                Opponent.DrawGame(this);
                break;
            case GameStatus.Playing:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private protected GameStatus IsWinPlayer()
    {
        Console.Write($"\n{Type}: {Player.UserName} vs {(Type == GameType.SingleGame ? "Bot" : Opponent.UserName)}");
        return new GameField(this).StartGame();
    }

    private static void CheckToPlayHimself(GameAccount player, GameAccount opponent)
    {
        if (player.Equals(opponent))
        {
            throw new  ArgumentException("Error: 'Player can't play with himself'");
        }

    }



    public abstract int GetRating { get; }
}
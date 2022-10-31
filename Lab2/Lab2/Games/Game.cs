using Lab2.Account;

namespace Lab2.Games;

public abstract class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/

    private readonly int _rating = 1; /* default value game rating */
    private readonly int _gameId;
    private readonly GameAccount _player;
    private readonly GameAccount _opponent = null!;

    public int Rating => _rating;

    protected Game(GameAccount player)
    {
        _player = player;
        _gameId = _id++;
        PlaySingle();
    }

    protected Game(GameAccount player, int rating)
    {
        _player = player;
        _rating = rating;
        _gameId = _id++;
        PlaySingle();
    }

    protected Game(GameAccount player, GameAccount opponent)
    {
        _player = player;
        _opponent = opponent;
        _gameId = _id++;
        Play();
    }

    protected Game(GameAccount player, GameAccount opponent, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Error: 'rating can't have negative value'");
        }
        if (rating > player.CurrentRating || rating > opponent.CurrentRating)
        {
            throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
        }
        _player = player;
        _opponent = opponent;
        _rating = rating;
        _gameId = _id++;
        Play();
    }

    private void PlaySingle()
    {
        // TODO: "delete output"
        Console.Write($"GameId {_gameId}: ");

        var random = new Random();
        if (random.Next(2) < 1)
        {
            _player.WinGame(this); /*"SYSTEM",*/
            _player.HistoryGames.Add(new HistoryGame(_gameId, GameStatus.Win, _rating));  // DELETE OPPONENT
        }
        else
        {
            _player.LoseGame(this);
            _player.HistoryGames.Add(new HistoryGame(_gameId, GameStatus.Lose, _rating));
        }

        _player.GamesCount++;
    }

    private void Play()
    {
        // TODO: "delete output"
        Console.Write($"GameId {_gameId}: ");

        var random = new Random();
        if (random.Next(2) < 1)
        {
            _player.WinGame(this);  /*_opponent.UserName, */
            _player.HistoryGames.Add(new HistoryGame(_gameId, _opponent.UserName, GameStatus.Win, _rating));

            _opponent.LoseGame(this);
            _opponent.HistoryGames.Add(new HistoryGame(_gameId, _player.UserName, GameStatus.Lose, _rating));
        }
        else
        {
            _opponent.WinGame(this); /*_player.UserName, */
            _opponent.HistoryGames.Add(new HistoryGame(_gameId, _player.UserName, GameStatus.Win, _rating));

            _player.LoseGame(this);
            _player.HistoryGames.Add(new HistoryGame(_gameId, _opponent.UserName, GameStatus.Lose, _rating));
        }

        _player.GamesCount++;
        _opponent.GamesCount++;

    }

    /*public static void CreateGames(GameAccount player1, GameAccount player2, int countGames)
    {
        for (var i = 0; i < countGames; i++)
        {
            new Game(player1, player2);
        }
    }*/

    /*public abstract int GetRating();*/
}
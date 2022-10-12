namespace Lab1;

public class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/

    private int _rating = 1; /* default value game rating */
    private int _gameId ;
    private GameAccount _player;
    private GameAccount _opponent;
    private GameStatus _isWinPlayer;

    public Game(GameAccount player, GameAccount opponent)
    {
        _player = player;
        _opponent = opponent;
        _gameId = _id++;
        Play();
    }

    public Game(GameAccount player, GameAccount opponent, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Error: '_rating can't have negative value'");
        }
        else if (rating > player.CurrentRating || rating > opponent.CurrentRating)
        {
            throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
        }
        _player = player;
        _opponent = opponent;
        _rating = rating;
        _gameId = _id++;
        Play();
    }

    private void Play()
    {
        Console.Write($"GameId {_gameId}: ");
        var random = new Random();
        if (random.Next(2) < 1)
        {
            _player.WinGame(_opponent.UserName, _rating);
            _opponent.LoseGame(_player.UserName, _rating);
            _isWinPlayer = GameStatus.Win;
        }
        else
        {
            _opponent.WinGame(_player.UserName, _rating);
            _player.LoseGame(_opponent.UserName, _rating);
            _isWinPlayer = GameStatus.Lose;
        }

        _player.GamesCount++;
        _opponent.GamesCount++;

        _player.HistoryGames.Add(this);
        _opponent.HistoryGames.Add(this);
    }

    public override string ToString()
    {
        return "Game{"
            + '\'' + _player.UserName + "' vs '" + _opponent.UserName + '\''
            + ", isWinPlayer=" + _isWinPlayer
            + ", gameRating=" + _rating
            + ", gameId=" + _gameId
            + '}';
    }

    public static void CreateGames(GameAccount player1, GameAccount player2, int countGames)
    {
        for (var i = 0; i < countGames; i++)
        {
            new Game(player1, player2);
        }
    }
}
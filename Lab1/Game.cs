namespace Lab1;

public class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/

    public int Rating = 1; /* default value game rating */
    public int GameId ;
    public GameAccount Player;
    public GameAccount Opponent;
    public GameStatus IsWinPlayer;

    public Game(GameAccount player, GameAccount opponent)
    {
        Player = player;
        Opponent = opponent;
        GameId = _id++;
        Play();
    }

    public Game(GameAccount player, GameAccount opponent, int rating)
    {
        if (rating < 0)
        {
            throw new ArgumentException("Error: 'Rating can't have negative value'");
        }
        else if (rating > player.CurrentRating || rating > opponent.CurrentRating)
        {
            throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
        }
        Player = player;
        Opponent = opponent;
        Rating = rating;
        GameId = _id++;
        Play();
    }

    public void Play()
    {
        Console.Write($"GameId {GameId}: ");
        Random random = new Random();
        if (random.Next(2) < 1)
        {
            Player.WinGame(Opponent.UserName, Rating);
            Opponent.LoseGame(Player.UserName, Rating);
            IsWinPlayer = GameStatus.Win;
        }
        else
        {
            Opponent.WinGame(Player.UserName, Rating);
            Player.LoseGame(Opponent.UserName, Rating);
            IsWinPlayer = GameStatus.Lose;
        }

        Player.GamesCount++;
        Opponent.GamesCount++;

        Player.HistoryGames.Add(this);
        Opponent.HistoryGames.Add(this);
    }

    public override string ToString()
    {
        return "Game{"
            + '\'' + Player.UserName + "' vs '" + Opponent.UserName + '\''
            + ", isWinPlayer=" + IsWinPlayer
            + ", gameRating=" + Rating
            + ", gameId=" + GameId
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
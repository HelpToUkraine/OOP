namespace Lab1;

public class Game
{
    private static int _id; /* var for increment value Game object's 'GameId'*/

    public readonly int Rating = 1; /* default value game rating */
    public readonly int GameId;
    public readonly GameAccount Player;
    public readonly GameAccount Opponent;

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
            throw new ArgumentException("Error: 'rating can't have negative value'");
        }
        if (rating > player.CurrentRating || rating > opponent.CurrentRating)
        {
            throw new ArgumentException("Error: 'Game rating  can't be more players rating'");
        }
        Player = player;
        Opponent = opponent;
        Rating = rating;
        GameId = _id++;
        Play();
    }

    private void Play()
    {
        Console.Write($"GameId {GameId}: ");
        var random = new Random();
        if (random.Next(2) < 1)
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

    public static void CreateGames(GameAccount player1, GameAccount player2, int countGames)
    {
        for (var i = 0; i < countGames; i++)
        {
            new Game(player1, player2);
        }
    }
}
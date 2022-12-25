using TicTacToe.Account;

namespace TicTacToe.Games;

public static class GameFactory
{
    public static Game CreateStandartGame(GameAccount player, GameAccount opponent)
    {
        return new StandartGame(player, opponent);
    }

    public static Game CreateStandartGame(GameAccount player, GameAccount opponent, int rating)
    {
        return new StandartGame(player, opponent, rating);
    }

    public static Game CreateTrainingGame(GameAccount player, GameAccount opponent)
    {
        return new TrainingGame(player, opponent);
    }

    public static Game CreateSingleGame(GameAccount player)
    {
        return new SingleGame(player);
    }

    public static Game CreateSingleGame(GameAccount player, int rating)
    {
        return new SingleGame(player, rating);
    }
}
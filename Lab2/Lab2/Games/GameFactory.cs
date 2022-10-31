using Lab2.Account;

namespace Lab2.Games;

public static class GameFactory
{
    public static Game CreateStandartGame(GameAccount player, GameAccount opponent)
    {
        return new StandartGame(player, opponent);
    }

    public static Game CreateTrainGame(GameAccount player, GameAccount opponent)
    {
        return new TrainGame(player, opponent);
    }

    public static Game CreateSingleGame(GameAccount player)
    {
        return new SingleGame(player);
    }
}
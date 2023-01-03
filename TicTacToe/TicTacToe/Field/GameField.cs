using TicTacToe.Enum;
using TicTacToe.Games;

namespace TicTacToe.Field;

public class GameField
{
    private const int Size = 3;
    public readonly char[,] Field = new char[Size, Size];
    private readonly Game _game;
    public int NumberSteps { get; private set; }

    public GameField(Game game)
    {
        _game = game;
    }

    private void PrintField()
    {
        for (var i = 0; i < Size; i++)
        {
            Console.WriteLine("\n+----+----+----+");
            for (var j = 0; j < Size; j++)
            {
                Console.Write(j != Size - 1 ? $"| {Field[i, j]}  " : $"| {Field[i, j]}  |");
            }
        }

        Console.WriteLine("\n+----+----+----+");
    }

    public GameStatus StartGame()
    {
        var status = GameStatus.Playing;
        PrintField();

        while (status.Equals(GameStatus.Playing))
        {
            var index = GetIndex();
            while (!IsCellEmpty(index))
            {
                Console.WriteLine("Error: This cell isn't empty, pls choose another\n");
                index = GetIndex();
            }

            SetStep(GetIndexInMatrix(index),
                NumberSteps % 2 == 0
                    ? GameSide.X
                    : GameSide.O);
            PrintField();

            NumberSteps++;
            status = WinnerCheck();
        }

        Console.WriteLine("Result of match: " +
                          status switch
                          {
                              GameStatus.Draw => GameStatus.Draw,
                              GameStatus.Win => $"{(char)GameSide.X}  {_game.Player.UserName} {GameStatus.Win}",
                              _ => $"{(char)GameSide.O}  " +
                                   $"{(_game.Type != GameType.Single ? _game.Opponent.UserName : "Bot")} " +
                                   $"{GameStatus.Win}"
                          });
        return status;
    }

    private int GetIndex()
    {
        return _game.Type != GameType.Single ? GetIndexFromUser()
            : NumberSteps % 2 == 0 ? GetIndexFromUser()
            : Bot.GetIndexFromBot(this);
    }


    private void SetStep(int[] index, GameSide side)
    {
        Field[index[0], index[1]] = (char)side;
    }

    private int GetIndexFromUser()
    {
        var index = 0;
        while (index is not (>= 1 and <= 9))
        {
            try
            {
                Console.Write((NumberSteps % 2 == 0
                                  ? $"{(char)GameSide.X}  {_game.Player.UserName}"
                                  : $"{(char)GameSide.O}  {_game.Opponent.UserName}")
                              + " choose your step: ");
                index = Convert.ToInt32(Console.ReadLine());
                if (index is < 1 or > 9)
                    throw new ArgumentException();
            }
            catch (Exception)
            {
                Console.WriteLine("Error: please, input number from 1 to 9\n");
            }
        }

        return index;
    }

    private bool IsCellEmpty(int index)
    {
        var mIndex = GetIndexInMatrix(index);
        return Field[mIndex[0], mIndex[1]] != (char)GameSide.X && Field[mIndex[0], mIndex[1]] != (char)GameSide.O;
    }

    public List<int> GetEmptyCells()
    {
        var list = new List<int>();
        for (var i = 1; i <= Field.Length; i++)
        {
            if (IsCellEmpty(i))
                list.Add(i);
        }

        return list;
    }

    private static int[] GetIndexInMatrix(int index)
    {
        var arr = new int[2];
        switch (index)
        {
            case 1:
                arr[0] = 0;
                arr[1] = 0;
                break;
            case 2:
                arr[0] = 0;
                arr[1] = 1;
                break;
            case 3:
                arr[0] = 0;
                arr[1] = 2;
                break;
            case 4:
                arr[0] = 1;
                arr[1] = 0;
                break;
            case 5:
                arr[0] = 1;
                arr[1] = 1;
                break;
            case 6:
                arr[0] = 1;
                arr[1] = 2;
                break;
            case 7:
                arr[0] = 2;
                arr[1] = 0;
                break;
            case 8:
                arr[0] = 2;
                arr[1] = 1;
                break;
            case 9:
                arr[0] = 2;
                arr[1] = 2;
                break;
        }

        return arr;
    }

    private GameStatus WinnerCheck()
    {
        if (
            (Field[0, 0] == (char)GameSide.X && Field[0, 1] == (char)GameSide.X && Field[0, 2] == (char)GameSide.X)
            || (Field[0, 2] == (char)GameSide.X && Field[1, 2] == (char)GameSide.X &&
                Field[2, 2] == (char)GameSide.X)
            || (Field[2, 0] == (char)GameSide.X && Field[2, 1] == (char)GameSide.X &&
                Field[2, 2] == (char)GameSide.X)
            || (Field[0, 0] == (char)GameSide.X && Field[1, 0] == (char)GameSide.X &&
                Field[2, 0] == (char)GameSide.X)
            || (Field[0, 0] == (char)GameSide.X && Field[1, 1] == (char)GameSide.X &&
                Field[2, 2] == (char)GameSide.X)
            || (Field[0, 2] == (char)GameSide.X && Field[1, 1] == (char)GameSide.X &&
                Field[2, 0] == (char)GameSide.X)
            || (Field[1, 0] == (char)GameSide.X && Field[1, 1] == (char)GameSide.X &&
                Field[1, 2] == (char)GameSide.X)
            || (Field[0, 1] == (char)GameSide.X && Field[1, 1] == (char)GameSide.X &&
                Field[2, 1] == (char)GameSide.X)
        ) return GameStatus.Win;
        if (
            (Field[0, 0] == (char)GameSide.O && Field[0, 1] == (char)GameSide.O && Field[0, 2] == (char)GameSide.O)
            || (Field[0, 2] == (char)GameSide.O && Field[1, 2] == (char)GameSide.O &&
                Field[2, 2] == (char)GameSide.O)
            || (Field[2, 0] == (char)GameSide.O && Field[2, 1] == (char)GameSide.O &&
                Field[2, 2] == (char)GameSide.O)
            || (Field[0, 0] == (char)GameSide.O && Field[1, 0] == (char)GameSide.O &&
                Field[2, 0] == (char)GameSide.O)
            || (Field[0, 0] == (char)GameSide.O && Field[1, 1] == (char)GameSide.O &&
                Field[2, 2] == (char)GameSide.O)
            || (Field[0, 2] == (char)GameSide.O && Field[1, 1] == (char)GameSide.O &&
                Field[2, 0] == (char)GameSide.O)
            || (Field[1, 0] == (char)GameSide.O && Field[1, 1] == (char)GameSide.O &&
                Field[1, 2] == (char)GameSide.O)
            || (Field[0, 1] == (char)GameSide.O && Field[1, 1] == (char)GameSide.O &&
                Field[2, 1] == (char)GameSide.O)
        ) return GameStatus.Lose;

        return NumberSteps == Size * Size ? GameStatus.Draw : GameStatus.Playing;
    }
}
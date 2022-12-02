using TicTacToe.Enum;

namespace TicTacToe.Field;

public static class Bot
{
    private static readonly List<int> Angles = new();
    private static List<int> _emptyCells = null!;
    private static char[,] _matrix = null!;
    private static readonly Random Random = new();


    public static int GetIndexFromBot(GameField field)
    {
        _emptyCells = field.GetEmptyCells();
        _matrix = field.Field;

        Thread.Sleep(500);
        return field.NumberSteps is 0 or 1 ? FirstStep() : CloseWinOrLoseLine();
    }

    private static int FirstStep()
    {
        foreach (var cell in _emptyCells.Where(cell => cell is 1 or 3 or 7 or 9))
        {
            Angles.Add(cell);
        }

        return Angles[Random.Next(Angles.Count)];
    }

    private static int RandomStep()
    {
        return _emptyCells[new Random().Next(_emptyCells.Count)];
    }

    private static int CloseWinOrLoseLine()
    {
        if (MainDiagonal(GameSide.O) != 0) return MainDiagonal(GameSide.O);
        if (SubDiagonal(GameSide.O) != 0) return SubDiagonal(GameSide.O);
        if (RowCourse(GameSide.O) != 0) return RowCourse(GameSide.O);
        if (ColumnCourse(GameSide.O) != 0) return ColumnCourse(GameSide.O);
        
        if (MainDiagonal(GameSide.X) != 0) return MainDiagonal(GameSide.X);
        if (SubDiagonal(GameSide.X) != 0) return SubDiagonal(GameSide.X);
        if (RowCourse(GameSide.X) != 0) return RowCourse(GameSide.X);
        return ColumnCourse(GameSide.X) != 0 ? ColumnCourse(GameSide.X) : RandomStep();
    }

    private static int RowCourse(GameSide gameSide)
    {
        for (int i = 0, index = 1; i < _matrix.GetLength(0); i++)
        {
            int count=0, indexEmpty = 0;
            for (var j = 0; j < _matrix.GetLength(1); j++, index++)
            {
                if (_matrix[i, j] == (char)gameSide)
                    count++;

                if (_matrix[i, j] != (char)GameSide.X && _matrix[i, j] != (char)GameSide.O)
                    indexEmpty = index;
            }

            if ((count == 2) && indexEmpty != 0)
            {
                return indexEmpty;
            }
        }

        return 0;
    }

    private static int ColumnCourse(GameSide gameSide)
    {

        for (int i = 0, index = 1; i < _matrix.GetLength(0); i++, index=i+1)
        {
            int count = 0, indexEmpty = 0;
            for (var j = 0; j < _matrix.GetLength(1); j++, index += 3)
            {
                if (_matrix[j, i] == (char)gameSide)
                    count++;
                else if (_matrix[j,i] == (char)GameSide.X || _matrix[j,i] == (char)GameSide.O)
                    break;
                else indexEmpty = index;
            }

            if ((count == 2) && indexEmpty != 0)
            {
                return indexEmpty;
            }
        }

        return 0;
    }

    private static int MainDiagonal(GameSide gameSide)
    {
        int count=0, indexEmpty = 0;
        for (int i = 0, index = 1; i < _matrix.GetLength(0); i++, index += 4)
        {
            if (_matrix[i, i] == (char)gameSide)
                count++;
            else if (_matrix[i,i] == (char)GameSide.X || _matrix[i,i] == (char)GameSide.O)
                break;
            else indexEmpty = index;
        }

        if ((count ==  2) && indexEmpty != 0)
        {
            return indexEmpty;
        }

        return 0;
    }

    private static int SubDiagonal(GameSide gameSide)
    {
        int indexEmpty = 0, count=0;
        for (int i = 0, j = 2, index = 3; i < _matrix.GetLength(0); i++, j--, index += 2)
        {
            if (_matrix[i, j] == (char)gameSide)
                count++;
            else if (_matrix[i,j] == (char)GameSide.X || _matrix[i,j] == (char)GameSide.O)
                break;
            else indexEmpty = index;
        }

        if ((count== 2) && indexEmpty != 0)
        {
            return indexEmpty;
        }

        return 0;
    }
}
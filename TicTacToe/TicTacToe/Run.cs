using System.Text;
using TicTacToe.Menu;

namespace TicTacToe;

public static class Run
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; /*for print unicode symbols*/
        GameMenu.Start();
    }
}
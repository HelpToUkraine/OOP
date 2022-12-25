using Newtonsoft.Json;
using TicTacToe.Services;
using static System.IO.File;

namespace TicTacToe.Data;

public static class DataSerialize
{
    public static readonly JsonSerializerSettings Settings = new()
    {
        TypeNameHandling = TypeNameHandling.Auto,
        Formatting = Formatting.Indented
    };

    public const string AccountPath = "account.json";
    public const string GamePath = "game.json";

    public static void SaveData()
    {
        var jsonDataUser = JsonConvert.SerializeObject(UserService.Get(), Settings);
        var jsonDataGame = JsonConvert.SerializeObject(GameService.Get(), Settings);
        WriteAllText(AccountPath, jsonDataUser);
        WriteAllText(GamePath, jsonDataGame);
    }
}
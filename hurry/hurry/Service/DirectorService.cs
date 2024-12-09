using _2._2Dars.Models;
using System.Text.Json;

namespace _2._2Dars.Services;

public class DirectorService
{
    private string directorFilePath;
    public DirectorService()
    {
        directorFilePath = "../../../Data/Director.json";
    }
    public void SaveInform(List<Director> directors)
    {
        var res = JsonSerializer.Serialize(directors);
        File.WriteAllText(directorFilePath,res);
    }
    public List<Director> GetDirectors()
    {
        var result = File.ReadAllText(directorFilePath);
        var ress = JsonSerializer.Deserialize<List<Director>>(result);
        return ress;
    }

    public bool CheckLogin(string password, string username)
    {
        if (password == "1999" && username == "2000")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ChangeLogin()
    {
        var result = File.ReadAllText(directorFilePath);
        var ress = JsonSerializer.Deserialize<List<Director>>(result);

        Console.WriteLine("Enter new Password");
        var log = Console.ReadLine();
        ress[0].Username = log;
        Console.WriteLine("Enter New Username");
        var pass = Console.ReadLine();
        ress[0].Password = pass;
        Console.WriteLine("Saved Successfully");
        SaveInform(ress);
    }



    //private string directorFilePath;
    //public DirectorService()
    //{
    //    directorFilePath = "../../../Data/Director.json";
    //}
    //public void SaveInform(List<Director> director)
    //{
    //    var directorJson = JsonSerializer.Serialize(director);
    //    File.WriteAllText(directorFilePath, directorJson);
    //}
    //public List<Director> GetDirectors()
    //{
    //    var directorJson = File.ReadAllText(directorFilePath);
    //    var result = JsonSerializer.Deserialize<List<Director>>(directorJson);
    //    return result;
    //}
    //public bool CheckLogin(string password, string username)
    //{
    //    //password = "world";
    //    //username = "life";
    //    if (password == "world" && username == "life")
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    //public bool checkDirectorPassword(string login, string password)
    //{
    //    var resInFile = File.ReadAllText(directorFilePath);
    //    var res = JsonSerializer.Deserialize<List<Director>>(resInFile);

    //    if (login == res[0].UserName && password == res[0].Password)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
    //public void ChangeLogin()
    //{
    //    var resInFile = File.ReadAllText(directorFilePath);
    //    var result = JsonSerializer.Deserialize<List<Director>>(resInFile);

    //    Console.WriteLine("Enter new Password");
    //    var log = Console.ReadLine();
    //    result[0].UserName = log;
    //    Console.WriteLine("Enter New Username");
    //    var pass = Console.ReadLine();
    //    result[0].Password = pass;
    //    Console.WriteLine("Saved Successfully");
    //    SaveInform(result);
    //}
}


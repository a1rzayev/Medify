using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Models;

namespace GameStore.Repository;
public class GameResources
{

    private const string ConnectionString = $"Server=localhost;Database=GameStoreDb;Trusted_Connection=True;TrustServerCertificate=True;";

    public IEnumerable<Game> GetGames()
    {
        using var connection = new SqlConnection(ConnectionString);
        return connection.Query<Game>("select * from Games");
    }

    public Game? GetGameById(int Id)
    {
        using var connection = new SqlConnection(ConnectionString);
        return connection.QueryFirstOrDefault<Game>(
            sql: "select top 1 * from games where Id = @Id",
            param: new { Id = Id });
    }

    public Game? GetGameByName(string name)
    {
        using var connection = new SqlConnection(ConnectionString);
        return connection.QueryFirstOrDefault<Game>(
            sql: "select top 1 * from games where Name = @Name",
            param: new { Name = name });
    }


    public void AddGame(Game game)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(
            @"insert into games (Name, Price, Categories) 
        values(@Name, @Price, @Categories)",
            param: new
            {
                game.Name,
                game.Price,
                game.Categories,
            });
    }

    public void DeleteGame(int id)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Execute(
            @"delete games where Id = @Id",
            param: new { Id = id }
        );
    }
}
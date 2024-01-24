using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Models;
using Dapper;

namespace GameStore.Resources;
public class GameResources
{

    private const string connectionString = $"Server=localhost;Database=GameStoreDB;Trusted_Connection=True;TrustServerCertificate=True;";

    public IEnumerable<Game> GetGames()
    {
        using var connection = new SqlConnection(connectionString);
        return connection.Query<Game>("select * from Games");
    }

    public Game? GetGameById(int id)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.QueryFirstOrDefault<Game>(
            sql: "select * from Games where Id = @Id",
            param: new {
                Id = id 
            }                
        );
    }

    public Game? GetGameByName(string name)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.QueryFirstOrDefault<Game>(
            sql: "select * from Games where Name = @name",
            param: new {
                Name = name 
            }                
        );
    }


    public int AddGame(Game game)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.Execute(
            @"insert into Games (Name, Price, Category) values (@Name ,@Price, @Category)",
            param: new
            {
                game.Name,
                game.Price,
                game.Category
            }
        );
    }

    public  int DeleteGame(int id)
    {
        using var connection = new SqlConnection(connectionString);
        return connection.Execute(
            @"delete Games where Id = @Id",
            param: new
            {
                Id = id,
            }
        );
    }

}

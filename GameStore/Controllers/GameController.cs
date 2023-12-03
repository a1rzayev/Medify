namespace GameStore.Controllers;

using System.Data.SqlClient;
using System.Net;
using System.Text.Json;
using Dapper;
using GameStore.Controllers.Base;
using GameStore.Extensions;
using GameStore.Models;

public class GameController : ControllerBase {
    private const string ConnectionString = "Server=localhost;Database=GameStoreDb;User Id=admin;Password=admin;";

    public async Task GetProductsAsync(HttpListenerContext context)
    {
        using var writer = new StreamWriter(context.Response.OutputStream);

        using var connection = new SqlConnection(ConnectionString);
        var games = await connection.QueryAsync<Game>("select * from GameStoreDB");

        var gamesHtml = games.GetHtml();
        await writer.WriteLineAsync(gamesHtml);
        context.Response.ContentType = "text/html";

        // var productsJson = JsonSerializer.Serialize(products);
        // await writer.WriteLineAsync(productsJson);
        // context.Response.ContentType = "application/json";

        context.Response.StatusCode = (int)HttpStatusCode.OK;

        writer.Dispose();
    }

    public async Task PostProductAsync(HttpListenerContext context)
    {
        using var reader = new StreamReader(context.Request.InputStream);
        var json = await reader.ReadToEndAsync();

        var newProduct = JsonSerializer.Deserialize<Game>(json);

        if (newProduct == null || string.IsNullOrWhiteSpace(newProduct.Name))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        using var connection = new SqlConnection(ConnectionString);
        var products = await connection.ExecuteAsync(
            @"insert into Products (Name, Price) 
        values(@Name, @Price)",
            param: new
            {
                newProduct.Name,
                newProduct.Price,
            });

        context.Response.StatusCode = (int)HttpStatusCode.Created;
    }

    public async Task DeleteGameAsync(HttpListenerContext context)
    {
        var productIdToDeleteObj = context.Request.QueryString["id"];

        if (productIdToDeleteObj == null || int.TryParse(productIdToDeleteObj, out int gameIdToDelete) == false)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        using var connection = new SqlConnection(ConnectionString);
        var deletedRowsCount = await connection.ExecuteAsync(
            @"delete GameStoreDB where Id = @Id",
            param: new
            {
                Id = gameIdToDelete,
            });

        if (deletedRowsCount == 0)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return;
        }

        context.Response.StatusCode = (int)HttpStatusCode.OK;
    }

    public async Task PutProductAsync(HttpListenerContext context)
    {
        var productIdToUpdateObj = context.Request.QueryString["id"];

        if (productIdToUpdateObj == null || int.TryParse(productIdToUpdateObj, out int productIdToUpdate) == false)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        using var reader = new StreamReader(context.Request.InputStream);
        var json = await reader.ReadToEndAsync();

        var gameToUpdate = JsonSerializer.Deserialize<Game>(json);

        if (gameToUpdate == null || string.IsNullOrEmpty(gameToUpdate.Name))
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return;
        }

        using var connection = new SqlConnection(ConnectionString);
        var affectedRowsCount = await connection.ExecuteAsync(
            @"update Products
        set Name = @Name, Price = @Price
        where Id = @Id",
            param: new
            {
                gameToUpdate.Name,
                gameToUpdate.Price,
                Id = productIdToUpdate
            });

        if (affectedRowsCount == 0)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            return;
        }

        context.Response.StatusCode = (int)HttpStatusCode.OK;
    }
}
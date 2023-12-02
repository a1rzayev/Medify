using System.Net;
using System.Text;
using GameStore.Models;
using GameStore.Resources;
using System.Data.SqlClient;

const string connectionString = "Server=localhost;Database=AkhshamBazariDb;User Id=sa;Password=Admin9264!!;";
HttpListener httpListener = new HttpListener();

const int port = 8080;
httpListener.Prefixes.Add($"http://*:{port}/");

httpListener.Start();

Console.WriteLine($"Server successfully started on port {port}");

System.Console.WriteLine($"Server started on port {port}...");

string GetHtml<T>(IEnumerable<T> products)
{
    Type type = typeof(T);

    var props = type.GetProperties();

    StringBuilder sb = new StringBuilder(100);
    sb.Append("<ul>");

    foreach (var product in products)
    {
        foreach (var prop in props)
        {
            sb.Append($"<li><span>{prop.Name}: </span>{prop.GetValue(product)}</li>");
        }
        sb.Append("<br/>");
    }
    sb.Append("</ul>");

    return sb.ToString();
}

while (true)
{
    var context = await httpListener.GetContextAsync();
    using var writer = new StreamWriter(context.Response.OutputStream);

    var endpointItems = context.Request.RawUrl?.Split("/", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    if (endpointItems == null || endpointItems.Length == 0)
    {
        var pageHtml = await File.ReadAllTextAsync("Pages/home.html");
        await writer.WriteLineAsync(pageHtml);
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.ContentType = "text/html";

        continue;
    }

    switch (endpointItems[0].ToLower())
    {
        case "games":
            if (context.Request.HttpMethod == HttpMethod.Get.ToString())
            {
                var products = new List<Game> {
                    new Game {
                        Id = 1,
                        Name = "GTA",
                        Price = 28.99,
                        Categories = new List<Category> {Category.Openworld}
                    },
                    new Game {
                        Id = 2,
                        Name = "Pes",
                        Price = 18.99,
                        Categories = new List<Category> {Category.Sports}
                    },
                    new Game {
                        Id = 3,
                        Name = "Forza Horizon 4",
                        Price = 39.99,
                        Categories = new List<Category> {Category.Race}
                    },
                    new Game {
                        Id = 4,
                        Name = "Minecraft",
                        Price = 19.99,
                        Categories = new List<Category> {Category.Survival}
                    },
                    new Game {
                        Id = 4,
                        Name = "Counter-Strike",
                        Price = 15.99,
                        Categories = new List<Category> {Category.FPS}
                    }
                };
                using var connection = new System.Data.SqlClient.SqlConnection(connectionString);
                var games = await connection.QueryAsync<Game>("select * from Products");

                var gamesHtml = GetHtml(products);
                await writer.WriteLineAsync(gamesHtml);
                context.Response.ContentType = "text/html";

                context.Response.StatusCode = (int)HttpStatusCode.OK;
            }
            else {
                context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            }

            break;
    }
}
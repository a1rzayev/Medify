namespace GameStore.Controllers;

using System.Net;
using GameStore.Controllers.Base;

public class HomeController : ControllerBase
{
    public async Task HomePageAsync(HttpListenerContext context)
    {
        using var writer = new StreamWriter(context.Response.OutputStream);

        var pageHtml = await File.ReadAllTextAsync("Views/Home.html");
        await writer.WriteLineAsync(pageHtml);
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        context.Response.ContentType = "text/html";
    }
}
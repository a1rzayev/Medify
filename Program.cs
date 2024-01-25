using GameStore.Resources;
using GameStore.Resources.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IResources>(provider => {
    const string connectionStringName = "GameStoreDB";
    string? connectionString = builder.Configuration.GetConnectionString(connectionStringName);
    if(string.IsNullOrWhiteSpace(connectionString)) 
        throw new Exception($"{connectionStringName} not found");
    return new GameResources(connectionString);
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Game}/{action=GetGames}");

app.Run();

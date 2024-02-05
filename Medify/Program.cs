using Medify.Repositories;
using Medify.Repositories.Base;
using Medify.Resources;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepository>(provider => {
    const string connectionStringName = "MedifyDB";
    string? connectionString = builder.Configuration.GetConnectionString(connectionStringName);
    if(string.IsNullOrWhiteSpace(connectionString)) 
        throw new Exception($"{connectionStringName} not found");
    return new MedRepository(connectionString);
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
    pattern: "{controller=Doctor}/{action=GetDoctors}");

app.Run();

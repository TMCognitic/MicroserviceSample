using MicroServ.Web.Models;
using MicroServ.Web.Models.Repositories;
using MicroServ.Web.Models.Services;

if (args.Length > 0)
{
    foreach(string arg in args)
    {
        Console.WriteLine(arg);
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("api", client =>
{
    client.BaseAddress = new Uri(args[0]);
});

builder.Services.AddScoped<ITodoRepository, TodoService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

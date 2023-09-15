using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using UnicornManager.DBLib;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddDbContextFactory<UnicornDbContext>(
    o => o.UseSqlite("Data Source=unciorn.db"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    using IServiceScope scope = app.Services.CreateScope();

    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<UnicornDbContext>>();

    using UnicornDbContext context = factory.CreateDbContext();

    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    context.Unicorns.Add(new Unicorn()
    {
        Identifier = 1,
        Name = "Rainbow Star",
        Birthdate = DateTime.Now.AddDays(-8374)
    });

    context.Unicorns.Add(new Unicorn()
    {
        Identifier = 2,
        Name = "Sparkle",
        Birthdate = DateTime.Now.AddDays(-8384)
    });

    context.Unicorns.Add(new Unicorn()
    {
        Identifier = 3,
        Name = "Strawbery Milk",
        Birthdate = DateTime.Now.AddDays(-8884)
    });

    context.SaveChanges();
}

    app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

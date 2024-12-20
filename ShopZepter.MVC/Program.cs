using ShopZepter.Infrastructure.Extensions;
using ShopZepter.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddDbContext(configuration);
builder.Services.AddInfrastructureMvc();
builder.Services.AddSeeder();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<Seeder>();

seeder.Seed();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

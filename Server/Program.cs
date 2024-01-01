using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using WindowsStore.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
using WindowsStore.BLL.Interfaces;
using WindowsStore.BLL.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<BlazorWindowStoreContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Database"),
        b =>
        {
            b.MigrationsAssembly("WindowsStore.DAL");
            b.CommandTimeout(240);
        });
    options.EnableSensitiveDataLogging();

});

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IWindowService, WindowService>();

builder.Services.AddScoped<ISubElementService, SubElementService>();

builder.Services.AddMudServices();

builder.Services.AddAutoMapper((serviceProvider, automapper) =>
{
    automapper.AddCollectionMappers();
    automapper.UseEntityFrameworkCoreModel<BlazorWindowStoreContext>(serviceProvider);
}, typeof(BlazorWindowStoreContext).Assembly);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
//app.MapRazorComponents<App>()
//    .AddInteractiveServerRenderMode()
//    .AddInteractiveWebAssemblyRenderMode();


app.UseRouting();

app.UseAntiforgery();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<BlazorWindowStoreContext>();

context.Database.Migrate();

_ = Task.Run(async () => await Seed.TestingSeedData(context));

app.Run();
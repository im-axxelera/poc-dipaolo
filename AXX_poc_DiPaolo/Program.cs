using AXX_poc_DiPaolo.Data;
using AXX_poc_DiPaolo.Models;
using AXX_poc_DiPaolo.Repositories;
using AXX_poc_DiPaolo.Repositories.Interfaces;
using AXX_poc_DiPaolo.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITyreDealerRequestRepository, TyreDealerRequestRepository>();
builder.Services.AddScoped<TyreDealerService>();

builder.Services.AddScoped<ITransporterRequestRepository, TransporterRequestRepository>();
builder.Services.AddScoped<TransporterService>();

builder.Services.AddScoped<IBackOfficeRequestRepository, BackOfficeRequestRepository>();
builder.Services.AddScoped<BackOfficeService>();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login";
        });

builder.Services.Configure<List<LoginUser>>(builder.Configuration.GetSection("Users"));

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    //options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();

builder.Services.AddDbContext<PocDbContext>(options =>
options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("pocTestDb")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<PocDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Errore durante la creazione del database.");
    }
}

app.Run();

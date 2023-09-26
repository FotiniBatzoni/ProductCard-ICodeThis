using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using MongoDB.Driver;
using ProductCard.Data;
using ProductCard.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();


static void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddServerSideBlazor();
    services.AddSingleton<MongoDbClient>();
    services.AddTransient<UserService>();
    services.AddTransient<ProductService>();
    services.AddTransient<CartItemService>();
    services.AddScoped<CustomAuthenticationStateProvider>();
    services.AddTransient<AuthenticationService>();
    services.AddTransient<CartService>();
    services.AddTransient<TokenHelper>();   
    services.AddHttpContextAccessor();

    // Configure authentication
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/login"; // The login page URL
            options.AccessDeniedPath = "/accessDenied"; // The access denied page URL
        });

    // Configure authorization policies
    services.AddAuthorization(options =>
    {
        options.AddPolicy("AdminOnly", policy =>
        {
            policy.RequireRole("Admin"); // Requires users with the "Admin" role.
        });
    });

    


}


using System.Text.Encodings.Web;
using System.Text.Unicode;
using MBIN.Utility;
using MBIN.Web.Services.User;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

#region ApiUrls

var ApiUrlsSection = builder.Configuration.GetSection("ApiUrls");
builder.Services.Configure<ApiUrls>(ApiUrlsSection);

#endregion

builder.Services.AddHttpClient();

#region Session

builder.Services.AddSession(x =>
{
    x.IOTimeout = TimeSpan.FromDays(10);
    x.Cookie.HttpOnly = true;
    x.Cookie.IsEssential = true;
});

#endregion

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/Login";
    options.LogoutPath = "/Logout";
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
});

#region Dependencies

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Arabic }));

#endregion



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseSession();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
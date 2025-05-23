using MBIN.Utility;
using MBIN.Web.Services.User;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

#region ApiUrls

var ApiUrlsSection = builder.Configuration.GetSection("ApiUrls");
builder.Services.Configure<ApiUrls>(ApiUrlsSection);

#endregion

builder.Services.AddHttpClient();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
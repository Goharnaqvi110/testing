using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Gharshare.DataAccessLayer;
using Gharshare.DataAccessLayer.DbInitializer;
using AspNetCore.SEOHelper;
using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.DataAccessLayer.Data.Infrastructure.Repository;
using Gharshare.CommonHelper;
using Gharshare.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Gharshare.com.pk.Hubs;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
// Added Account Confirmation option
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDBContext>(); ;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUnitofWork, UnitOfWork>();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddScoped<Utility, Utility>();
//Dependecny injection for OTP/SMS upon Sign up
builder.Services.Configure<TwilioOptions>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddScoped<TwilioService>();
//builder.Services.AddScoped<ITempDataDictionary, TempDataDictionary>();
//builder.Services.AddScoped<DbContext, ApplicationDBContext>();
builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<EmailSender, EmailSender>();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
    options.LoginPath = $"/login";
    options.LogoutPath = $"/Identity/Account/Logout";
});
// Set the default culture to en-GB
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-GB");

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "usersession";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();
// Configure middleware for browser caching of static files
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Set caching headers for static assets (adjust values as needed)
        ctx.Context.Response.Headers["Cache-Control"] = "public, max-age=604800"; // 1 week
        ctx.Context.Response.Headers["Expires"] = DateTime.UtcNow.AddDays(7).ToString("R");
    }
});
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseXMLSitemap(app.Environment.ContentRootPath);
app.UseRobotsTxt(app.Environment.ContentRootPath);

app.UseExceptionHandler("/Error");
app.UseStatusCodePagesWithReExecute("/Error/{0}");

app.UseRouting();

app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");
//app.MapHub<AdminChatHub>("/AdminchatHub");
app.MapHub<AdminChatHub>("/AdminChatHub", options =>
{
    options.Transports = HttpTransportType.WebSockets;
    options.LongPolling.PollTimeout = TimeSpan.FromMinutes(3);
});

DataSeeding();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "portal",
    pattern: "{area:exists}/{controller=Portal}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");
app.Run();

void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var DbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        DbInitializer.Initialize();
    }
}

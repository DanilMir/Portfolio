using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.DataAccess;
using Portfolio.Entity;
using Portfolio.Middleware;
using Portfolio.Misc;
using Portfolio.Misc.Services.EmailSender;
using Portfolio.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var emailConfig = builder.Configuration
    .GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();

builder.Services.AddDbContext<Context>(opts =>
    opts.UseNpgsql(builder.Configuration.GetConnectionString("sqlConnection")));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => { options.SignIn.RequireConfirmedEmail = false; })
    .AddEntityFrameworkStores<Context>();

builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// app.UseLogger();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
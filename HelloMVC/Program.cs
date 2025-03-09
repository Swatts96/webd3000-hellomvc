using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelloMVC.Data;
using HelloMVC.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<HelloMVCContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HelloMVCContext") ?? throw new InvalidOperationException("Connection string 'HelloMVCContext' not found.")));


// Configure Identity
builder.Services.AddDefaultIdentity<AppUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // Set to true if you require email confirmation
})
.AddEntityFrameworkStores<HelloMVCContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapRazorPages();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();

using LeavManagemnt_.NET6.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LeavManagemnt_.NET6.Configurations;
using AutoMapper;
using LeavManagemnt_.NET6.Contracts;
using LeavManagemnt_.NET6.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using LeavManagemnt_.NET6.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Get connectionString from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// use connectionString for connecting to database with AddDbContext. that is service from dependencyInjection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost",25,"no-reply@leavemanagement.com"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();

using Microsoft.EntityFrameworkCore;
using MovieApp.AutoMapper;
using MovieApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add db context
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"))
);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    // seed data
    AppDbMockDataSeeder.Seed(app);
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TravelPlanner.Data.AppContext;
using TravelPlanner.Models.Configurations;
using TravelPlanner.Services.Services.DestinationServices;
using TravelPlanner.Services.Services.ItineraryServices;
using TravelPlanner.Services.Services.ScheduledEventServices;
using TravelPlanner.Services.Services.TripServices;
using TravelPlanner.Services.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<TravelPlannerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MappingConfiguration));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IItineraryService, ItineraryService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IScheduledEventService, ScheduledEventService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

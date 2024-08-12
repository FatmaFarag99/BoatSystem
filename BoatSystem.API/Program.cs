using BoatRentalSystem.API.Controllers;
using BoatRentalSystem.Application;
using BoatRentalSystem.Core.Interfaces;
using BoatRentalSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<CityService>();

builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<CountryService>();


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


var logDictionary = $"logs\\{DateTime.Now.Year}\\{DateTime.Now.Month}\\{DateTime.Now.Day}";
if (!Directory.Exists(logDictionary))
{
    Directory.CreateDirectory(logDictionary);
}

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341", Serilog.Events.LogEventLevel.Information)
    .WriteTo.File(
       path: Path.Combine(logDictionary, "logs.json"),
       rollingInterval: RollingInterval.Day,
       outputTemplate : "{Timestamp} {Message} {NewLine:1} {Exception:!}"
    ));


builder.Services.AddHangfire(config =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    config.UseSqlServerStorage(connectionString);

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHangfireDashboard("/dashboard");
app.UseHangfireServer();

app.Run();

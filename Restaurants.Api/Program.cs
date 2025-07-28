using Restaurants.Application.Extensions;
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

/* Serilog Section*/
builder.Host.UseSerilog((context, configuration) => 
    configuration
        .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .WriteTo.Console(outputTemplate:"[{Timestamp: dd-MM HH:mm:ss} {SourceContext} {Level:u3}] {Message:lj}{NewLine}{Exception}")
);

var app = builder.Build();

var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.Seed(); 

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

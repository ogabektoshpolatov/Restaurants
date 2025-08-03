using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistance;
using Restaurants.Infrastructure.Repositories;
using Restaurants.Infrastructure.Restaurants;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("RestaurantsDbForSqlServer"); //RestaurantsDb, RestaurantsDbForSqlServer
        services.AddDbContext<RestaurantsDbContext>(options => 
            options.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()); // Database loglarini olish uchun kerak.

        services.AddIdentityApiEndpoints<User>() // eski verisyalarda biz Login, Register, etc.. funcsiyalarni qo`lda yozardek controller ochib endi esa {AddIdentityApiEndpoints} shularni barchasini avtomatik Controller sifatida qo`shadi
            .AddEntityFrameworkStores<RestaurantsDbContext>();
                
        services.AddScoped<IRestaurantSeeder, RestaurantSeeder>();
        services.AddScoped<IRestaurantsRepository, RestaurantsRepository>();
        services.AddScoped<IDishesRepository, DishesRepository>();

    }
}


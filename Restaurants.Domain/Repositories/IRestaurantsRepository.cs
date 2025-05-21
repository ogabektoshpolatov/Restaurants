using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;
public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();
    Task<Restaurant?> GetByIdAsync(int id);
}


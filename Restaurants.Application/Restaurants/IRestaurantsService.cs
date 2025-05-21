using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Restaurants
{
    public interface IRestaurantsService
    {
        Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
        Task<RestaurantDto?> GetById(int id);
    }
}

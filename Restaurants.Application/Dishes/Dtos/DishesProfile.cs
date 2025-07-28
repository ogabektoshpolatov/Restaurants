using System.Net.Http.Headers;
using AutoMapper;
using Restaurants.Application.Dishes.Commands;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.Dtos;

public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<CreateDishCommand, Dish>();
        CreateMap<Dish, DishDto>();
    }   
}
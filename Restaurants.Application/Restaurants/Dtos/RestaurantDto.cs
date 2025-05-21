﻿using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

public class RestaurantDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Category { get; set; } = default!;
    public bool HasDelivery { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
    public List<DishDto> Dishes { get; set; } = new();

    public static RestaurantDto? FromEntity(Restaurant restaurant)
    {
        if(restaurant == null) return null;
        return new RestaurantDto()
        {
            Category = restaurant.Category,
            Description = restaurant.Description,
            Id = restaurant.Id,
            Dishes = restaurant.Dishes.Select(DishDto.FromEntity).ToList()
        };
    }
}
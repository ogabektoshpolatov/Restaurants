using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandlar:IRequestHandler<CreateRestaurantCommand, int>
{
    public Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
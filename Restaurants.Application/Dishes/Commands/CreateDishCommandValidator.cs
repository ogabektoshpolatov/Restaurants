using FluentValidation;

namespace Restaurants.Application.Dishes.Commands;

public class CreateDishCommandValidator:AbstractValidator<CreateDishCommand>
{
    public CreateDishCommandValidator()
    {
        RuleFor(dish => dish.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be non-negative number");
        
        RuleFor(dish => dish.KiloCalories)
            .GreaterThanOrEqualTo(0)
            .WithMessage("KiloCalories must be none-negative number");
    }
}
using FluentValidation;

namespace FusionSoapService.Contracts.Data
{
    public class AddressValidator : AbstractValidator<Address> {
        public AddressValidator()
        {
            RuleFor(address => address.Address1)
                .NotNull()
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Address1 must not be null and no more than 50 characters.");

            RuleFor(address => address.Address2).Length(1, 50).WithMessage("Address2 must not be more than 50 characters.");

            RuleFor(address => address.City)
                .NotNull()
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("City must not be null and no more than 50 characters.");

            RuleFor(address => address.State)
                .NotNull()
                .NotEmpty()
                .Length(1, 2)
                .WithMessage("State must be two characters.");

            RuleFor(address => address.GeoLocation)
                .NotNull()
                .WithMessage("Geo location must not be null.");
        }
    }
}
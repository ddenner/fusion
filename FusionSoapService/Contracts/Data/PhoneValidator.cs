using FluentValidation;

namespace FusionSoapService.Contracts.Data
{
    public class PhoneValidator : AbstractValidator<Phone> 
    {
        public PhoneValidator()
        {
            RuleFor(phone => phone.Number)
                .NotNull()
                .NotEmpty()
                .Length(1, 255)
                .WithMessage("Phone number must be 9 characters.");
        }
    }
}
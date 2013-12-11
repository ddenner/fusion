using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace FusionSoapService.Contracts.Data
{
    public class PersonNameValidator : AbstractValidator<PersonName> 
    {
        public PersonNameValidator()
        {
            RuleFor(person => person.FirstName)
                .NotNull()
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("First name must not be null and no more than 50 characters.");

            RuleFor(person => person.LastName)
                .NotNull()
                .NotEmpty()
                .Length(1, 50)
                .WithMessage("Last name must not be null and no more than 50 characters.");
        }
    }
}
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.ReturnDate).NotEmpty();
            RuleFor(r => r.RentDate).Must(BeValidDate).WithMessage("Hatalı tarih girildi");

        }

        private bool BeValidDate(DateTime arg)
        {
            return DateTime.Equals(default, arg);
        }
    }
}

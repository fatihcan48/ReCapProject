using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>  // CarValidator, bir IValidator sınıfı oluyor..
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelName).NotEmpty();
            RuleFor(p => p.ModelName).MinimumLength(2);
            RuleFor(p => p.DailyPrice).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.ModelYear).InclusiveBetween((short)2000,(short)DateTime.Now.Year);
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();

        }
    }
}

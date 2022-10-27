using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.ProfessionRepository.Validation
{
    public class ProfessionValidator : AbstractValidator<Profession>
    {
        public ProfessionValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Meslek adý boþ olamaz!");
            RuleFor(c => c.Name).NotNull().WithMessage("Meslek adý boþ olamaz!");
        }
    }
}

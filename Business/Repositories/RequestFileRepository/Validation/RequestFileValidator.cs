using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.RequestFileRepository.Validation
{
    public class RequestFileValidator : AbstractValidator<RequestFile>
    {
        public RequestFileValidator()
        {
        }
    }
}

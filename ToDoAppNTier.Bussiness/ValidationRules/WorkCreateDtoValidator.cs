using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.Dtos.WorkDtos;

namespace ToDoAppNTier.Bussiness.ValidationRules
{
    public class WorkCreateDtoValidator : AbstractValidator<WorkCreateDto> 
    {
        public WorkCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty().WithMessage("Definition is required").When(x => x.IsCompleted).Must(NotBeYavuz);  
        }

        private bool NotBeYavuz(string arg)
        {
            return arg != "Yavuz" && arg != "yavuz";
        }
    }
}

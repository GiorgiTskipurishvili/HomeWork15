using FluentValidation;
using Homework15.Controllers;
using System;

namespace Homework15
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.CreateDate).LessThanOrEqualTo(DateTime.Today)
             .WithMessage("must not be greater than today.");

            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Firstname should not be empty")
                .Length(0,50).WithMessage("Firstname should be between 1 and 50");
            RuleFor(x => x.Lastname).NotEmpty().WithMessage("Lastname should not be empty")
                 .Length(0, 50).WithMessage("Lastname should be between 1 and 50");
            RuleFor(x => x.JobPosition).NotEmpty().WithMessage("JobPosition should not be empty")
                 .Length(0, 50).WithMessage("JobPosition should be between 1 and 50");


            RuleFor(x => x.Salary).InclusiveBetween(0, 10000).WithMessage("Salary must be betweeen 0 and 10000");

            RuleFor(x => x.WorkExperience).NotEmpty()
            .WithMessage("WorkExperience must not be empty.");

            RuleFor(x => x.PersonAddress).SetValidator(new AdressValidator());

        }
    }


    public class AdressValidator : AbstractValidator<Adress>
    {
        public AdressValidator()
        {
            RuleFor(x => x.Country).NotEmpty()
            .WithMessage("Country must not be empty.");
            RuleFor(x => x.City).NotEmpty()
                .WithMessage("City must not be empty.");
            RuleFor(x => x.HomeNumber).NotEmpty()
                .WithMessage("HomeNumber must not be empty.");
        }
    }
}

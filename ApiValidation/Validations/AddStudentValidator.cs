using System;
using ApiValidation.Models;
using FluentValidation;

namespace ApiValidation.Validations
{
	public class AddStudentValidator : AbstractValidator<AddStudentInputModel>
	{
		public AddStudentValidator()
		{
			RuleFor(m => m.FullName)
				.NotEmpty()
					.WithMessage("Full name must not be null or empty")
				.MaximumLength(50)
					.WithMessage("Full name length be less than 50")
				.MinimumLength(5)
					.WithMessage("Full name length must be than 5");

			RuleFor(m => m.BirthDate)
				.LessThan(DateTime.Now.Date)
					.WithMessage("Data de nascimento tem que ser menor que hoje");

			RuleFor(m => m.Document)
				.Must(d => d.IsValidDocument())
					.WithMessage("Document is invalid");

		}
	}
}


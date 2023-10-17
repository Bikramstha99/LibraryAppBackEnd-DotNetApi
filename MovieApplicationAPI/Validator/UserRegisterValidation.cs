using FluentValidation;
using MovieAppAPI.Dto;
using System.Text.RegularExpressions;

namespace MovieAppAPI.Validator
{
    public class UserRegisterValidation : AbstractValidator<RegisterDto>
    {
        public UserRegisterValidation()
        {
            RuleFor(x => x.FirstName)
               .NotNull().NotEmpty().WithMessage("Enter your first name.")
               .MaximumLength(100).WithMessage("First Name cannot be longer than 100 words.");

            RuleFor(x => x.LastName)
                .NotNull().NotEmpty().WithMessage("Enter your last name.")
                .MaximumLength(100).WithMessage("First Name cannot be longer than 100 words.");

            RuleFor(x => x.Email.Trim().ToLower())
                .NotNull().NotEmpty().WithMessage("Enter your email address.")
                .MaximumLength(100).WithMessage("Email cannot be longer than 100 words")
                .Must(email => ValidEmail(email)).WithMessage("Invalid email format.");

        }

        public static bool ValidEmail(string email)
        {
            const string emailRegex =
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            return new Regex(emailRegex).IsMatch(email);
        }
    }
}

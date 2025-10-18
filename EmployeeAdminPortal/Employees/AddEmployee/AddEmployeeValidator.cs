using FluentValidation;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    public class AddEmployeeValidator : AbstractValidator<AddEmployeeRequest>
    {
        public AddEmployeeValidator()
        {
            this.RuleFor(x => x.Employee.FirstName)
                .Matches("^[a-zA-Z\\s]+$").WithMessage("Name should not contain numbers.")
                .NotEmpty();

            this.RuleFor(x => x.Employee.LastName)
                .Matches("^[a-zA-Z\\s]+$").WithMessage("Name should not contain numbers.")
                .NotEmpty();

            this.RuleFor(x => x.Employee.Phone)
                .NotEmpty()
                .Matches(@"^\+?\d{1,4}?[-.\s]?\(?\d{1,3}?\)?[-.\s]?\d{1,4}[-.\s]?\d{1,4}[-.\s]?\d{1,9}$")
                .WithMessage("Phone number is not valid.");
        }
    }
}
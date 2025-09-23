using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using EmployeeAdminPortal.Services.Validators; // Додаємо using для нового валідатора
using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Common;

namespace EmployeeAdminPortal.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly EmployeeValidator _employeeValidator;

        public EmployeesService(ApplicationDbContext dbContext, EmployeeValidator employeeValidator)
        {
            this._dbContext = dbContext;
            this._employeeValidator = employeeValidator;
        }

        public Result<AddEmployeeOutput> AddEmployee(AddEmployeeInput input)
        {
            this._dbContext.Add(input.Employee);
            this._dbContext.SaveChanges();

            return Result<AddEmployeeOutput>.Success(new AddEmployeeOutput());
        }

        public Result<GetEmployeeOutput> GetEmployee(GetEmployeeInput input)
        {
            var employee = this._dbContext
                .Set<Employee>()
                .FirstOrDefault(e => !e.IsDeleted && e.EmployeeId == input.EmployeeId);

            if (employee == null)
            {
                return Result<GetEmployeeOutput>.Failure("Employee not found.");
            }

            return Result<GetEmployeeOutput>.Success(new GetEmployeeOutput { Employee = employee });
        }

        public Result<DeleteEmployeeOutput> DeleteEmployee(DeleteEmployeeInput input)
        {
            var employee = this._dbContext
                .Set<Employee>()
                .FirstOrDefault(e => e.EmployeeId == input.EmployeeId && !e.IsDeleted);

            if (employee == null)
            {
                return Result<DeleteEmployeeOutput>.Failure("Employee not found.");
            }

            employee.IsDeleted = true;
            this._dbContext.SaveChanges();

            return Result<DeleteEmployeeOutput>.Success(new DeleteEmployeeOutput());
        }

        public Result<UpdateEmployeeOutput> UpdateEmployee(Guid id, UpdateEmployeeInput input)
        {
            var employee = this._dbContext.Set<Employee>()
                .FirstOrDefault(e => e.EmployeeId == id && !e.IsDeleted);

            if (employee == null)
            {
                return Result<UpdateEmployeeOutput>.Failure("Employee not found.");
            }

            employee.Name = input.Employee.Name;
            employee.Email = input.Employee.Email;

            this._dbContext.SaveChanges();

            return Result<UpdateEmployeeOutput>.Success(new UpdateEmployeeOutput());
        }
    }
}
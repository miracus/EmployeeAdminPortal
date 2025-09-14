using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using Microsoft.EntityFrameworkCore;
using EmployeeAdminPortal.Common; // Додаємо using

namespace EmployeeAdminPortal.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DbContext _dbContext;

        public EmployeesService(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
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
                // Повертаємо Result з помилкою, якщо співробітника не знайдено
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

        public Result<UpdateEmployeeOutput> UpdateEmployee(UpdateEmployeeInput input)
        {
            var employee = this._dbContext.Set<Employee>()
                .FirstOrDefault(e => e.EmployeeId == input.Employee.EmployeeId && !e.IsDeleted);

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
using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly DbContext _dbContext;

        public EmployeesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AddEmployeeOutput AddEmployee(AddEmployeeInput input)
        {
            _dbContext.Add(input.Employee);
            _dbContext.SaveChanges();

            return new AddEmployeeOutput { Success = true };
        }

        public GetEmployeeOutput GetEmployee(GetEmployeeInput input)
        {
            var employee = _dbContext
                .Set<Employee>()
                .Where(e => !e.IsDeleted && e.Id == input.EmployeeId)
                .FirstOrDefault();

            return new GetEmployeeOutput { Employee = employee };
        }

        public DeleteEmployeeOutput DeleteEmployee(DeleteEmployeeInput input)
        {
            var employee = _dbContext
                .Set<Employee>()
                .FirstOrDefault(e => e.Id == input.EmployeeId && !e.IsDeleted);

            if (employee == null)
                return new DeleteEmployeeOutput { Success = false };

            employee.IsDeleted = true;
            _dbContext.SaveChanges();

            return new DeleteEmployeeOutput { Success = true };
        }

        public UpdateEmployeeOutput UpdateEmployee(UpdateEmployeeInput input)
        {
            var employee = _dbContext.Set<Employee>()
                .FirstOrDefault(e => e.Id == input.EmployeeId && !e.IsDeleted);

            if (employee == null)
                return new UpdateEmployeeOutput { Success = false };

            employee.Name = input.Employee.Name;
            employee.Email = input.Employee.Email;

            _dbContext.SaveChanges();

            return new UpdateEmployeeOutput { Success = true };
        }
    }
}

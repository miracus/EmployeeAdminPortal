using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Services.Validators
{
    public class EmployeeValidator
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeValidator(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> EmployeeExists(Guid employeeId)
        {
            return await _dbContext.Employees.AnyAsync(e => e.EmployeeId == employeeId && !e.IsDeleted);
        }
    }
}
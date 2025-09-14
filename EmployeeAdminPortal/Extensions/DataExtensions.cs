using EmployeeAdminPortal.Employees.AddEmployee;
using EmployeeAdminPortal.Employees.DeleteEmployee;
using EmployeeAdminPortal.Employees.GetEmployee;
using EmployeeAdminPortal.Employees.UpdateEmployee;
using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAdminPortal.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            return services.AddScoped<IEmployeesService, EmployeesService>()
                .AddScoped<AddEmployeeMapper>()
                .AddScoped<GetEmployeeMapper>()
                .AddScoped<DeleteEmployeeMapper>()
                .AddScoped<UpdateEmployeeMapper>();
        }
    }
}
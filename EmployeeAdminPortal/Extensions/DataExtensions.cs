using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeAdminPortal.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            return services.AddScoped<IEmployeesService, EmployeesService>();
        }
    }
}
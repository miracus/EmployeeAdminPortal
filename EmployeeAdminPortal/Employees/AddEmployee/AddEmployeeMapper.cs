using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Employees.AddEmployee.Dtos;
using Riok.Mapperly.Abstractions;

namespace EmployeeAdminPortal.Employees.AddEmployee
{
    [Mapper]
    public partial class AddEmployeeMapper
    {
        [MapPropertyFromSource(target: nameof(Employee.Name), Use = nameof(MapEmployeeFullName))]
        [MapPropertyFromSource(target: nameof(Employee.IsDeleted), Use = nameof(GetIsDeletedValue))]
        [MapPropertyFromSource(target: nameof(Employee.Phone), Use = nameof(GetDefaultPhone))]
        [MapPropertyFromSource(target: nameof(Employee.Salary), Use = nameof(GetDefaultSalary))]
        public partial Employee Map(EmployeeDto dto);

        public partial AddEmployeeInput Map(AddEmployeeRequest request);

        private static string MapEmployeeFullName(EmployeeDto dto) => $"{dto.FirstName} {dto.LastName}";
        private static bool GetIsDeletedValue(EmployeeDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return false;
        }

        private static string GetDefaultPhone(EmployeeDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return string.Empty;
        }

        private static int GetDefaultSalary(EmployeeDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            return 0;
        }
    }

}

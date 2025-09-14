using EmployeeAdminPortal.Models.Inputs;

namespace EmployeeAdminPortal.Employees.DeleteEmployee
{
    public static class DeleteEmployeeMapper
    {
        public static DeleteEmployeeInput Map(DeleteEmployeeRequest request)
        {
            return new DeleteEmployeeInput
            {
                EmployeeId = request.EmployeeId
            };
        }
    }
}
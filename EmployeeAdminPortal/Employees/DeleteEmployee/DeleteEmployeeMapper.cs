using EmployeeAdminPortal.Models.Inputs;
using EmployeeAdminPortal.Models.Outputs;

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

        public static DeleteEmployeeResponse Map(DeleteEmployeeOutput output)
        {
            return new DeleteEmployeeResponse
            {
                Success = output.Success
            };
        }
    }
}
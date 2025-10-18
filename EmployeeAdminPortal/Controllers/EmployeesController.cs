using EmployeeAdminPortal.Employees.AddEmployee;
using EmployeeAdminPortal.Employees.DeleteEmployee;
using EmployeeAdminPortal.Employees.GetEmployee;
using EmployeeAdminPortal.Employees.UpdateEmployee;
using EmployeeAdminPortal.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddEmployee(
            [FromBody] AddEmployeeRequest request,
            AddEmployeeMapper addEmployeeMapper,
            IValidator<AddEmployeeRequest> addEmployeeValidator,
            IEmployeesService employeesService)
        {
            var validationResult = await addEmployeeValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return this.BadRequest(validationResult.Errors);

            var input = addEmployeeMapper.Map(request);
            var result = employeesService.AddEmployee(input);

            if (result.IsFailure)
                return this.StatusCode(444, new { ErrorCode = "EmployeeAlreadyExists", Message = result.ErrorMessage });

            return this.Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(GetEmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployee(
            Guid id,
            GetEmployeeMapper getEmployeeMapper,
            IEmployeesService employeesService)
        {
            var input = new GetEmployeeRequest { EmployeeId = id };
            var mappedInput = getEmployeeMapper.Map(input);
            var result = employeesService.GetEmployee(mappedInput);

            if (result.IsFailure || result.Value == null)
                return this.NotFound();

            return this.Ok(result.Value);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(
            Guid id,
            DeleteEmployeeMapper deleteEmployeeMapper,
            IEmployeesService employeesService)
        {
            var input = new DeleteEmployeeRequest { EmployeeId = id };
            var mappedInput = deleteEmployeeMapper.Map(input);
            var result = employeesService.DeleteEmployee(mappedInput);

            if (result.IsFailure)
                return this.NotFound();

            return this.Ok();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmployee(
            Guid id,
            UpdateEmployeeRequest request,
            UpdateEmployeeMapper updateEmployeeMapper,
            IEmployeesService employeesService)
        {
            var input = updateEmployeeMapper.Map(request);
            input.Employee.EmployeeId = id;
            var result = employeesService.UpdateEmployee(input);

            if (result.IsFailure)
                return this.NotFound();

            return this.Ok();
        }
    }
}

using EmployeeAdminPortal.Employees;
using EmployeeAdminPortal.Employees.AddEmployee;
using EmployeeAdminPortal.Employees.DeleteEmployee;
using EmployeeAdminPortal.Employees.GetEmployee;
using EmployeeAdminPortal.Employees.UpdateEmployee;
using EmployeeAdminPortal.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            this._employeesService = employeesService;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var input = AddEmployeeMapper.Map(request);
            var result = this._employeesService.AddEmployee(input);

            if (result.IsFailure)
            {
                return BadRequest(result.ErrorMessage);
            }

            return Ok();
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(GetEmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployee(Guid id)
        {
            var input = new GetEmployeeRequest { EmployeeId = id };
            var mappedInput = GetEmployeeMapper.Map(input);
            var result = _employeesService.GetEmployee(mappedInput);

            if (result.IsFailure)
            {
                return NotFound();
            }

            var response = GetEmployeeMapper.Map(result.Value);
            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(Guid id)
        {
            var input = new DeleteEmployeeRequest { EmployeeId = id };
            var mappedInput = DeleteEmployeeMapper.Map(input);
            var result = this._employeesService.DeleteEmployee(mappedInput);

            if (result.IsFailure)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            request.EmployeeId = id;
            var input = UpdateEmployeeMapper.Map(request);

            if (input == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = this._employeesService.UpdateEmployee(input);

            if (result.IsFailure)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
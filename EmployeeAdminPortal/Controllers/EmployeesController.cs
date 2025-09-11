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
            _employeesService = employeesService;
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(AddEmployeeResponse), StatusCodes.Status200OK)]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var input = AddEmployeeMapper.Map(request);
            var output = _employeesService.AddEmployee(input);
            var response = AddEmployeeMapper.Map(output);
            return Ok(response);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(UpdateEmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmployee(Guid id)
        {
            var input = new GetEmployeeRequest { EmployeeId = id };
            var mappedInput = GetEmployeeMapper.Map(input);

            var output = _employeesService.GetEmployee(mappedInput);
            var response = GetEmployeeMapper.Map(output);

            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(DeleteEmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(Guid id)
        {
            var input = new DeleteEmployeeRequest { EmployeeId = id };
            var mappedInput = DeleteEmployeeMapper.Map(input);

            var output = _employeesService.DeleteEmployee(mappedInput);
            var response = DeleteEmployeeMapper.Map(output);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(UpdateEmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateEmployee(Guid id, [FromBody] UpdateEmployeeRequest request)
        {
            request.EmployeeId = id;

            var input = UpdateEmployeeMapper.Map(request);

            if (input == null)
            {
                return BadRequest();
            }
                
            var output = _employeesService.UpdateEmployee(input);

            if (!output.Success)
                return NotFound();

            var response = UpdateEmployeeMapper.Map(output);

            return Ok(response);
        }
    }
}

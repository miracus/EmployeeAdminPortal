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
        private readonly AddEmployeeMapper _addEmployeeMapper;
        private readonly GetEmployeeMapper _getEmployeeMapper;
        private readonly DeleteEmployeeMapper _deleteEmployeeMapper;
        private readonly UpdateEmployeeMapper _updateEmployeeMapper;

        public EmployeesController(
            IEmployeesService employeesService,
            AddEmployeeMapper addEmployeeMapper,
            GetEmployeeMapper getEmployeeMapper,
            DeleteEmployeeMapper deleteEmployeeMapper,
            UpdateEmployeeMapper updateEmployeeMapper)
        {
            this._employeesService = employeesService;
            this._addEmployeeMapper = addEmployeeMapper;
            this._getEmployeeMapper = getEmployeeMapper;
            this._deleteEmployeeMapper = deleteEmployeeMapper;
            this._updateEmployeeMapper = updateEmployeeMapper;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddEmployee([FromBody] AddEmployeeRequest request)
        {
            var input = _addEmployeeMapper.Map(request);
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
            var mappedInput = _getEmployeeMapper.Map(input);
            var result = _employeesService.GetEmployee(mappedInput);

            if (result.IsFailure || result.Value == null)
            {
                return NotFound();
            }

            var response = _getEmployeeMapper.Map(result.Value);
            return Ok(response);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(Guid id)
        {
            var input = new DeleteEmployeeRequest { EmployeeId = id };
            var mappedInput = _deleteEmployeeMapper.Map(input);
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
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeRequest request)
        {
            var input = _updateEmployeeMapper.Map(request);

            if (input == null)
            {
                return BadRequest("Invalid request data.");
            }

            var result = this._employeesService.UpdateEmployee(id, input);

            if (result.IsFailure)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
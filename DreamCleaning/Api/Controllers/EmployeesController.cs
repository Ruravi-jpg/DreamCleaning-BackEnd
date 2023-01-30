using DC.WebApi.Api.Models;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain;
using DC.WebApi.Core.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DC.WebApi.Api.Controllers
{
    [ApiController]
    //[Authorize(Roles = nameof(UserRole.SuperAdmin))]
    [Route("api/" + Constants.SecuredApiPath + "/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class EmployeesController : DCController
    {
        private readonly IEmployeeDomain _employeeDomain;
        private readonly IUserDomain _userDomain;

        public EmployeesController(IEmployeeDomain employeeDomain, IUserDomain userDomain)
        {
            _employeeDomain = employeeDomain;
            _userDomain = userDomain;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<EmployeeViewModel>> Get(CancellationToken token)
        {
            var employees = await _employeeDomain.GetAllAsync(token);

            return  EmployeeViewModel.FromList(employees);
        }


        [HttpGet("inactive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<EmployeeViewModel>> GetInactive(CancellationToken token)
        {
            var employees = await _employeeDomain.GetAllInactiveAsync(token);

            return EmployeeViewModel.FromList(employees);
        }


        [HttpGet("{idEmp}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<EmployeeViewModel>> Get([FromRoute] long idEmp, CancellationToken token)
        {
            var vision = await _employeeDomain.FindByIdAsync(idEmp, token);

            if (vision == default)
                return NotFound();

            return Ok(new EmployeeViewModel(vision));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] EmployeeCreateModel employee, CancellationToken token)
        {
            var employeeDb = await _employeeDomain.CreateEmployeeAsync(employee, token);
            return CreatedAtAction(nameof(Get), new { IdEmp = employeeDb.Id }, null);
        }


        [HttpPut("{idEmp}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put([FromRoute] long idEmp, [FromBody] EmployeeUpdateModel employee, CancellationToken token)
        {
            var employeeDb = await _employeeDomain.FindByIdAsync(idEmp, token);

            if (employeeDb == default)
            {
                employeeDb = await _employeeDomain.FindInactiveByIdAsync(idEmp, token);
                if (employeeDb == default)
                    return NotFound();
            }

            await _employeeDomain.UpdateAsync(employeeDb, employee, token);
            return NoContent();
        }


        [HttpDelete("{idEmp}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long idEmp, CancellationToken token)
        {
            var eDb = await _employeeDomain.FindByIdAsync(idEmp, token);

            if (eDb == default)
                return NotFound();

            await _employeeDomain.DeleteAsync(eDb, token);
            return NoContent();
        }
    }
}

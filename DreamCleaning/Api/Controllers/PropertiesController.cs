using DC.WebApi.Api.Models;
using DC.WebApi.Core.Domain.Models;
using DC.WebApi.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using DC.WebApi.Core.Data.Entities;

namespace DC.WebApi.Api.Controllers
{

    [ApiController]
    [Authorize(Roles = nameof(UserRole.SuperAdmin))]
    [Route("api/" + Constants.SecuredApiPath + "/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PropertiesController : DCController
    {
        private readonly IPropertyDomain _propertyDomain;

        public PropertiesController(IPropertyDomain propertyDomain)
        {
            _propertyDomain = propertyDomain;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<PropertyViewModel>> Get(CancellationToken token)
        {
            var properties = await _propertyDomain.GetAllAsync(token);

            return PropertyViewModel.FromList(properties);
        }


        [HttpGet("inactive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        [AllowAnonymous]
        public async Task<IList<PropertyViewModel>> GetInactive(CancellationToken token)
        {
            var properties = await _propertyDomain.GetAllInactiveAsync(token);

            return PropertyViewModel.FromList(properties);
        }


        [HttpGet("{idProp}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<PropertyViewModel>> Get([FromRoute] long idProp, CancellationToken token)
        {
            var property = await _propertyDomain.FindByIdAsync(idProp, token);

            if (property == default)
                return NotFound();

            return Ok(new PropertyViewModel(property));
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] PropertyCreateModel property, CancellationToken token)
        {
            var propertyDb = await _propertyDomain.CreatePropertyAsync(property, token);
            return CreatedAtAction(nameof(Get), new { IdProp = propertyDb.Id }, null);
        }


        [HttpPut("{idProp}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put([FromRoute] long idProp, [FromBody] PropertyUpdateModel property, CancellationToken token)
        {
            var propertyDb = await _propertyDomain.FindByIdAsync(idProp, token);

            if (propertyDb == default)
            {
                propertyDb = await _propertyDomain.FindInactiveByIdAsync(idProp, token);
                if (propertyDb == default)
                    return NotFound();
            }

            await _propertyDomain.UpdateAsync(propertyDb, property, token);
            return NoContent();
        }


        [HttpDelete("{idProp}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long idProp, CancellationToken token)
        {
            var propertyDb = await _propertyDomain.FindByIdAsync(idProp, token);

            if (propertyDb == default)
                return NotFound();

            await _propertyDomain.DeleteAsync(propertyDb, token);
            return NoContent();
        }
    }
}

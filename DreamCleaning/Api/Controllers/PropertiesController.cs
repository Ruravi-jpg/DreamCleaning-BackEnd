using DC.WebApi.Api.Models;
using DC.WebApi.Core.Domain.Models;
using DC.WebApi.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Api.Services.Permissions;
using DC.WebApi.Api.Services;
using Npgsql.Replication.PgOutput.Messages;

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
        private readonly IPropertyPermissionService _permisionService;

        public PropertiesController(IPropertyDomain propertyDomain, IPropertyPermissionService permisionService)
        {
            _propertyDomain = propertyDomain;
            _permisionService = permisionService;
        }

        [HttpGet]
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
        public async Task<IList<PropertyViewModel>> GetInactive(CancellationToken token)
        {
            var properties = await _propertyDomain.GetAllInactiveAsync(token);

            return PropertyViewModel.FromList(properties);
        }


        [HttpGet("{idProp}")]
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

        [HttpGet("images/{id}/{guid}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Text.Plain)]
        public async Task<IActionResult> GetImage([FromRoute] long id, [FromRoute] string guid, CancellationToken token)
        {
            var imagePath = await _propertyDomain.GetImagesPath(id, guid, token);

            if (imagePath == default)
                NotFound();
            try
            {

            }
            catch (DirectoryNotFoundException)
            {
                NotFound();
                throw;
            }
            byte[] bytes = System.IO.File.ReadAllBytes(imagePath);
            string mimeType = Constants.GetMimeType(guid);
            return File(bytes, mimeType);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] PropertyCreateModel property, CancellationToken token)
        {
            _permisionService.EnsureCanCreateProperty(UserJwt);
            var propertyDb = await _propertyDomain.CreatePropertyAsync(property, token);
            return CreatedAtAction(nameof(Get), new { idProp = propertyDb.Id }, null);
        }

        [HttpPost("images/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes("multipart/form-data")]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> PostImages([FromForm] IFormCollection images, [FromRoute] long id, CancellationToken token)
        {

            _permisionService.EnsureCanModifyProperty(UserJwt);

            var property = await _propertyDomain.FindByIdAsync(id, token);

            if (property == default)
                return NotFound();

            if (images == null)
                throw new ArgumentNullException(nameof(images));
            if (images.Files == null)
                throw new ArgumentNullException(nameof(images));

            //if(images.Files.Count == 0)
            //    return NoContent();

            await _propertyDomain.AddPhotosAsync(images.Files, property, token);
            return NoContent();

        }

        [HttpPut("{idProp}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put([FromRoute] long idProp, [FromBody] PropertyUpdateModel property, CancellationToken token)
        {

            _permisionService.EnsureCanModifyProperty(UserJwt);

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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long idProp, CancellationToken token)
        {
            _permisionService.EnsureCanModifyProperty(UserJwt);

            var propertyDb = await _propertyDomain.FindByIdAsync(idProp, token);

            if (propertyDb == default)
                return NotFound();

            await _propertyDomain.DeleteAsync(propertyDb, token);
            return NoContent();
        }

        [HttpPost("{propId}/workUnit")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> PostWorkUnit([FromRoute] long propId, [FromBody] List<WorkUnitCreateModel> workUnitCreateModel, CancellationToken token)
        {
            var propertyDb = await _propertyDomain.FindByIdAsync(propId, token);

            if (propertyDb == default)
                return NotFound();

            var workUnitDb = await _propertyDomain.CreateWorkUnit(propertyDb, workUnitCreateModel, token);
            return Ok(workUnitDb);
        }

        [HttpGet("workUnits/{employeeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<WorkUnitViewModelEmployee>> GetEmployeeWorkUnits([FromRoute] long employeeId, CancellationToken token)
        {
            var workUnits = await _propertyDomain.GetEmployeeWorkunitsAsync(employeeId, token);

            return WorkUnitViewModelEmployee.FromList(workUnits);
        }

        [HttpGet("{propId}/workUnits")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<WorkUnitViewModelProperty>> GetPropertyWorkUnits([FromRoute] long propId, CancellationToken token)
        {
            var workUnits = await _propertyDomain.GetPropertyWorkunitsAsync(propId, token);

            return WorkUnitViewModelProperty.FromList(workUnits);
        }

        [HttpDelete("workUnits")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteWorkUnits([FromBody]List<long> workunitsId, CancellationToken token)
        {
            _permisionService.EnsureCanModifyProperty(UserJwt);

            foreach (var workUnitId in workunitsId)
            {
                var workUnit = await _propertyDomain.FindWorkUnitByIdAsync(workUnitId, token);

                if (workUnit == default)
                    continue;

                await _propertyDomain.DeleteWorkUnitAsync(workUnit, token);

            }
            
            return NoContent();
        }

        [HttpPut("{propId}/workUnits/{workUnitId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> PutWorkUnit([FromRoute] long propId, [FromRoute] long workUnitId, [FromBody] WorkUnitUpdateModel workUnit, CancellationToken token)
        {

            _permisionService.EnsureCanModifyProperty(UserJwt);

            var workUnitDb = await _propertyDomain.FindWorkUnitByIdAsync(workUnitId, token);

            if (workUnitDb == default)
                return NotFound();
            

            await _propertyDomain.UpdateWorkUnit(workUnitDb, workUnit, token);


            return NoContent();
        }
    }
}

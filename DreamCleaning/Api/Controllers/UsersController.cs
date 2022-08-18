using DC.WebApi.Api.Models;
using DC.WebApi.Api.Services.Permissions;
using DC.WebApi.Core.Data.Entities;
using DC.WebApi.Core.Domain;
using DC.WebApi.Core.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DC.WebApi.Api.Controllers
{
    [ApiController]
    [Authorize(Roles = nameof(UserRole.SuperAdmin))]
    [Route($"api/{Constants.SecuredApiPath}/[controller]")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class UsersController : DCController
    {
        private readonly IUserDomain _domain;
        private readonly IUserPermissionService _permissionService;

        public UsersController(IUserDomain domain, IUserPermissionService userPermision)
        {
            _domain = domain;
            _permissionService = userPermision;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<UserViewModel>> Get(CancellationToken token)
        {
            var users = await _domain.GetAllAsync(token);

            return UserViewModel.FromList(users);
        }

        [HttpGet("inactive")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IList<UserViewModel>> GetInactive( CancellationToken token)
        {
            var users = await _domain.GetAllInactiveAsync(token);

            return UserViewModel.FromList(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserViewModel>> Get([FromRoute] long id, CancellationToken token)
        {
            var user = await _domain.FindByIdAsync(id, token);

            if (user == default)
                return NotFound();

            return Ok(new UserViewModel(user));
        }



        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Post([FromBody] UserCreateModel user, CancellationToken token)
        {
            _permissionService.EnsureCanCreateUser(user, UserJwt);
            var userdb = await _domain.CreateAsync(user, token);
            return CreatedAtAction(nameof(Get), new { id = userdb.Id }, null);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Put([FromRoute] long id, [FromBody] UserUpdateModel user, CancellationToken token)
        {
            var userdb = await _domain.FindByIdAsync(id, token);

            if (userdb == default)
            {
                userdb = await _domain.FindInactiveByIdAsync(id, token);
                if (userdb == default)
                    return NotFound();
            }

            _permissionService.EnsureCanModifyUser(userdb, UserJwt);

            await _domain.UpdateAsync(userdb, user, token);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long id, CancellationToken token)
        {
            var userdb = await _domain.FindByIdAsync(id, token);

            if (userdb == default)
                return NotFound();

            _permissionService.EnsureCanModifyUser(userdb, UserJwt);

            await _domain.DeleteAsync(userdb, token);
            return NoContent();
        }
    }
}

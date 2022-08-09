using DC.WebApi.Api;
using DC.WebApi.Api.Controllers;
using DC.WebApi.Api.Models;
using DC.WebApi.Api.Services;
using DC.WebApi.Core.Domain;
using DreamCleaning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mime;
using System.Security.Claims;
using System.Security.Cryptography;

namespace DreamCleaning.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route($"api/{Constants.LoginApiPath}/[controller]")]
    public class LoginController : DCController
    {
        private readonly IUserDomain _domain;
        private readonly IJwtHelper _jwtHelper;

        public LoginController(IUserDomain domain, IJwtHelper jwtHelper )
        {
            _domain = domain;
            _jwtHelper = jwtHelper;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult<UserTokenViewModel>> Post(LoginModel request, CancellationToken token)
        {
            var userdb = await _domain.FindByAsync(request.Username, request.Password, token);
            if (userdb == default)
                return Unauthorized();

            if (!userdb.IsActive)
                return Unauthorized();

            var userToken = _jwtHelper.GetToken(userdb);

            return Ok(userToken);
        }

        [HttpGet("status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> Get()
        {
            if (User != default && User.Identity != default)
            {
                if (User.Identity.IsAuthenticated)
                    return Ok(true);
            }
            return Ok(false);
        }

        
    }
}

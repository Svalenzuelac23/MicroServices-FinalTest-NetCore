using AFORO255.MS.TEST.Security.DTO;
using AFORO255.MS.TEST.Security.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MS.AFORO255.Cross.Jwt.Src;
using System;

namespace AFORO255.MS.TEST.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAccessService _service;
        private readonly JwtOptions _jwtOption;

        public AuthController(
            IAccessService service
            , IOptionsSnapshot<JwtOptions> jwtOption
            )
        {
            _service = service;
            _jwtOption = jwtOption.Value;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            if(!_service.Validate(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));            

            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Contexts;
using UserService.Entities;
using UserService.Models;
using UserService.Repositories.Interface;
using UserService.Services.Interface;

namespace UserService.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IPartnerRepository _partnerRepository;
        private readonly IUserService _userService;

        public UserController(IPartnerRepository partnerRepository, IUserService userService)
        {
            _partnerRepository = partnerRepository;
            _userService = userService;
        }

        [HttpPost]
        [Route("auth")]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Authenticate([FromForm] AuthenticateRequest request)
        {
            var partner = _partnerRepository.GetPartnerByCredential(request.Username, request.Password);
            if (partner == null) return Unauthorized();

            var token = _userService.GenerateToken(partner);
            return Ok(token);
        }
    }
}

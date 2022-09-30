using Microsoft.AspNetCore.Mvc;
using AdventureWorks2019BE.DTOs.SigeoDTOs;
using AdventureWorks2019BE.Services;

namespace AdventureWorks2019BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly UserService _serviceUser;

        public UserController(ILogger<UserController> logger, UserService serviceUser)
        {
            _logger = logger;
            _serviceUser = serviceUser;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            UserDTO userDto = null;

            try
            {
                userDto = await _serviceUser.getById(id);
            }
            catch (Exception e)
            {
                throw;
            }

            return (userDto != null) ? Ok(userDto) : NotFound();
        }
    }
}

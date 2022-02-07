using FamilyAlbum.Database;
using FamilyAlbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAlbum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var id = User.FindFirst(x => x.Type == "Id")?.Value;
            if (id == null) 
            {
                return BadRequest("Пустой пользователь");
            }
            var currentUser = userRepository.GetUserById(id);
            if (currentUser == null) 
            {
                currentUser = new User { Id = id, FolderPath = $"D:/usr/{id}/", Name = User.FindFirst(x => x.Type == "Email")?.Value };
                await userRepository.AddUserAsync(currentUser);
            }
            return Ok(new { user = currentUser });
        }
    }
}

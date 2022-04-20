using FamilyAlbum.Database;
using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAlbum.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
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
                currentUser = new User { Id = id, FolderPath = $"D:/usr/{id}/",Name = User.FindFirst(x => x.Type == "Name")?.Value, Email = User.FindFirst(x => x.Type.Contains("email"))?.Value };
                await userRepository.AddUserAsync(currentUser);
            }
            return Ok( new { Id = currentUser.Id, Email = currentUser.Email, Name = currentUser.Name } );
        }
    }
}

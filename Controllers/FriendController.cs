using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            if(friendService == null)
                throw new ArgumentNullException(nameof(friendService));
            this.friendService = friendService;
        }

        [HttpGet]
        public IActionResult GetNotificationToFriend(string userId) 
        {
            return Ok(friendService.GetNotoficationToFriend(userId));
        }

        [HttpPost]
        public async Task<IActionResult> AddFriendToUser(TempModel model) 
        {
            await friendService.AddFriendToUser(model.UserId, model.FriendId);
            return Ok();
        }
    }
}

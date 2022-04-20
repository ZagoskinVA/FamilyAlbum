using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FamilyAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IPhotoService photoService;

        public PhotoController(IPhotoRepository photoRepository, IPhotoService photoService)
        {
            if(photoRepository == null)
                throw new ArgumentNullException(nameof(photoRepository));
            if(photoService == null)
                throw new ArgumentNullException(nameof(photoService));
            this.photoRepository = photoRepository;
            this.photoService = photoService;
        }


        [HttpGet]
        public IActionResult GetPhotoes(string userId) 
        {

            return Ok(photoService.GetAllPhotos(userId));
        }

        [HttpPost]
        public async Task<IActionResult> SavePhoto(Photo photo) 
        {
            await photoService.SavePhotoAsync(photo);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePhoto(Photo photo) 
        {
            await photoService.RemovePhotoAsync(photo);
            return Ok();
        }
    }
}

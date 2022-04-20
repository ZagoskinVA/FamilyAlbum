using FamilyAlbum.Interfaces;
using FamilyAlbum.Models;

namespace FamilyAlbum.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IPhotoRepository photoRepository;
        public PhotoService(IPhotoRepository photoRepository)
        {
            if(photoRepository == null)
                throw new ArgumentNullException(nameof(photoRepository));
            this.photoRepository = photoRepository;
        }
        public async Task RemovePhotoAsync(Photo photo)
        {
            await Task.Run(() =>
            {
                photoRepository.RemovePhotoAsync(photo);
                RemovePhotoFromHardDisk(photo);
            });
        }

        public async Task SavePhotoAsync(Photo photo)
        {
            photo.Path = $"D:\\FamiliAlbumPhotoes\\{photo.UserId}\\{photo.Title}";
            var savePhotoContent = SavePhotoToHardDisk(photo);
            await photoRepository.SavePhotoAsync(photo);
            await savePhotoContent;
        }

        public IEnumerable<Photo> GetAllPhotos(string userId)
        {
            var photos = photoRepository.GetUserPhotos(userId).ToList();
            foreach (var photo in photos) 
            {
                photo.Content = GetPhotoFromHardDisk(photo.Path);
            }
            var friendPhoto = photoRepository.GetFriendsPhoto(userId);
            foreach(var photo in friendPhoto) 
            {
                photo.Content = GetPhotoFromHardDisk(photo.Path);
                photos.Add(photo);
            }
            return photos;
        }

        private async Task SavePhotoToHardDisk(Photo photo) 
        {
            var path = $"D:\\FamiliAlbumPhotoes\\{photo.UserId}\\{photo.Title}";
            var dir = new DirectoryInfo($"D:\\FamiliAlbumPhotoes\\{photo.UserId}");
            if (!dir.Exists) 
            {
                Directory.CreateDirectory($"D:\\FamiliAlbumPhotoes\\{photo.UserId}");
            }

            using (var fs = new FileStream(path, FileMode.Create)) 
            {
                var content = photo.Content.Select(x => (byte)x).ToArray();
                await fs.WriteAsync(content, 0, photo.Content.Length);
            }
        }

        private void RemovePhotoFromHardDisk(Photo photo) 
        {
            var path = $"D:\\FamiliAlbumPhotoes\\{photo.UserId}\\{photo.Title}";

            if (File.Exists(path)) 
            {
                File.Delete(path);
            }
        }

        private int[] GetPhotoFromHardDisk(string path) 
        {
            var info = new FileInfo(path);
            if (info.Exists) 
            {
                var data = new byte[info.Length];
                using (var fs = new FileStream(path, FileMode.Open)) 
                {
                    fs.Read(data, 0, data.Length);
                }
                return data.Select(x => (int)x).ToArray();
            }
            return null;
        }
    }
}

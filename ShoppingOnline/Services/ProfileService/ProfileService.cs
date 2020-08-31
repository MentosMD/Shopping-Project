using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShoppingOnline.Models;
using ShoppingOnline.Repository.ProfileRepository;

namespace ShoppingOnline.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProfileService(IProfileRepository profileRepository, IWebHostEnvironment hostEnvironment)
        {
            _profileRepository = profileRepository;
            _hostEnvironment = hostEnvironment;
        }
        public void AddNewProfile(Profile newProfile)
        {
            if (newProfile == null) throw new ArgumentNullException("New profile is null");
            _profileRepository.AddNewEntity(newProfile);
        }

        public void UpdateProfile(Profile updatedProfile)
        {
            if (updatedProfile == null) throw new ArgumentNullException("Update profile is null");
            _profileRepository.UpdateEntity(updatedProfile);
        }

        public Profile GetById(int id)
        {
            return _profileRepository.GetById(id);
        }

        public void UploadImage(IFormFile file, int profileId)
        {
            if (file.Length == 0) throw new ArgumentNullException("File is not found");
            var profile = GetById(profileId);
            var uploads = Path.Combine(_hostEnvironment.WebRootPath, "images");
            string uniqueFileName = GetUniqueFileName(file.FileName);
            var fullPath = Path.Combine(uploads, uniqueFileName);
            if (Directory.Exists(_hostEnvironment.WebRootPath + "\\images\\"))
            {
                Directory.CreateDirectory(_hostEnvironment.WebRootPath + "\\images\\");
            }
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var avatarProfile = new AvatarProfile()
                {
                    Name = uniqueFileName,
                    Extension = Path.GetExtension(uniqueFileName)
                };
                profile.Avatar = avatarProfile;
                UpdateProfile(profile);
            }
        }

        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                   + Guid.NewGuid().ToString().Substring(0, 12)
                   + Path.GetExtension(fileName);
        }
    }
}
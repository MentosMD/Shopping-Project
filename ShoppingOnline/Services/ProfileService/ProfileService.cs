using System;
using ShoppingOnline.Models;
using ShoppingOnline.Repository.ProfileRepository;

namespace ShoppingOnline.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
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
    }
}
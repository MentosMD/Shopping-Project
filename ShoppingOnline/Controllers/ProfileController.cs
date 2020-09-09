using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using ShoppingOnline.Repository.UserRepository;
using ShoppingOnline.Services.ProfileService;
using ShoppingOnline.Validations;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/profile")]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService= profileService;
        }
        
        [Authorize(Roles = Roles.User)]
        [Route("info")]
        public IActionResult GetInfo()
        {
            var userId = HttpContext.User.Identity.Name;
            if (userId == null) throw new ArgumentNullException("User is null");
            var getProfile = _profileService.GetById(int.Parse(userId));
            if (getProfile == null) return BadRequest("Profile is not found");
            var response = new ApiResponse<Profile>()
            {
                StatusCode = 200,
                Result = getProfile
            };
            return Ok(response);
        }
        
        [Authorize(Roles = Roles.User)]
        [Route("update")]
        [HttpPut]
        public IActionResult UpdateProfile([FromBody] ProfileViewModel profileView)
        {
            if (profileView == null) return BadRequest("Fields are empty");
            ProfileModelValidator validator = new ProfileModelValidator();
            var validationResult = validator.Validate(profileView);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
            var profile = _profileService.GetById(int.Parse(HttpContext.User.Identity.Name));
            profile.FName = profileView.FName;
            profile.LName = profileView.LName;
            profile.Age = profileView.Age;
            profile.City = profileView.City;
            profile.Phone = profileView.Phone;
            profile.Address = profileView.Address;
            _profileService.UpdateProfile(profile);
            var response = new ApiResponse<string>()
            {
                StatusCode = 200,
                Result = "Updated"
            };
            return Ok(response);
        }
    
        [Authorize(Roles = Roles.User)]
        [Route("upload/avatar")]
        [HttpPost]
        public IActionResult UploadAvatar([FromForm] IFormFile avatar)
        {
            if (avatar.Length == 0) return BadRequest("Avatar is not found");
            var profileId = int.Parse(HttpContext.User.Identity.Name);
            _profileService.UploadImage(avatar, profileId);
            var response = new ApiResponse<string>()
            {
                StatusCode = 200,
                Result = "Uploaded"
            };
            return Ok(response);
        }
    }
}
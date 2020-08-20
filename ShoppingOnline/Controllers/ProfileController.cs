using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
            return Ok(getProfile);
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
            return Ok("Updated");
        }
    }
}
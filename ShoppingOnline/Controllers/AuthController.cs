using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;
using ShoppingOnline.Services;
using ShoppingOnline.Validations;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("authenticate")]
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel userView)
        {
            if (userView == null)
            {
                return BadRequest("User is not found");
            }
            var validate = new LoginModelValidator();
            var validateResult = validate.Validate(userView);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors);
            }
            var token = _userService.Authenticate(userView);
            var response = new ApiResponse<object>()
            {
                StatusCode = 200,
                Result = token
            };
            return Ok(response);
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody] RegisterViewModel registerView)
        {
            if (registerView == null) throw new ArgumentNullException("Fields are empty"); 
            RegisterModelValidator validator = new RegisterModelValidator();
            var validationResult = validator.Validate(registerView);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            User newUser = new User()
            {
                Email = registerView.Email,
                Password = registerView.Password,
                Role = Roles.User
            };
            Profile createProfile = new Profile()
            {
                FName = registerView.FName,
                LName = registerView.LName
            };
            newUser.Profile = createProfile;
            _userService.AddNewUser(newUser);
            var response = new ApiResponse<string>()
            {
                StatusCode = 200,
                Result = "User is created"
            };
            return Ok(response);
        }
        
        [Authorize(Roles = Roles.User)]
        [Route("password/change")]
        [HttpPut]
        public IActionResult ChangePassword([FromBody] ChangePasswordViewModel passwordModel)
        {
            ChangePasswordModelValidator validator = new ChangePasswordModelValidator();
            var validationResult = validator.Validate(passwordModel);
            if (!validationResult.IsValid) return BadRequest("Password is not match");
            var user = _userService.GetById(int.Parse(HttpContext.User.Identity.Name));
            user.Password = passwordModel.Password;
            _userService.ChangePassword(user);
            var response = new ApiResponse<string>()
            {
                StatusCode = 200,
                Result = "Changed!"
            };
            return Ok(response);
        }
    }
}
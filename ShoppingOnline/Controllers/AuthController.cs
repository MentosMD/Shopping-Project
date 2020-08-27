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
                throw new ArgumentNullException("User is null");
            }
            var validate = new LoginModelValidator();
            var validateResult = validate.Validate(userView);
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult.Errors);
            }
            var token = _userService.Authenticate(userView);
            return Ok(token);
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
            return Ok("User is created");
        }
        
        [Authorize(Roles = Roles.User)]
        [Route("password/change")]
        [HttpPut]
        public IActionResult ChangePassword([FromBody] string password, string repeatPassword)
        {
            if (!password.Equals(repeatPassword)) return BadRequest("Password is not match");
            var user = _userService.GetById(int.Parse(HttpContext.User.Identity.Name));
            user.Password = password;
            _userService.ChangePassword(user);
            return Ok("Changed!");
        }
    }
}
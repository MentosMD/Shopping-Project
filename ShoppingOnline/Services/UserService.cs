using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingOnline.Infrastructure;
using ShoppingOnline.Models;
using ShoppingOnline.Repository.UserRepository;
using ShoppingOnline.ViewModels;

namespace ShoppingOnline.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;
        
        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }
        public object Authenticate(LoginViewModel model)
        {
            var user = _userRepository.GetAll()
                .FirstOrDefault(x => x.Email.Contains(model.Email) && x.Password.Contains(model.Password));
            if (user == null)
                throw new ArgumentNullException("User not found");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.ID.ToString()),
                    new Claim(ClaimTypes.Role, user.Role), 
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            
            return new
            {
                access_token = user.Token
            };
        }

        public User GetById(int id)
        {
            return _userRepository.GetAll().First(u => u.ID == id);
        }

        public void AddNewUser(User newUser)
        {    
            if (IsEmailExisting(newUser.Email)) throw new ArgumentNullException("Email is existing");
            _userRepository.AddNewEntity(newUser);
        }

        public void ChangePassword(User user)
        {
            _userRepository.UpdateEntity(user);
        }

        private bool IsEmailExisting(string email)
        {
            var users = _userRepository.GetAll().FirstOrDefault(u => u.Email == email);
            if (users != null) return true;
            return false;
        }
    }
}
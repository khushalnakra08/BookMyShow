using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyShowTask.Services;
using BookMyShowTask.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using BookMyShowTask.DTO;

namespace BookMyShowTask.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<UserDetail> UserManager;
        private BookMyShowContext BookMyShowContext;
        private readonly IUserService UserService;
        private readonly ITokenService TokenService;
        public UserController(BookMyShowContext bookMyShowContext, UserManager<UserDetail> userManager, IUserService userService, ITokenService tokenService)
        {
            UserManager = userManager;
            BookMyShowContext = bookMyShowContext;
            UserService = userService;
            TokenService = tokenService;
        }
        [HttpGet("")]
        public IEnumerable<UserDetail> GetUserDetails()
        {
            return UserService.GetUserDetails();
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<Object> GetUserProfile()
        {
            string email = User.FindFirst(ClaimTypes.Email).Value;
            var user = await UserManager.FindByEmailAsync(email);
            return new
            {
                user.Email,
                user.UserName,
                user.PhoneNumber
            }; 
        }

        [HttpPost("register")]
        public async Task<Object> AddUser(UserDetailDTO user)
        {
            var userDetail = new UserDetail()
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            try
            {
                var result = await UserManager.CreateAsync(userDetail, user.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(Login login)
        {
            if(login == null)
            {
                return BadRequest("Invalid client request");
            }
            var user = await UserManager.FindByEmailAsync(login.Email);
            if (user != null && await UserManager.CheckPasswordAsync(user, login.Password))
            {
                var claims = new List<Claim>
                {
                new Claim(ClaimTypes.Email, login.Email)
                };
                var accessToken = TokenService.GenerateAccessToken(claims);
                var refreshToken = TokenService.GenerateRefreshToken();
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
                BookMyShowContext.SaveChanges();
                return Ok(new AuthenticateResponse
                {
                    Token = accessToken,
                    RefreshToken = refreshToken
                });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}

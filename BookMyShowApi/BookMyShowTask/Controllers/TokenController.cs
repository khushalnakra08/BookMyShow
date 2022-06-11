using BookMyShowTask.Models;
using BookMyShowTask.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookMyShowTask.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly BookMyShowContext BookMyShowContext;
        private readonly ITokenService TokenService;
        public TokenController(UserManager<UserDetail> userManager, BookMyShowContext bookMyShowContext, ITokenService tokenService)
        {
            BookMyShowContext = bookMyShowContext;
            TokenService = tokenService;
        }
        [HttpPost("refresh")]
        public IActionResult Refresh(Token token)
        {
            if (token is null)
            { return BadRequest("Invalid token request"); }

            else
            {
                string accessToken = token.AccessToken;
                string refreshToken = token.RefreshToken;
                var principal = TokenService.GetPrincipalFromExpiredToken(accessToken);
                if (principal == null)
                {
                    return BadRequest("Invalid access token or refresh token");
                }
                string email = principal.FindFirst(ClaimTypes.Email).Value;
                if (email == null)
                {
                    return BadRequest("Invalid email");
                }
                var user = BookMyShowContext.UserDetail.SingleOrDefault(u => u.Email == email);
                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                { 
                    return BadRequest("Invalid user request"); 
                }
                 var newAccessToken = TokenService.GenerateAccessToken(principal.Claims);
                 var newRefreshToken = TokenService.GenerateRefreshToken();
                 user.RefreshToken = newRefreshToken;
                BookMyShowContext.SaveChanges();
                return new ObjectResult(new AuthenticateResponse()
                 {
                        Token = newAccessToken,
                        RefreshToken = newRefreshToken
                  });
                 }
            }
        [HttpPost("revoke")]
        [Authorize]
        public IActionResult Revoke()
        {
            string email = User.FindFirst(ClaimTypes.Email).Value;
            var user = BookMyShowContext.UserDetail.SingleOrDefault(u => u.Email == email);
            if (user == null) return BadRequest();
            user.RefreshToken = null;
            BookMyShowContext.SaveChanges();
            return NoContent();
        }
    }
}

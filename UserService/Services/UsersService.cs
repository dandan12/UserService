using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Entities;
using UserService.Models;
using UserService.Services.Interface;

namespace UserService.Services
{
    public class UsersService : IUserService
    {
        private readonly AuthenticationSetting _setting;

        public UsersService(AuthenticationSetting setting)
        {
            _setting = setting;
        }

        public TokenResponse GenerateToken(Partner partner)
        {
            var claims = GetClaims(partner);

           var tokenHandler = new JwtSecurityTokenHandler();
           var key = Encoding.ASCII.GetBytes(_setting.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddSeconds(_setting.ExpiresInSecond),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Audience = _setting.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(token);

            return new TokenResponse() { AccessToken = accessToken, ExpiresIn = _setting.ExpiresInSecond };
        }

        public List<Claim> GetClaims(Partner partner)
        {
            var list = new List<Claim>();
            list.Add(new Claim(ClaimTypes.Name, partner.Name));
            list.Add(new Claim(ClaimTypes.NameIdentifier, partner.Id));
            list.Add(new Claim("url-callback", partner.UrlCallback));

            return list;
        }
    }
}

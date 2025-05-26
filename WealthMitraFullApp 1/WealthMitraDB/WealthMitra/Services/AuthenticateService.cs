using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WealthMitra.Models;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using BOL;
using DAL;
using System.Linq;
using System;
using System.Collections.Generic;
namespace WealthMitra.Services
{
    public class AuthenticateService : IAuthenticateService
    {

        private List<Credential> users = new List<Credential>();
        private readonly AppSettings _appSettings;
        public AuthenticateService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            users = CredentialDAL.GetAll();
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
           
            var user = users.SingleOrDefault(x => x.UserName == model.Username && x.Password==model.Password);

            if(user==null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
           
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.CredentialID.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName.ToString()),
                }),
            
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };
            if(user.RoleID == 4)
            {
                tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role,"Investor"));
            }
            else if(user.RoleID==3)
            {
                string[] advisor = {"Advisor","Investor"};
                foreach (var role in advisor)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
            else if(user.RoleID==1)
            {
                string[] admin = {"Admin","Investor","Advisor"};
                foreach (var role in admin)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
            else
            {
                string[] ceo = {"CEO","Investor","Advisor"};
                foreach (var role in ceo)
                {
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
                }
            }
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var writetoken = tokenHandler.WriteToken(token);

            user.Password = null;
            AuthenticateResponse resp = new AuthenticateResponse(user,writetoken);
            return resp;
            
        }
    
    }
}
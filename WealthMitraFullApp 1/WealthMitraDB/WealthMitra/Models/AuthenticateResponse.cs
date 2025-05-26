using BOL;

namespace WealthMitra.Models
{
 public class AuthenticateResponse
 {

        public int CredentalId { get; set; }   
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(Credential user, string token)
        {
            CredentalId = user.CredentialID;
            UserName = user.UserName;
            RoleId = user.RoleID;
            Token = token;
        }
    }
}
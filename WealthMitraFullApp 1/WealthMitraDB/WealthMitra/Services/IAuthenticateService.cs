using System.Collections.Generic;
using BOL;
using WealthMitra.Models;


namespace WealthMitra.Services
{
    public interface IAuthenticateService
        {
           AuthenticateResponse Authenticate(AuthenticateRequest model);
          
        }
}

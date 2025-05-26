using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DAL;
using WealthMitra.Services;
using WealthMitra.Models;

namespace WealthMitra.Controllers
{
    [ApiController]
    [Route("[controller]")]
  public class UsersController : ControllerBase{

    private IAuthenticateService _authenticateService;

      public UsersController(IAuthenticateService authenticateService){
         _authenticateService = authenticateService;
      }

      [HttpPost("authenticate")]      
      public IActionResult Authenticate([FromBody] AuthenticateRequest model)
      {
        var user = _authenticateService.Authenticate(model);
        if(user==null)
          return BadRequest(new {message = "Username or Password is Incorrect"});

        return Ok(user);
      }

      [Authorize(Roles="Advisor")]
      [HttpGet]
      public IActionResult GetAll(){
        var users=CredentialDAL.GetAll();
          return Ok(users);
      }
  }
}

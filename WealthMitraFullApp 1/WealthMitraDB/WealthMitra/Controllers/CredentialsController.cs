using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLL;
using BOL;

namespace WealthMitra.Controllers

{
    [ApiController]

    [Route("[controller]")]
    public class CredentialsController : ControllerBase

    {

        public CredentialsManager manager = CredentialsManager.GetManager();

        [HttpGet("credentials")]
        public IActionResult GetAll()
        {
            try{
                List<Credential> allCredentials= manager.GetAll();
                if(allCredentials==null)
                {                
                }
                return Ok(allCredentials);
            }
            catch(Exception){
                return BadRequest();
                }
        }

        [HttpGet("credential/{id}")]
        public IActionResult GetCredential(int id)
        {
            try{
                var obj = manager.GetCredential(id);
            
                if(obj==null){
                    return NotFound();
                }
                return Ok(obj[0]);
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("resetPassword")]
        public IActionResult ResetPassword([FromBody] ChangePassword obj)
        {
            var newPass = obj.NewPassword;
            var oldPass = obj.OldPassword;
            var cnPass = obj.ConfirmPassword;
            var email = obj.Email;

            manager.ResetPassword(obj);
            return Ok();

        }

    }
    
}
using System;

using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using BLL;

using BOL;

namespace WealthMitra.Controllers

{

    [ApiController]

    [Route("[controller]")]

    public class EmployeesController : ControllerBase
    {
        EmployeesManager manager = EmployeesManager.GetManager();

        [HttpGet]
        public IActionResult GetAllEmployees(){
            try{
                List<Employee> allEmployees = manager.GetAllEmployees();
                if(allEmployees==null){                
                }
                return Ok(allEmployees);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        [HttpPost("employeeadd")]
        public IActionResult CreateEmployeeRecord(Employee user)
        {
            int status=manager.CreateEmployeeRecord(user);
               return Ok(status);

        }
        [HttpGet("{username}")]
        public IActionResult GetMyProfile(string username){
            try{
                List<Object> allAsset = manager.GetMyProfile(username);
                if(allAsset==null){                
                }
                return Ok(allAsset[0]);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        [HttpPut("updateemployee/{id}")]
        public IActionResult UpdateEmployee(int id,Employee user){
            try{
                bool status = manager.UpdateEmployee(id,user);
         
            if(status==false){
                return NotFound();
            }
            return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }
    }
}
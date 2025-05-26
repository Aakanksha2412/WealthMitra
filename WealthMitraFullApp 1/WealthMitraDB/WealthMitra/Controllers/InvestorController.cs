using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;

namespace WealthMitra.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class InvestorController : ControllerBase
    {
      
        InvestorManager manager = InvestorManager.GetManager();

        [HttpGet("roles")]
        public IActionResult GetAllRoles()
        {
            try{
                List<Object> allRoles = manager.GetAllRoles();
                if(allRoles==null)
                {
                    return NotFound();                
                }
                return Ok(allRoles);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        [HttpGet("Countries")]
        public IActionResult GetCountries()
        {
            try{
                List<Object> allcountries = manager.GetCountries();
                if(allcountries==null)
                {
                    return NotFound();                
                }
                return Ok(allcountries);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        [HttpGet("states")]
        public IActionResult GetStates()
        {
            try{
                List<Object> allstates = manager.GetStates();
                if(allstates==null)
                {
                    return NotFound();                
                }
                return Ok(allstates);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        [HttpGet("Cities")]
        public IActionResult GetCities()
        {
            try{
                List<Object> allcities = manager.GetCities();
                if(allcities==null)
                {
                    return NotFound();                
                }
                return Ok(allcities);
            }
            catch(Exception){
                return BadRequest();
                }
        }

        [HttpGet("{username}")]
        public IActionResult GetInvestorProfile(string username)
        {
            try{
            List<Object> personalInfromation = manager.GetInvestorProfile(username);
         
            if(personalInfromation==null){
                return NotFound();
            }
            return Ok(personalInfromation[0]);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }
        [HttpGet("investorsofAdvisorby/{empid}")]
        public IActionResult GetInvestorsByAdvisorid(int empid)
        {
            try{
            List<Investor> personalInfromation = manager.GetInvestorsByAdvisorid(empid);
         
            if(personalInfromation==null){
                return NotFound();
            }
            return Ok(personalInfromation);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }
        [HttpGet("allinvestors")]
        public IActionResult GetInvestorsByCEO()
        {
            try{
            List<Investor> personalInfromation = manager.GetInvestorsByCEO();
         
            if(personalInfromation==null){
                return NotFound();
            }
            return Ok(personalInfromation);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }
        [HttpPost("investoradd")]
        public IActionResult CreateInvestorRecord(Investor user)
        {
            int status=manager.CreateInvestorRecord(user);
               return Ok(status);

        }

        [HttpPut("updateinvestor/{id}")]
        public IActionResult UpdateInvestor(int id,Investor user){
            try{
                bool status = manager.UpdateInvestor(id,user);
         
            if(status==false){
                return NotFound();
            }
            return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPost("inserttransactions/{id}")]
        public IActionResult InsertTransaction(int id, Transaction transaction){
            try{
                bool status = manager.InsertTransactions(id,transaction);

                if(status==false){
                return NotFound();
                }
                return Ok();
                }
                catch(Exception){
                    return BadRequest();
            }
        }

        [HttpPost("Cityadd")]
        public IActionResult CreateCityRecord( Location cityobject)
        {
            bool status=false;
            try{
                 status=manager.CreateCityRecord(cityobject);
                 if(status==false){
                    return NotFound();
                }
                return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
          
        }
        [HttpPost("stateadd")]
        public IActionResult CreateStateRecord( Location stateobject)
        {
            bool status=false;
            try{
                 status=manager.CreateStateRecord(stateobject);
                 if(status==false){
                    return NotFound();
                }
                return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
          
        }
        [HttpPost("countryadd")]
        public IActionResult CreateCountryRecord( Location countryObject)
        {
            bool status=false;
            try{
                 status=manager.CreateCountryRecord(countryObject);
                 if(status==false){
                    return NotFound();
                }
                return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
          
        }

        [HttpGet("gettransactionofinvestor/{id}")]
        public IActionResult GetTransactions(int id){
            try{
            List<Transaction> transactions = manager.GetTransactions(id);
         
            if(transactions==null){
                return NotFound();
            }
            return Ok(transactions);
            }
            catch(Exception){
            return BadRequest();
            }
        }

        [HttpPut("updatecity/{id}")]
        public IActionResult UpdateCity(int id,Location cityobject){
            
            try{
                bool status = manager.UpdateCity(id,cityobject);

                if(status == false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("updatestate/{id}")]
        public IActionResult UpdateState(int id,Location stateobject){
            
            try{
                bool status = manager.UpdateState(id,stateobject);

                if(status == false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("updatecountry/{id}")]
        public IActionResult UpdateCountry(int id,Location countryobject){
            
            try{
                bool status = manager.UpdateCountry(id,countryobject);

                if(status == false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }
         [HttpPut("updateRole/{id}")]
        public IActionResult UpdateRoles(int id,Roles role){
            
            try{
                bool status = manager.UpdateRoles(id,role);

                if(status == false){
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
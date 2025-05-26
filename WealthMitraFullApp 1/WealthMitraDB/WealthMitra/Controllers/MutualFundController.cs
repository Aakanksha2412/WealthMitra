using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class MutualFundController : ControllerBase
    {
      
        MutualFundManager manager = MutualFundManager.GetManager();

        [HttpGet]
        public IActionResult GetAll()
        {
        try{
            List<MutualFund> allMutualFunds = manager.GetAll();
            
            if(allMutualFunds==null){
                return NotFound();
            }
            return Ok(allMutualFunds);
            }
            catch(Exception){
            return BadRequest();
            }
        }

        [HttpPost("addMutualFund")]
        public IActionResult AddMutualFund(MutualFund mutualFundObj)
        {
            bool status = false;
            try{
            status = manager.AddMutualFund(mutualFundObj);
         
            if(status==false){
                return NotFound();
            }
            return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }

        [HttpPut("updateMutualFund/{id}")]
        public IActionResult UpdateMutualFund(int id,MutualFund mutualFundObj)
        {
            bool status = false;
            try{
            status = manager.UpdateMutualFund(id,mutualFundObj);
         
            if(status==false){
                return NotFound();
            }
            return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }

        [HttpGet("investorMutualFundsHistory/{id}")]
        public IActionResult InvestorMutualFunds(int id)
        {
        try{
            List<Object> allMutualFunds = manager.InvestorMutualFunds(id);
            
            if(allMutualFunds==null){
                return NotFound();
            }
            return Ok(allMutualFunds);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [HttpGet("investorbuymutualfunds/{id}")]
        public IActionResult InvestorBuyMutualFunds(int id)
        {
        try{
            List<Object> allMutualFunds = manager.InvestorBuyMutualFunds(id);
            
            if(allMutualFunds==null){
                return NotFound();
            }
            return Ok(allMutualFunds);
            }
            catch(Exception){
            return BadRequest();
            }
        }
    }
}
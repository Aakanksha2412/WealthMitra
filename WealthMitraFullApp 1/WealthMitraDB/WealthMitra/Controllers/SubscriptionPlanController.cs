using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("{controller}")]
    public class SubscriptionController : ControllerBase
    {
        SubscriptionPlanManager manager = SubscriptionPlanManager.GetManager();
        public IActionResult GetAll()
        {
            try{
                List<SubscriptionPlan> allSubscriptionPlans = manager.GetAll();
                if(allSubscriptionPlans==null){                
                }
                return Ok(allSubscriptionPlans);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id,SubscriptionPlan obj)
        {
            try
            {
                bool status = manager.Update(id,obj);
                if(status==false){
                }
                return Ok(new {message = "Updated Successfully"});
            }
            catch(Exception ee)
            {
                return BadRequest(new {message=ee.Message});
            }
        }

        [HttpPost("addPlan")]
        public IActionResult Insert(SubscriptionPlan obj)
        {
            try{
                int rowsAffected = manager.Insert(obj);
                if(rowsAffected==0)
                {}
                return Ok(new {messasge="Record Inserted Successfully"});
            }
            catch(Exception ee)
            {
                return BadRequest(new {message=ee.Message});
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            try{
                bool status=manager.Delete(id);
                if(status == false){
                    return NotFound();
                }
                return Ok(new {message="Record Deleted Successfully"});
            }
            catch(Exception ee)
            {
                return BadRequest(new {message=ee.Message});
            }
        }

        [HttpPut("planPurchased/{id}")]
        public IActionResult UpdatePlanDetailsOfInvestor(int id,Investor investor)
        {
            try
            {
                bool status = manager.UpdatePlanDetailsOfInvestor(id,investor);
                if(status==false)
                {
                    return NotFound();
                }
                return Ok(new {message="Record Updated Successfully"});
            }
            catch(Exception ee)
            {
                return BadRequest(new {message=ee.Message});
            }

        }

    }
    
}
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class SectorController : ControllerBase
    {
      
        SectorManager manager = SectorManager.GetManager();
        [HttpGet]
        public IActionResult GetAll()
        {
        try{
            List<Sector> allSectors = manager.GetAll();
            
            if(allSectors==null){
                return NotFound();
            }
            return Ok(allSectors);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [HttpGet("InvestorStocksSector/{id}")]
        public IActionResult InvestorStocksSector(int id)
        {
        try{
            List<Object> allStocksSectorInvestment = manager.InvestorStocksSector(id);
            
            if(allStocksSectorInvestment==null){
                return NotFound();
            }
            return Ok(allStocksSectorInvestment);
        }
        catch(Exception){
        return BadRequest();
        }
        }
        [HttpGet("InvestorMutualFundsSector/{id}")]
        public IActionResult InvestorMutualFundsSector(int id)
        {
            try{
                List<Object> allMutualFundsSectorInvestment = manager.InvestorMutualFundsSector( id);
                
                if(allMutualFundsSectorInvestment==null){
                    return NotFound();
                }
                return Ok(allMutualFundsSectorInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }

        [HttpGet("AdvisorStocksSector/{id}")]
        public IActionResult AdvisorStocksSector(int id)
        {
            try{
                List<Object> allStocksSectorInvestment = manager.AdvisorStocksSector(id);
                
                if(allStocksSectorInvestment==null){
                    return NotFound();
                }
                return Ok(allStocksSectorInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [HttpGet("AdvisorMutualFundsSector/{id}")]
        public IActionResult AdvisorMutualFundsSector(int id)
        {
            try{
                List<Object> allMutualFundsSectorInvestment = manager.AdvisorMutualFundsSector( id);
                
                if(allMutualFundsSectorInvestment==null){
                    return NotFound();
                }
                return Ok(allMutualFundsSectorInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }

        [HttpGet("AdvisorStocksSector/{id}")]
        public IActionResult CeoStocksSector()
        {
            try{
                List<Object> allStocksSectorInvestment = manager.CeoStocksSector();
                
                if(allStocksSectorInvestment==null){
                    return NotFound();
                }
                return Ok(allStocksSectorInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [HttpGet("AdvisorMutualFundsSector/{id}")]        public IActionResult CeoMutualFundsSector()
        {
            try{
                List<Object> allMutualFundsSectorInvestment = manager.CeoMutualFundsSector();
                
                if(allMutualFundsSectorInvestment==null){
                    return NotFound();
                }
                return Ok(allMutualFundsSectorInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }

        [HttpPost("AddSector")]
        public IActionResult InsertSector(Sector sector){
            try{
                bool status = manager.InsertSector(sector);

                if(status==false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("updatesector/{id}")]
        public IActionResult UpdateSector(int id,Sector sector){
            try{
                bool status = manager.UpdateSector(id,sector);

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
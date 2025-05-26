using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class StockController : ControllerBase
    {
      
        StockManager manager = StockManager.GetManager();
        [HttpGet]
        public IActionResult GetAll()
        {
            try{
            List<Stock> allStock = manager.GetAll();
         
            if(allStock==null){
                return NotFound();
            }
            return Ok(allStock);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }
        [HttpPost("addstock")]
        public IActionResult AddStock(Stock stock)
        {
            bool status = false;
            try{
            status = manager.AddStock(stock);
         
            if(status==false){
                return NotFound();
            }
            return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }

        [HttpPut("updatestock/{id}")]
        public IActionResult UpdateStock(int id,Stock stock)
        {
            bool status = false;
            try{
            status = manager.UpdateStock(id,stock);
         
            if(status==false){
                return NotFound();
            }
            return Ok(status);
            }
            catch(Exception){
            return BadRequest();
            }
            
        }

        [HttpGet("investorStocksHistory/{id}")]
        public IActionResult InvestorStocks(int id)
        {
        try{
            List<Object> allstocks = manager.InvestorStocks(id);
            
            if(allstocks==null){
                return NotFound();
            }
            return Ok(allstocks);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [HttpGet("investorbuystocks/{id}")]
        public IActionResult InvestorBuyStocks(int id)
        {
        try{
            List<Object> allstocks = manager.InvestorBuyStocks(id);
            
            if(allstocks==null){
                return NotFound();
            }
            return Ok(allstocks);
            }
            catch(Exception){
            return BadRequest();
            }
        }
    }
}
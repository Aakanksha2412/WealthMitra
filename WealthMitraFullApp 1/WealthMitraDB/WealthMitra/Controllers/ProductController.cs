using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        ProductManager manager = ProductManager.GetManager();
       [HttpGet("products")]
        public IActionResult GetAll()
        {
            try{
                List<Product> allProduct = manager.GetAll();
                if(allProduct==null){                
                }
                return Ok(allProduct);
            }
            catch(Exception){
                return BadRequest();
                }
        }

        [HttpGet("ceoproduct")]
        public IActionResult CEOProduct()
        {
            try{
                List<Object> allProductInvestment = manager.CEOProduct();
            
                if(allProductInvestment==null){
                    return NotFound();
                }
                return Ok(allProductInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }
       
        [HttpGet("advisorProduct/{id}")]
        public IActionResult AdvisorProduct(int id)
        {
            try{
                List<Object> allProductInvestment = manager.AdvisorProduct(id);
            
                if(allProductInvestment==null){
                    return NotFound();
                }
                return Ok(allProductInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }
        [Authorize(Roles="Investor")]
        [HttpGet("investorProduct/{id}")]
        public IActionResult InvestorProduct(int id)
        {
            try{
                List<Object> investorProducts = manager.InvestorProduct(id);
            
                if(investorProducts==null){
                    return NotFound();
                }
                return Ok(investorProducts);
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPost("insertproduct")]
        public IActionResult InsertProduct(Product product)
        {
            try{
                bool status = manager.InsertProduct(product);
            
                if(status==false){
                    return NotFound();
                }
                return Ok(status);
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("updateproduct/{id}")]
        public IActionResult UpdateProduct(int id,Product product)
        {
            try{
                bool status = manager.UpdateProduct(id,product);
            
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
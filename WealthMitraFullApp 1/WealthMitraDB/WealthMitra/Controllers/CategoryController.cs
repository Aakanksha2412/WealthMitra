using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
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

    public class CategoryController : ControllerBase

    {

        public CategoryManager manager = CategoryManager.GetManager();

        [HttpGet("categories")]
        public IActionResult GetAll()
        {
            try{
                List<Category> allCategory = manager.GetAll();
                if(allCategory==null)
                {
                    return NotFound();                
                }
                return Ok(allCategory);
            }
            catch(Exception){
                return BadRequest();
                }
        }

        [HttpGet("investorcategory/{id}")]
        public IActionResult InvestorCategory(int id)
        {
            try{
                List<Object> allCategoryInvestment = manager.InvestorCategory(id);
            
                if(allCategoryInvestment==null){
                    return NotFound();
                }
                return Ok(allCategoryInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }   
        [Authorize(Roles="Investor")]
        [HttpGet("investorstockscategory/{id}")]
        public IActionResult InvestorStocksCategory(int id)
        {
            try{
                List<Object> allCategoryInvestment = manager.InvestorStocksCategory(id);
            
                if(allCategoryInvestment==null){
                    return NotFound();
                }
                return Ok(allCategoryInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }
        [Authorize(Roles="Investor")]
        [HttpGet("investormutualfundscategory/{id}")]
        public IActionResult InvestorMutualFundsCategory(int id)
        {
            try{
                List<Object> allCategoryInvestment = manager.InvestorMutualFundsCategory(id);
            
                if(allCategoryInvestment==null){
                    return NotFound();
                }
                return Ok(allCategoryInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }
         [HttpGet("ceostockscategory")]
        public IActionResult CEOStocksCategory()
        {
            try{
                List<Object> allCategoryInvestment = manager.CEOStocksCategory();
            
                if(allCategoryInvestment==null){
                    return NotFound();
                }
                return Ok(allCategoryInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }
        [HttpGet("ceomutualfundscategory")]
        public IActionResult CEOMutualFundsCategory()
        {
            try{
                List<Object> allCategoryInvestment = manager.CEOMutualFundsCategory();
            
                if(allCategoryInvestment==null){
                    return NotFound();
                }
                return Ok(allCategoryInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpGet("advisorstockscategory/{id}")]
        public IActionResult AdvisorStocksCategory(int id)
        {
            try{
                List<Object> obj = manager.AdvisorStocksCategory(id);
                if(obj==null){
                    return NotFound();
                }
                return Ok(obj);
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpGet("advisormutualfundscategory/{id}")]
        public IActionResult AdvisorMutualFundsCategory(int id)
        {
            try{
                List<Object> obj = manager.AdvisorMutualFundsCategory(id);
                if(obj==null){
                    return NotFound();
                }
                return Ok(obj);
            }
            catch(Exception){
                return BadRequest();
            }
        }
        
        [HttpGet("getCategoryById/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try{
                List<Category> Category = manager.CategoryById(id);
                if(Category==null)
                {
                    return NotFound();                
                }
                return Ok(Category);
            }
            catch(Exception){
                return BadRequest();
                }
        }

        [HttpPost("insertcategory")]
        public IActionResult InsertCategory(Category category){
            try{
                bool status = manager.InsertCategory(category);
                if(status==false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("updatecategory/{id}")]
        public IActionResult UpdateCategory(int id,Category category){
            try{
                bool status = manager.UpdateCategory(id,category);
                if(status==false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpDelete("deletecategory/{id}")]
        public IActionResult DeleteCategory(int id){
            try{
                bool status = manager.DeleteCategory(id);
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
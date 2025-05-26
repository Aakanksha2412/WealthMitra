using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BLL;
using BOL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class AssetController : ControllerBase
    {
      
        AssetManager manager = AssetManager.GetManager();
        [HttpGet("assets")]
        public IActionResult GetAll()
        {
            try{
            List<Asset> allAsset = manager.GetAll();
         
            if(allAsset==null){
                return NotFound();
            }
            return Ok(allAsset);
            }
            catch(Exception){
            return BadRequest();
            }
        }

         [HttpGet("getAssetById/{id}")]
        public IActionResult GetAssetById(int id)
        {
            try{
                List<Asset> allAsset = manager.GetAssetById(id);
                if(allAsset==null){                
                }
                return Ok(allAsset);
            }
            catch(Exception){
                return BadRequest();
                }
        }
        
        [HttpPost("Assetadd")]
        public IActionResult InsertAsset(Asset asset){
            try{
                bool status=manager.InsertAsset(asset);
                if(status == false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpPut("updateasset/{id}")]
        public IActionResult UpdateAsset(int id,[FromBody] Asset asset){
            try{
                bool status=manager.UpdateAsset(id,asset);
                if(status == false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }
        
        [HttpDelete("deleteasset/{id}")]
        public IActionResult DeleteAsset(int id){
            try{
                bool status=manager.DeleteAsset(id);
                if(status == false){
                    return NotFound();
                }
                return Ok();
            }
            catch(Exception){
                return BadRequest();
            }
        }

        [HttpGet("investorasset/{id}")]
        public IActionResult InvestorAsset(int id)
        {
        try{
            List<Object> allAssetInvestment = manager.InvestorAsset(id);
            
            if(allAssetInvestment==null){
                return NotFound();
            }
            return Ok(allAssetInvestment);
        }
        catch(Exception){
        return BadRequest();
        }
        }
        [HttpGet("ceoasset")]
        public IActionResult CEOAsset()
        {
        try{
            List<Object> allAssetInvestment = manager.CEOAsset();
            
            if(allAssetInvestment==null){
                return NotFound();
            }
            return Ok(allAssetInvestment);
        }
        catch(Exception){
        return BadRequest();
        }
        }
        [HttpGet("advisorasset/{id}")]

        public IActionResult AdvisorAsset(int id)
        {
            try{
                List<Object> allAssetInvestment = manager.AdvisorAsset(id);
           
                if(allAssetInvestment==null){
                    return NotFound();
                }
                return Ok(allAssetInvestment);
            }
            catch(Exception){
                return BadRequest();
            }
        }
        


    }
}
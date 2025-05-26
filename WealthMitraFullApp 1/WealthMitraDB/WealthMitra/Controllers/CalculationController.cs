using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BLL;
namespace WealthMitra.Controllers
{
     [ApiController]
     [Route("[controller]")]
    public class CalculationController : ControllerBase
    {
      
        CalculationManager manager = CalculationManager.GetManager();
       
        [HttpGet("InvestorSummaryView/{id}")]
        public IActionResult InvestorSummaryView(int id)
        {
            try{
                List<Object> InvestmentSummaryOfInvestor = manager.InvestorSummaryView(id);
                
                if(InvestmentSummaryOfInvestor==null){
                    return NotFound();
                }
                return Ok(InvestmentSummaryOfInvestor);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [Authorize(Roles="Investor")]
        [HttpGet("InvestorProfitLossROITotalValueOfInvestment/{id}")]
        public IActionResult InvestorProfitLossROITotalValueOfInvestment(int id)
        {
            try{
                List<Object> InvestorProfitLossROITotalInvestment = manager.InvestorProfitLossROITotalValueOfInvestment(id);
                
                if(InvestorProfitLossROITotalInvestment==null){
                    return NotFound();
                }
                return Ok(InvestorProfitLossROITotalInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [Authorize(Roles="Advisor")]
        [HttpGet("AdvisorProfitLossROITotalValueOfInvestment/{empid}")]
        public IActionResult AdvisorProfitLossROITotalValueOfInvestment(int empid)
        {
            try{
                List<Object> AdvisorProfitLossROITotalInvestment = manager.AdvisorProfitLossROITotalValueOfInvestment(empid);
                
                if(AdvisorProfitLossROITotalInvestment==null){
                    return NotFound();
                }
                return Ok(AdvisorProfitLossROITotalInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }
        [Authorize(Roles="CEO")]
        [HttpGet("CEOProfitLossROITotalValueOfInvestment")]
        public IActionResult CEOProfitLossROITotalValueOfInvestment()
        {
            try{
                List<Object> CEOProfitLossROITotalInvestment = manager.CEOProfitLossROITotalValueOfInvestment();
                
                if(CEOProfitLossROITotalInvestment==null){
                    return NotFound();
                }
                return Ok(CEOProfitLossROITotalInvestment);
            }
            catch(Exception){
            return BadRequest();
            }
        }
    }
}
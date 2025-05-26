using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class CalculationManager
    {
        public static CalculationManager self=null;
        private CalculationManager(){
            self=this;
        }
        
        public static CalculationManager GetManager(){
            CalculationManager themanager;
            if(self == null){
                themanager = new CalculationManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
       
        public  List<Object> InvestorSummaryView(int id){
            return CalculationDAL.InvestorSummaryView(id);
        }
      
        public  List<Object> InvestorProfitLossROITotalValueOfInvestment(int id){
            return CalculationDAL.InvestorProfitLossROITotalValueOfInvestment(id);
        }
        public  List<Object> AdvisorProfitLossROITotalValueOfInvestment(int id){
            return CalculationDAL.AdvisorProfitLossROITotalValueOfInvestment(id);
        }
        public  List<Object> CEOProfitLossROITotalValueOfInvestment(){
            return CalculationDAL.CEOProfitLossROITotalValueOfInvestment();
        }
    
       
         
         
    }
         
}

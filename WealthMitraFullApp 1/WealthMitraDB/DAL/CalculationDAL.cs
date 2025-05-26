using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
namespace DAL
{
    public class CalculationDAL
    {
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
         public static List<Object> InvestorSummaryView(int id)
        {   
            List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select NameOfInstruments,SchemeCode,Units,AverageValue,TotalValueOfInvestment from Summary where InvestorId={0}";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);                
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;
        }
        public static List<Object> InvestorProfitLossROITotalValueOfInvestment(int id)
        {   
            List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select sum (ProfitLoss) as ProfitLoss,sum (ROI) as ROI,(select  sum(TotalValueOfInvestment) from Summary where InvestorId={0}) as TotalValueOfInvestment from Transactions where InvestorId={0}";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;

        }

        public static List<Object> AdvisorProfitLossROITotalValueOfInvestment(int id)
        {   
            List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select sum (ProfitLoss) as ProfitLoss,sum (ROI) as ROI ,(select  sum(TotalValueOfInvestment) from Summary join Investors on Investors.InvestorId=Summary.InvestorId
                                    where Investors.EmployeeId={0} ) as TotalValueOfInvestment
                                    from Transactions join Investors on Transactions.InvestorId=Investors.InvestorId
                                    where Investors.EmployeeId={0}";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);          
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj; 
        } 
        public static List<Object> CEOProfitLossROITotalValueOfInvestment()
        {
            List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select sum (ProfitLoss) as ProfitLoss,sum (ROI) as ROI ,(select  sum(TotalValueOfInvestment) from Summary ) as TotalValueOfInvestment from Transactions ";
                obj = (List<Object>)connection.Query<Object>(query);             
                } 
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        }   
    }
}    
   


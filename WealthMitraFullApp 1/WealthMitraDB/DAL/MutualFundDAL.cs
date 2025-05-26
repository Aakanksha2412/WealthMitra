using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using BOL;
namespace DAL
{
    public class MutualFundDAL
    {
     public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
       

        public static List<MutualFund> GetAll()
        {
            List<MutualFund> stocks = new List<MutualFund>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                
                stocks = (List<MutualFund>) connection.Query<MutualFund>("select MutualFundId,MutualFundName,SchemeCode,AssetProductCategory.CategoryName,sector.SectorName,MutualFunds.IsActive,MutualFunds.RecordCreatedBy,MutualFunds.RecordCreatedDate,MutualFunds.RecordModifiedBy,MutualFunds.RecordModifiedDate from MutualFunds join AssetProductCategory on mutualfunds.AssetProductCategoryId=AssetProductCategory.AssetProductCategoryId join sector on MutualFunds.SectorId=sector.SectorId");

                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return stocks;  
               
        }

        public static bool CreateMutualFund(MutualFund mutualFundObj)
        { 
            bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"exec sp_AddMutualFundsAndInstruments @SchemeCode='{0}' ,@MutualFundName='{1}' ,@ProductName = '{2}',@CategoryName='{3}' ,@SectorName='{4}'";
                string finalQuery = string.Format(query, mutualFundObj.MutualFundName,mutualFundObj.SchemeCode,mutualFundObj.CategoryName, mutualFundObj.ProductName,mutualFundObj.SectorName);
        
                connection.Execute(finalQuery);
                status=true ;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }
        public static bool UpdateMutualFund(int id,MutualFund mutualFundObj)
        { 
            bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"exec sp_UpdateMutualFundsAndInstruments @SchemeCode='{0}',@MutualFundName='{1}',@CategoryName='{2}',@ProductName='{3}',@SectorName='{4}',@MutualFundId={5}";
                string finalQuery = string.Format(query,mutualFundObj.SchemeCode, mutualFundObj.MutualFundName,mutualFundObj.CategoryName, mutualFundObj.ProductName,mutualFundObj.SectorName,id);
  
                connection.Execute(finalQuery);
                status=true ;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }
        public static List<Object> InvestorMutualFunds(int id)
        {
            List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Transactions.NameOfInstrument,Transactions.SchemeCode,Transactions.Action,Transactions.Units,Transactions.UnitValue,(Units*UnitValue) as TotalValue,Transactions.ProfitLoss,Transactions.ROI,sector.SectorName,AssetProductCategory.CategoryName,Products.ProductName,Assets.AssetName
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join MutualFunds on Instruments.MasterTypeId=MutualFunds.MutualFundId
                                join sector on MutualFunds.SectorId=sector.SectorId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Products on AssetProductCategory.ProductId=Products.ProductId
                                join Assets on Products.AssetId=Assets.AssetId
                                where Transactions.InvestorId = {0} and Instruments.MasterType='MutualFunds' ";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);              
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj; 
        }
        public static List<Object> InvestorBuyMutualFunds(int id)
        {   List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Transactions.NameOfInstrument,Transactions.SchemeCode,Transactions.Action,Transactions.Units,Transactions.UnitValue,(Units*UnitValue) as TotalValue,Transactions.ProfitLoss,Transactions.ROI,sector.SectorName,AssetProductCategory.CategoryName,Products.ProductName,Assets.AssetName
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join MutualFunds on Instruments.MasterTypeId=MutualFunds.MutualFundId
                                join sector on MutualFunds.SectorId=sector.SectorId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Products on AssetProductCategory.ProductId=Products.ProductId
                                join Assets on Products.AssetId=Assets.AssetId
                                where Transactions.InvestorId = {0} and Instruments.MasterType='MutualFunds' and Action='buy'";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);             
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        }     
    }
}    
   


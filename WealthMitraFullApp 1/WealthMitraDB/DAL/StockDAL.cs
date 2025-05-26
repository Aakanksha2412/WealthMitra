using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using BOL;
namespace DAL
{
    public class StockDAL
    {
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
    
        public static List<Stock> GetAll()
        {
            List<Stock> stocks = new List<Stock>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                
                stocks = (List<Stock>) connection.Query<Stock>("select StockId,StockName,SchemeCode,AssetProductCategory.CategoryName,sector.SectorName,Stocks.IsActive,stocks.RecordCreatedBy,Stocks.RecordCreatedDate,Stocks.RecordModifiedBy,Stocks.RecordModifiedDate from Stocks join AssetProductCategory on Stocks.AssetProductCategoryId=AssetProductCategory.AssetProductCategoryId join sector on Stocks.SectorId=sector.SectorId");

                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return stocks;  
               
        }

        public static bool CreateStock(Stock stockobj)
        { 
            bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"exec sp_AddStocksAndInstruments @SchemeCode='{0}' ,@StockName='{1}' ,@CategoryName='{2}',@ProductName='{3}' ,@SectorName='{4}'";
                string finalQuery = string.Format(query, stockobj.StockName,stockobj.SchemeCode,stockobj.CategoryName, stockobj.ProductName,stockobj.SectorName);
           
                connection.Execute(finalQuery);
                status=true ;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }

        public static bool UpdateStock(int id,Stock stockobj)
        { 
            bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"exec sp_UpdateStocksAndInstruments @SchemeCode='{0}',@StockName='{1}',@CategoryName='{2}',@ProductName='{3}',@SectorName='{4}',@StockId={5}";
                string finalQuery = string.Format(query, stockobj.SchemeCode,stockobj.StockName,stockobj.CategoryName, stockobj.ProductName,stockobj.SectorName,id);
           
                connection.Execute(finalQuery);
                status=true ;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }


        public static List<Object> InvestorStocks(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select Transactions.NameOfInstrument,Transactions.SchemeCode,Transactions.Action,Transactions.Units,Transactions.UnitValue,(Units*UnitValue) as TotalValue,Transactions.ProfitLoss,Transactions.ROI,sector.SectorName,AssetProductCategory.CategoryName,Products.ProductName,Assets.AssetName
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join Stocks on Instruments.MasterTypeId=Stocks.StockId
                                join sector on Stocks.SectorId=sector.SectorId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Products on AssetProductCategory.ProductId=Products.ProductId
                                join Assets on Products.AssetId=Assets.AssetId
                                where Transactions.InvestorId = {0} and Instruments.MasterType='Stocks'";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                                   
                } 
            } 
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj; 


        }
        public static List<Object> InvestorBuyStocks(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select Transactions.NameOfInstrument,Transactions.SchemeCode,Transactions.Action,Transactions.Units,Transactions.UnitValue,(Units*UnitValue) as TotalValue,Transactions.ProfitLoss,Transactions.ROI,sector.SectorName,AssetProductCategory.CategoryName,Products.ProductName,Assets.AssetName
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join Stocks on Instruments.MasterTypeId=Stocks.StockId
                                join sector on Stocks.SectorId=sector.SectorId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Products on AssetProductCategory.ProductId=Products.ProductId
                                join Assets on Products.AssetId=Assets.AssetId
                                where Transactions.InvestorId = {0} and Instruments.MasterType='Stocks' and Action='buy'";
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
   


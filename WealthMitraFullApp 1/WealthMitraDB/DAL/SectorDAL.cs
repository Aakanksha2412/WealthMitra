using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using BOL;
namespace DAL
{
    public class SectorDAL
    {
      
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";

        public static List<Sector> GetAll()
        {
            List<Sector> Sectors = new List<Sector>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                
                Sectors = (List<Sector>) connection.Query<Sector>("select * from Sector");
     
                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return Sectors;  
               
        }

        public static bool InsertSector(Sector sector)
        {
            bool status= false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query=@"insert into Sector(SectorName,RecordCreatedDate) values('{0}',getdate());";
                    string finalQuery=string.Format(query,sector.SectorName);
              
                    connection.Execute(finalQuery);
                    status=true;

                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return status;  
               
        }

        public static bool UpdateSector(int id,Sector sector)
        {
            bool status= false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query=@"update sector set SectorName ='{0}' where SectorId={1}";
                    string finalQuery=string.Format(query,sector.SectorName,id);

                    connection.Execute(finalQuery);
                    status=true;

                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return status;  
               
        }
        
        public static List<Object> InvestorStocksSector(int id)
        {
            List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                { 
                    string query = @"select Sector.SectorName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join Stocks on Instruments.MasterTypeId=Stocks.StockId
                                join sector on Stocks.SectorId=sector.SectorId
                                where Transactions.InvestorId = {0} group by Sector.SectorName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);                  
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        }  

        
        public static List<Object> InvestorMutualFundsSector(int id)
        {   List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Sector.SectorName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join MutualFunds on Instruments.MasterTypeId=MutualFunds.MutualFundId
                                join sector on MutualFunds.SectorId=sector.SectorId
                                where Transactions.InvestorId = {0} group by Sector.SectorName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);             
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        }   

        public static List<Object> AdvisorStocksSector(int id)
        {   List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Sector.SectorName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
								join Investors on Transactions.InvestorId= Investors.InvestorId
                                join Stocks on Instruments.MasterTypeId=Stocks.StockId
                                join sector on Stocks.SectorId=sector.SectorId
                                where Investors.EmployeeId = {0} group by Sector.SectorName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);             
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        }    

        public static List<Object> AdvisorMutualFundsSector(int id)
        {   List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Sector.SectorName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
								join Investors on Transactions.InvestorId= Investors.InvestorId
                                join MutualFunds on Instruments.MasterTypeId=MutualFunds.MutualFundId
                                join sector on MutualFunds.SectorId=sector.SectorId
                                where Investors.EmployeeId = {0} group by Sector.SectorName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);             
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        }   

        public static List<Object> CeoStocksSector()
        {   List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Sector.SectorName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId						
                                join Stocks on Instruments.MasterTypeId=Stocks.StockId
                                join sector on Stocks.SectorId=sector.SectorId
                                group by Sector.SectorName";
                    string finalQuery = string.Format(query);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);             
                }  
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return obj;  
        } 

        public static List<Object> CeoMutualFundsSector()
        {   List<Object> obj=null;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = @"select Sector.SectorName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join MutualFunds on Instruments.MasterTypeId=MutualFunds.MutualFundId
                                join sector on MutualFunds.SectorId=sector.SectorId
                                group by Sector.SectorName";
                    string finalQuery = string.Format(query);
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
   


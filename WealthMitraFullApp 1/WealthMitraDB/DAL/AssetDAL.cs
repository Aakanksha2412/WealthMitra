using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using BOL;
namespace DAL
{
    public class AssetDAL
    {
        
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
       
        public static List<Asset> GetAll(){
            List<Asset> allAsset=new List<Asset>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    allAsset = (List<Asset>) connection.Query<Asset>("select * from Assets");
                }
                
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
      
           return allAsset;
               
        }
         public static List<Object> InvestorAsset(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select Assets.AssetName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                    from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                    join Products on AssetProductCategory.ProductId=Products.ProductId
                                    join Assets on Products.AssetId=Assets.AssetID
                                    where Transactions.InvestorId = {0} group by Assets.AssetName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                } 
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }

            return obj;
             

        }
        public static List<Object> CEOAsset()
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select Assets.AssetName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                    from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                    join Products on AssetProductCategory.ProductId=Products.ProductId
                                    join Assets on Products.AssetId=Assets.AssetID
                                    group by Assets.AssetName";
                    obj = (List<Object>)connection.Query<Object>(query);
                    return obj;                
                }  
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj; 
        }

        public static List<Object> AdvisorAsset(int id){
            List<Object> obj = new List<Object>();

            try{
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select Assets.AssetName, sum(Transactions.Units*Transactions.UnitValue) as totalValue from Transactions
                                    join Investors on Transactions.InvestorId = Investors.InvestorId
                                    join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                    join Employees on Investors.EmployeeId = Employees.EmployeeId
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                    join Products on AssetProductCategory.ProductId = Products.ProductId
                                    join Assets on Assets.AssetId = Products.AssetId
                                    join Roles on Employees.RoleId = Roles.RoleId
                                    where Investors.EmployeeId = {0} and Roles.RoleName = 'Advisor' group by Assets.AssetName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                    return obj;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;
        }
        //------------------------------------
        
        public static List<Asset> GetAssetById(int id){
            List<Asset> asset = new List<Asset>();
            try{
                using(SqlConnection connection=new SqlConnection(connectionString)){
                    string query = @"select * from Assets where AssetId = {0}";
                    string finalQuery= string.Format(query,id);
                    asset = (List<Asset>)connection.Query<Asset>(finalQuery);
                    
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return asset;
        }

       

        public static bool InsertAsset(Asset asset){
            bool status = false;
            try{
                using(SqlConnection connection=new SqlConnection(connectionString)){
                
                    string query = @"insert into Assets(AssetName,RecordCreatedDate) values ('{0}',getdate())";
                    string finalQuery= string.Format(query,asset.AssetName);

                    connection.Execute(finalQuery);
                    status = true;
                
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }

        public static bool UpdateAsset(int id,Asset asset){
            bool status = false;
            try{
                using(SqlConnection connection=new SqlConnection(connectionString)){
                
                    string query = @"update Assets set AssetName='{0}',RecordModifiedBy='Admin',RecordModifiedDate=getdate() where AssetId={1}";
                    string finalQuery= string.Format(query,asset.AssetName,id);
                    connection.Execute(finalQuery);
                    status = true;
                }
                
            }
            catch(Exception ee){
                    Console.WriteLine(ee.Message);
            }
            return status;
        }

        public static bool DeleteAsset(int id){
            bool status = false;
            try{
            using(SqlConnection connection=new SqlConnection(connectionString)){
                
                    string query = @"update Assets set IsActive = 0 where AssetId ={0}";
                    string finalQuery= string.Format(query,id);

                    connection.Execute(finalQuery);
                    status = true;
                }
                
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }
        
    }
}    
   


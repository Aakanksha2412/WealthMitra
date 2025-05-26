using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using BOL;

namespace DAL
{
    public class ProductDAL
    {
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
     
        public static List <Product> GetAll(){
           List<Product> allProduct = new List<Product>();
           try{
               using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    allProduct = (List<Product>) connection.Query<Product>("select ProductId,ProductName,Assets.AssetName,Products.IsActive,Products.RecordCreatedBy,Products.RecordCreatedDate,Products.RecordModifiedBy,Products.RecordModifiedDate from Products join Assets on Products.AssetId=Assets.AssetId");
                    
                }   
           }
           catch(Exception ee){
               Console.WriteLine(ee.Message);
           }
           return allProduct;
        }
        public static List<Object> InvestorProduct(int id){
            List<Object> obj = new List<Object>();
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                    string query=@"select Products.ProductName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue from Transactions
                                join Instruments on Transactions.InstrumentId=Instruments.InstrumentId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Products on AssetProductCategory.ProductId = Products.ProductId
                                where Transactions.InvestorId={0} group by Products.ProductName";
                    string finalQuery = String.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                }
            }
            catch(Exception ee){
               Console.WriteLine(ee.Message);
           }
            return obj; 
        }
        public static List<Object> CEOProduct(){
            
            List<Object> obj = new List<Object>();
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                    string query=@"select Products.ProductName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue from Transactions
                                    join Instruments on Transactions.InstrumentId=Instruments.InstrumentId
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                    join Products on AssetProductCategory.ProductId = Products.ProductId
                                    group by Products.ProductName";
                    string finalQuery = String.Format(query);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                }
            }
            catch(Exception ee){
               Console.WriteLine(ee.Message);
           }
            return obj; 
        }
        public static List<Object> AdvisorProduct(int id){

            List<Object> obj = new List<Object>();
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                    string query=@"select Products.ProductName, sum(Transactions.Units*Transactions.UnitValue) as totalValue from Transactions
                            join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                            join Investors on Transactions.InvestorId = Investors.InvestorId
                            join Employees on Investors.EmployeeId = Employees.EmployeeId
                            join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                            join Products on AssetProductCategory.ProductId = Products.ProductId
                            join Roles on Employees.RoleId = Roles.RoleId
                            where Investors.EmployeeId = {0} and Roles.RoleName = 'Advisor' group by Products.ProductName";
                    string finalQuery = String.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                }
            }
            catch(Exception ee){
               Console.WriteLine(ee.Message);
           }
            return obj; 

        }
        public static bool InsertProduct(Product product)
        {
            bool status=false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = "exec sp_AddProduct @AssetName='{0}',@ProductName='{1}'";
                string finalQuery = string.Format(query,product.AssetName,product.ProductName);
                connection.Execute(finalQuery);
                status=true;
                
                } 
            }
            catch(Exception ee){
               Console.WriteLine(ee.Message);
            }
            return status;
                  
        }

        public static bool UpdateProduct(int id,Product product)
        {
            bool status=false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = "exec sp_UpdateProduct @AssetName='{0}',@ProductName='{1}',@ProductId={2}";
                string finalQuery = string.Format(query,product.AssetName,product.ProductName,id);
           
                connection.Execute(finalQuery);
                status=true;
                
                } 
            }
            catch(Exception ee){
               Console.WriteLine(ee.Message);
            }
            return status;
                  
        }

        public static bool DeleteProduct(int id)
        {
            bool status= false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                string query = "update Products set IsActive = 0 where ProductId = {0}";
                string finalQuery = string.Format(query,id);
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

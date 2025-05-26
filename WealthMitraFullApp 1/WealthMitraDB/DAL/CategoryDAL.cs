using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using BOL;

namespace DAL
{
    public class CategoryDAL
    {
         
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
        public static List <Category> GetAll(){
            List<Category> allCategory = new List<Category>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    allCategory = (List<Category>) connection.Query<Category>("select AssetProductCategoryId,Products.ProductName,CategoryName,AssetProductCategory.IsActive,AssetProductCategory.RecordCreatedBy,AssetProductCategory.RecordCreatedDate,AssetProductCategory.RecordModifiedBy,AssetProductCategory.RecordModifiedDate from AssetProductCategory join Products on AssetProductCategory.ProductId=Products.ProductId");
                    
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            
            return allCategory;
            
        }

        public static List<Object> InvestorCategory(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select AssetProductCategory.CategoryName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId 
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                where Transactions.InvestorId = {0} group by AssetProductCategory.CategoryName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                               
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;       


        }
        public static List<Object> InvestorStocksCategory(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select AssetProductCategory.CategoryName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                    from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId 
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
			                        where Transactions.InvestorId = {0} and Instruments.MasterType='Stocks' group by AssetProductCategory.CategoryName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                               
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;   

        }
    
        public static List<Object> InvestorMutualFundsCategory(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =@"select AssetProductCategory.CategoryName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                    from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId 
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
			                        where Transactions.InvestorId = {0} and Instruments.MasterType='MutualFunds' group by AssetProductCategory.CategoryName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                               
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;  

        }
        public static List<Object> CEOStocksCategory()
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =@"select AssetProductCategory.CategoryName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                            from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId 
                            join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
			                where Instruments.MasterType='Stocks' group by AssetProductCategory.CategoryName";
                    string finalQuery = string.Format(query);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                               
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;

        }
        public static List<Object> CEOMutualFundsCategory()
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select AssetProductCategory.CategoryName,sum(Transactions.Units * Transactions.UnitValue) as TotalValue
                                    from Transactions join Instruments on Transactions.InstrumentId = Instruments.InstrumentId 
                                    join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
			                        where Instruments.MasterType='MutualFunds' group by AssetProductCategory.CategoryName";
                    string finalQuery = string.Format(query);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                               
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;
              

        }
        public static List<Category> CategoryById(int id){
            List<Category> category = new List<Category>();
            try{
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query=@"select * from AssetProductCategory where AssetProductCategoryId = {0}";
                    string finalQuery = string.Format(query,id);
                    category = (List<Category>)connection.Query<Category>(finalQuery);
                    
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return category;
        }
        public static bool InsertCategory(Category category){
            bool status = false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                    
                        string query = @"exec sp_AddCategory '{0}','{1}'";
                        string finalQuery = string.Format(query,category.CategoryName,category.ProductName);
                        connection.Execute(finalQuery);
                        status= true;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }

        public static bool UpdateCategory(int id,Category category){
            bool status = false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                    
                        string query = @"exec sp_UpdateCategory @CategoryName='{0}',@ProductName='{1}',@CategoryId={2}";
                        string finalQuery = string.Format(query,category.CategoryName,category.ProductName,id);
                        connection.Execute(finalQuery);
                        status= true;
                }
                    
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }

        public static bool DeleteCategory(int id){
            bool status = false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                
                    string query = @"update AssetProductCategory set IsActive = 0 where AssetProductCategoryId={0}";
                    string finalQuery = string.Format(query,id);
                     connection.Execute(finalQuery);
                     status= true;
                }
                
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }
        public static List<Object> AdvisorStocksCategory(int id)
        {
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select AssetProductCategory.CategoryName, sum(Transactions.Units*Transactions.UnitValue) as totalValue from Transactions
                                join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                                join Investors on Transactions.InvestorId = Investors.InvestorId
                                join Employees on Investors.EmployeeId = Employees.EmployeeId
                                join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                                join Roles on Employees.RoleId = Roles.RoleId
                                where Investors.EmployeeId = {0} and Roles.RoleName = 'Advisor'and Instruments.MasterType='Stocks' group by AssetProductCategory.CategoryName";
                    string finalQuery = string.Format(query,id);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                                  
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;    
        }
        public static List<Object> AdvisorMutualFundsCategory(int id)
        {            
            List<Object> obj = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select AssetProductCategory.CategoryName, sum(Transactions.Units*Transactions.UnitValue) as totalValue from Transactions
                            join Instruments on Transactions.InstrumentId = Instruments.InstrumentId
                            join Investors on Transactions.InvestorId = Investors.InvestorId
                            join Employees on Investors.EmployeeId = Employees.EmployeeId
                            join AssetProductCategory on Instruments.AssetProductCategoryId = AssetProductCategory.AssetProductCategoryId
                            join Roles on Employees.RoleId = Roles.RoleId
                            where Investors.EmployeeId = {0} and Roles.RoleName = 'Advisor'and Instruments.MasterType='MutualFunds' group by AssetProductCategory.CategoryName";
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

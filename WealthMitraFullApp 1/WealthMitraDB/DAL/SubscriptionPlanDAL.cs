using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using BOL;

namespace DAL
{
    public class SubscriptionPlanDAL
    {
        public static List<SubscriptionPlan> allCredentials = null;
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
        static SubscriptionPlanDAL()
        {
           allCredentials  = new List<SubscriptionPlan>();  
        }
        public static List <SubscriptionPlan> GetAll(){
      
           using( SqlConnection connection = new SqlConnection(connectionString))
            {
                allCredentials = (List<SubscriptionPlan>) connection.Query<SubscriptionPlan>("select * from SubscriptionPlans");
                return allCredentials;
            }   
        }

        public static bool Update(int id,SubscriptionPlan obj)
        {
            bool status = false;
            
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "update SubscriptionPlans set SubscriptionPlanName='{0}',Price={1},Features='{2}' where SubscriptionPlanId = {3} ";
                string finalQuery = string.Format(query,obj.SubscriptionPlanName,obj.Price,obj.Features,id);
                connection.Execute(finalQuery);
                status = true;
                return status;
                
            } 
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message); 
            }
            return status;
        }
        public static int Insert(SubscriptionPlan obj)
            {
            
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                string query = "insert into SubscriptionPlans(SubscriptionPlanName,Price,Features,RecordCreatedDate, RecordModifiedDate) values('{0}',{1},'{2}',GETDATE(),GETDATE())";
                string finalQuery = string.Format(query,obj.SubscriptionPlanName,obj.Price,obj.Features);
                int rowsAffected = connection.Execute(finalQuery);
                return rowsAffected;
                
            } 
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
                return 0;
            }
        }
        public static bool Delete(int id){
            bool status = false;
            try{
                using(SqlConnection connection=new SqlConnection(connectionString)){
                
                    string query = @"delete from SubscriptionPlans where SubscriptionPlanId ={0}";
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

        public static bool UpdatePlanDetailsOfInvestor(int Id,Investor investor)
        {
            bool status = false;
            try
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                {
                
                    string query = @"update Investors set SubscriptionPlanId={0}, CurrentStatus = 1, EmployeeId = (SELECT top 1 EmployeeId FROM Employees ORDER BY NEWID()),
                                PlanPurchasedDate=GETDATE(),PlanExpiryDate=(select dateadd(year, 1, getdate())) where InvestorId={1}";

                    string finalQuery = string.Format(query,Id,investor.InvestorId);
                    connection.Execute(finalQuery);
                    status = true;
                }

            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            return status;
        }
        
    }
}

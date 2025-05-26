using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using BOL;

namespace DAL
{
    public class InvestorDAL
    {
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
        
        public static List <Object> GetAllRoles(){
            List<Object> allroles = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    allroles = (List<Object>) connection.Query<Object>("select * from Roles");       
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return allroles;
        }
        public static bool InsertRoles(Roles role){
            bool status = false;
            try{
                using(SqlConnection connection=new SqlConnection(connectionString)){
                
                    string query = @"insert into Roles(RoleName) values ('{0}')";
                    string finalQuery= string.Format(query,role.RoleName);

                    connection.Execute(finalQuery);
                    status = true;
                
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }

        public static bool UpdateRoles(int id,Roles role){
            bool status = false;
            try{
                using(SqlConnection connection=new SqlConnection(connectionString)){
                
                    string query = @"update Roles set RoleName='{0}' where RoleId={1}";
                    string finalQuery= string.Format(query,role.RoleName,id);
                    connection.Execute(finalQuery);
                    status = true;
                }
                
            }
            catch(Exception ee){
                    Console.WriteLine(ee.Message);
            }
            return status;
        }
        public static List<Object> GetInvestorProfile(string username){
      
           using( SqlConnection connection = new SqlConnection(connectionString))
            {
               string query = (@"select Investors.InvestorId,FName,MName,LName,Email,MobileNo,AltrnateMobileNo,Age,Pan,Gender,DOB,MaritalStatus,AddressLine1,
                                AddressLine2,Pincode,AadharNo,City.CityName,state.StateName,Country.CountryName,SubscriptionPlanId,
                                PlanPurchasedDate,PlanExpirydate,Investors.RecordCreatedDate from Investors
                                join City on Investors.CityId=city.CityId
                                join state on City.StateId=State.StateId 
                                join Country on State.CountryId=Country.CountryId  where Investors.Email={0}");
                string finalQuery = string.Format(query,username);
                var obj =  (List<Object>) connection.Query<Object>(finalQuery);
                return obj;  
            }
               
        }
        public static List<Investor> GetInvestorsByAdvisorid(int empid){
      
           using( SqlConnection connection = new SqlConnection(connectionString))
            {
               string query = (@"select Investors.InvestorId,Investors.FName,Investors.MName,Investors.LName,Investors.Email,Investors.MobileNo,Investors.AltrnateMobileNo,Investors.Age,Investors.Pan,Investors.Gender,Investors.DOB,Investors.MaritalStatus,Investors.AddressLine1,
                                Investors.AddressLine2,Investors.Pincode,Investors.AadharNo,City.CityName,state.StateName,Country.CountryName,SubscriptionPlans.SubscriptionPlanName,
                                PlanPurchasedDate,PlanExpirydate,Investors.RecordCreatedDate from investors
                                join Employees on Investors.EmployeeId=Employees.EmployeeId
								join Roles on Employees.RoleId=Roles.RoleId
                                join City on Investors.CityId=city.CityId
                                join state on City.StateId=State.StateId 
                                join Country on State.CountryId=Country.CountryId 
                                join SubscriptionPlans on Investors.SubscriptionPlanId=SubscriptionPlans.SubscriptionPlanId where Investors.EmployeeId ={0} and Roles.RoleName='Advisor'");
                string finalQuery = string.Format(query,empid);
                var obj = (List<Investor>) connection.Query<Investor>(finalQuery);
                return obj;  
            }
               
        }
    public static List<Investor> GetInvestorsByCEO(){
      
           using( SqlConnection connection = new SqlConnection(connectionString))
            {
               string query = (@"select Investors.InvestorId,Investors.FName,Investors.MName,Investors.LName,Investors.Email,Investors.MobileNo,Investors.AltrnateMobileNo,Investors.Age,Investors.Pan,Investors.Gender,Investors.DOB,Investors.MaritalStatus,Investors.AddressLine1,
                                Investors.AddressLine2,Investors.Pincode,Investors.AadharNo,City.CityName,state.StateName,Country.CountryName,SubscriptionPlans.SubscriptionPlanName,
                                PlanPurchasedDate,PlanExpirydate,Investors.RecordCreatedDate from investors
                                join Employees on Investors.EmployeeId=Employees.EmployeeId
								join Roles on Employees.RoleId=Roles.RoleId
                                join City on Investors.CityId=city.CityId
                                join state on City.StateId=State.StateId 
                                join Country on State.CountryId=Country.CountryId 
                                join SubscriptionPlans on Investors.SubscriptionPlanId=SubscriptionPlans.SubscriptionPlanId ");
                
                var obj = (List<Investor>) connection.Query<Investor>(query);
                return obj;  
            }
    }

        public static int CreateInvestorRecord(Investor user)

        {

            using( SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"exec sp_AddInvestor @Fname = '{0}', @Mname ='{1}', @Lname ='{2}', @Email ='{3}', @MobileNo ={4} ,@PAN ='{5}', @AadharNo ='{6}',@CityName='{7}', @Password ='{8}'";
                string finalQuery = string.Format(query,user.Fname,user.Mname,user.Lname,user.Email,user.MobileNo,user.PAN,user.AadharNo,user.CityName,user.Password);
               
                var cons=connection.Execute(finalQuery);
                return cons;
            }
        }
    

        public static bool UpdateInvestor(int id,Investor user){
            bool status = false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                string query = @"exec sp_UpdateInvestor @Fname = '{0}', @Mname ='{1}', @Lname ='{2}', @Email ='{3}', @MobileNo ={4}, @AltrnateMobileNo ={5}, @Age ={6},@PAN ='{7}', @Gender ='{8}',@DOB ='{9}', @MaritalStatus ='{10}', @AddressLine1 ='{11}', @AddressLine2 ='{12}', @PinCode ={13}, @AadharNo ={14}, @CityName ='{15}', @Id={16}";
                string finalQuery = string.Format(query,user.Fname,user.Mname,user.Lname,user.Email,user.MobileNo,user.AltrnateMobileNo,user.Age,user.PAN,user.Gender,user.DOB,user.MaritalStatus,user.AddressLine1,user.AddressLine2,user.PinCode,user.AadharNo,user.CityName,id);

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
        public static List<Transaction> GetTransactions(int id){
            using(SqlConnection connection = new SqlConnection(connectionString)){
                string query = @"select * from Transactions where InvestorId={0}";
                string finalQuery=string.Format(query,id);
                List<Transaction> transactions = (List<Transaction>)connection.Query<Transaction>(finalQuery);
                return transactions;
            }
        }

        public static bool InsertTransactions(int id,Transaction transactions){
            bool status = false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                    string query = @"exec sp_InsertTransactions @NameOfInstrument='{0}',@SchemeCode='{1}',@Action='{2}',@Units={3},@UnitValue={4},@ActionDate='{5}',@InvestorId={6}";
                    string finalQuery = string.Format(query,transactions.NameOfInstrument,transactions.SchemeCode,transactions.Action,transactions.Units,transactions.UnitValue,transactions.ActionDate,id);

                    connection.Execute(finalQuery);

                    status = true;
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return status;
        }

         public static List<Object> GetCountries()
        {
            List<Object> countries = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                
                countries = (List<Object>) connection.Query<Object>("select * from Country");
                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return countries;  
               
        }
         public static List<Object> GetStates()
        {
            List<Object> states = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                
                states = (List<Object>) connection.Query<Object>(@"select StateId,StateName,CountryName,State.IsActive,State.RecordCreatedBy,State.RecordCreatedDate,State.RecordModifiedBy,State.RecordModifiedDate from State join Country on Country.CountryId=State.CountryId");
                
                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return states;  
               
        }
        public static List<Object> GetCities()
        {
            List<Object> cities = new List<Object>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                
                cities = (List<Object>) connection.Query<Object>("select CityId,CityName,StateName,City.IsActive,City.RecordCreatedBy,City.RecordCreatedDate,City.RecordModifiedBy,City.RecordModifiedDate from City join State on City.StateId=State.StateId");
                // return stocks;
                }
            }  
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }         
            return cities;  
               
        }

        public static bool CreateCityRecord(Location cityobject)
        {   bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {  
                    string query = @"exec sp_AddCity @CityName='{0}',@StateName='{1}'";
                    string finalQuery = string.Format(query, cityobject.mainName, cityobject.subName);
                    connection.Execute(finalQuery);
                    status=true;          
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return status; 
        } 
        public static bool CreateStateRecord(Location stateobject)
        {   bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {  
                    string query = @"exec sp_AddState @StateName='{0}',@CountryName='{1}'";
                    string finalQuery = string.Format(query, stateobject.mainName, stateobject.subName);
                    connection.Execute(finalQuery);
                    status=true ;          
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return status; 
        }


        public static bool CreateCountryRecord(Location countryObject)
        {   bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {  
                    string query = @"insert into Country(CountryName,RecordCreatedDate) values('{0}',getdate())";
                    string finalQuery = string.Format(query, countryObject.mainName);
                    connection.Execute(finalQuery);
                    status=true ;          
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return status; 
        } 
        public static bool UpdateCountry(int id,Location countryObject)
        {   bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {  
                    string query = @"update Country set CountryName='{0}',RecordModifiedBy = 'Admin',RecordModifiedDate=GETDATE() where CountryId={1}";
                    string finalQuery = string.Format(query, countryObject.mainName,id);
                    connection.Execute(finalQuery);
                    status=true ;          
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return status; 
        } 

        public static bool UpdateState(int id,Location stateobject)
        {   bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {  
                    string query = @"exec sp_UpadteState @StateName='{0}',@CountryName='{1}', @StateId={2}";
                    string finalQuery = string.Format(query, stateobject.mainName, stateobject.subName,id);
                    connection.Execute(finalQuery);
                    status=true ;          
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return status; 
        }

        public static bool UpdateCity(int id,Location cityobject)
        {   bool status=false;
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {  
                    string query = @"exec sp_UpdateCity @CityName='{0}',@StateName='{1}',@cityId={2}";
                    string finalQuery = string.Format(query, cityobject.mainName, cityobject.subName,id);
                    connection.Execute(finalQuery);
                    status=true ;          
                }
            }  
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }       
            return status; 
        }
    }
}    
   


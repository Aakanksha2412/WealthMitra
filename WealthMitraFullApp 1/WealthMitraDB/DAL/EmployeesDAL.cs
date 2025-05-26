using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using BOL;
namespace DAL
{
    public class EmployeesDAL
    {
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
        
        public static List<Employee> GetAllEmployees(){
            List<Employee> allEmployeee = new List<Employee>();
            try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = (@"select * from Employees");
                    allEmployeee = (List<Employee>)connection.Query<Employee>(query);
                                   
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return allEmployeee; 
      
            
        }

        public static List<Object> GetMyProfile(string username){
            List<Object> obj = new List<Object>();
            try{
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"select Employees.EmployeeId,Employees.FName, Employees.MName,Employees.LName, Employees.Email,Employees.MobileNo, 
                                    Employees.AltrnateMobileNo,Employees.Age, Employees.Gender, Employees.DOB,Employees.MaritalStatus,
                                    Employees.Pan, Employees.AadharNo, Employees.AddressLine1,Employees.AddressLine2,Employees.Pincode,
									 Roles.RoleName, Employees.Experience, Employees.JoiningDate,
                                    Employees.IsActive, Employees.RecordCreatedBy,Employees.RecordCreatedDate, Employees.RecordModifiedBy,
                                    Employees.RecordModifiedDate from Employees
                                    join Roles on Employees.RoleId = Roles.RoleId where Email={0}";
                    string finalQuery = string.Format(query,username);
                    obj = (List<Object>)connection.Query<Object>(finalQuery);
                    
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return obj;
        }
        public static int CreateEmployeeRecord(Employee user)

        {

            using( SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"exec sp_AddEmployee  @Fname='{0}',@Mname ='{1}',@Lname ='{2}',@Email ='{3}',@MobileNo ={4}, @PAN ='{5}',@AadharNo ='{6}',@RoleName ='{7}',@CityName ='{8}', @Password ='{9}'";
                string finalQuery = string.Format(query,user.FName,user.MName,user.LName,user.Email,user.MobileNo,user.PAN,user.AadharNo,user.RoleName,user.CityName,user.Password);
             
                var cons=connection.Execute(finalQuery);
                return cons;
            }
        }

        public static bool UpdateEmployee(int id,Employee user){
            bool status = false;
            try{
                using(SqlConnection connection = new SqlConnection(connectionString)){
                string query = @"exec sp_UpdateEmployee @Fname = '{0}', @Mname ='{1}', @Lname ='{2}', @Email ='{3}', @MobileNo ={4}, @AltrnateMobileNo ={5}, @Age ={6},@PAN ='{7}', @Gender ='{8}',@DOB ='{9}', @MaritalStatus ='{10}', @AddressLine1 ='{11}', @AddressLine2 ='{12}', @PinCode ={13}, @AadharNo ={14}, @CityName ='{15}', @Id={16},@Experience='{17}',@JoiningDate='{18}',@RoleName='{19}'";
                string finalQuery = string.Format(query,user.FName,user.MName,user.LName,user.Email,user.MobileNo,user.AltrnateMobileNo,user.Age,user.PAN,user.Gender,user.DOB,user.MaritalStatus,user.AddressLine1,user.AddressLine2,user.Pincode,user.AadharNo,user.CityName,id,user.Experience,user.JoiningDate,user.RoleName);

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
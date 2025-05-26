using System;
using System.Collections.Generic;
using System.Data.SqlClient;
// using WealthMitra.Models;
using Dapper;
using BOL;

namespace DAL
{
    public class CredentialDAL
    {
        public static string connectionString =@"server=NLPULTP8105053\SQLEXPRESS_19;database=WealthMitra;Integrated Security=true";
        
        public static List <Credential> GetAll(){
           List<Credential> allCredentials = new List<Credential>(); 
           try{
                using( SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select * from Credentials";
                    allCredentials = (List<Credential>) connection.Query<Credential>(query);
                    
                }
            }
            catch(Exception ee){
                Console.WriteLine(ee.Message);
            }
            return allCredentials;
              
        }
        public static List<Object> GetCredential(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            string query = "select * from Credentials where CredentialId = {0}";
            string finalQuery = string.Format(query,id);
            var cred = (List<Object>) connection.Query<Object>(finalQuery);
            return cred;
        }
        public static int ChangePassword(ChangePassword obj)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            var newPass = obj.NewPassword;
            var oldPass = obj.OldPassword;
            var cnPass = obj.ConfirmPassword;
            var email = obj.Email;
            string query = @"update Credentials set password='{0}' where UserName='{1}'";
            string finalQuery = string.Format(query,cnPass,email);
            var cons = connection.Execute(finalQuery);
            return cons;
        }
    }
}

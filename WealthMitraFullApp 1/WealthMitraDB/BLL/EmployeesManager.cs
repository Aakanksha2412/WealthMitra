using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class EmployeesManager
    {
        public static EmployeesManager self=null;
        private EmployeesManager(){
            self=this;
        }
        public static EmployeesManager GetManager(){
            EmployeesManager themanager;
            if(self == null){
                themanager = new EmployeesManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }

        public List<Employee> GetAllEmployees(){
            return EmployeesDAL.GetAllEmployees();
        }
        public int CreateEmployeeRecord(Employee user){
            return  EmployeesDAL.CreateEmployeeRecord(user);
        }

        public List<Object> GetMyProfile(string username){
            return EmployeesDAL.GetMyProfile(username);
        }

        public bool UpdateEmployee(int id,Employee user){
            return EmployeesDAL.UpdateEmployee(id,user);
        }

    }
}
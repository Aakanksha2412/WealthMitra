using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class InvestorManager
    {
        public static InvestorManager self=null;
        private InvestorManager(){
            self=this;
        }
        
        public static InvestorManager GetManager(){
            InvestorManager themanager;
            if(self == null){
                themanager = new InvestorManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }

         public List<Object> GetAllRoles(){
            return InvestorDAL.GetAllRoles();
        }

        public bool InsertRoles(Roles role){
            return InvestorDAL.InsertRoles(role);
        }

        public bool UpdateRoles(int id,Roles role){
            return InvestorDAL.UpdateRoles(id,role);
        }
        public List<Object> GetCountries(){
            return InvestorDAL.GetCountries();
        } 
        public List<Object> GetStates(){
            return InvestorDAL.GetStates();
        } 
        public List<Object> GetCities(){
            return InvestorDAL.GetCities();
        }
        public List<Object> GetInvestorProfile(string username){
            return InvestorDAL.GetInvestorProfile(username);
        }
        public List<Investor> GetInvestorsByAdvisorid(int empid){
            return InvestorDAL.GetInvestorsByAdvisorid(empid);
        }
         public List<Investor> GetInvestorsByCEO(){
            return InvestorDAL.GetInvestorsByCEO();
        }
        public int CreateInvestorRecord(Investor user){
            return  InvestorDAL.CreateInvestorRecord(user);
        }

        public List<Transaction> GetTransactions(int id){
            return InvestorDAL.GetTransactions(id);
        }

        public bool UpdateInvestor(int id,Investor user){
            return InvestorDAL.UpdateInvestor(id,user);
        }

        public bool InsertTransactions(int id,Transaction transaction){
            return InvestorDAL.InsertTransactions(id,transaction);
        }

        public bool CreateCityRecord( Location cityobject){
            return  InvestorDAL.CreateCityRecord(cityobject);
        }
        public bool CreateStateRecord( Location stateobject){
            return  InvestorDAL.CreateStateRecord(stateobject);
        }
        public bool CreateCountryRecord( Location countryObject){
            return  InvestorDAL.CreateCountryRecord(countryObject);
        }

        public bool UpdateCity(int id,Location cityobject){
            return  InvestorDAL.UpdateCity(id,cityobject);
        }
        public bool UpdateState(int id,Location stateobject){
            return  InvestorDAL.UpdateState(id,stateobject);
        }
        public bool UpdateCountry(int id,Location countryobject){
            return  InvestorDAL.UpdateCountry(id,countryobject);
        }

    }
}

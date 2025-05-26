using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class MutualFundManager
    {
        public static MutualFundManager self=null;
        private MutualFundManager(){
            self=this;
        }
        
        public static MutualFundManager GetManager(){
            MutualFundManager themanager;
            if(self == null){
                themanager = new MutualFundManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }

        public  List<MutualFund> GetAll(){
            return MutualFundDAL.GetAll();
        }

        public bool AddMutualFund(MutualFund mutualFundObj){
            return MutualFundDAL.CreateMutualFund(mutualFundObj);
        }
        public bool UpdateMutualFund(int id,MutualFund mutualFundObj){
            return MutualFundDAL.UpdateMutualFund(id,mutualFundObj);
        }
        public  List<Object> InvestorMutualFunds(int id){
            return MutualFundDAL.InvestorMutualFunds(id);
        }
        
        public  List<Object> InvestorBuyMutualFunds(int id){
            return MutualFundDAL.InvestorBuyMutualFunds(id);
        }

    }
}

using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class SubscriptionPlanManager
    {
        public static SubscriptionPlanManager self=null;
        private SubscriptionPlanManager(){
            self=this;
        }
        public static SubscriptionPlanManager GetManager(){
            SubscriptionPlanManager themanager;
            if(self == null){
                themanager = new SubscriptionPlanManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
        public List<SubscriptionPlan> GetAll(){
            return SubscriptionPlanDAL.GetAll();
        }
        public bool Update(int id,SubscriptionPlan obj)
        {
            return SubscriptionPlanDAL.Update(id,obj);
        }
        public int Insert(SubscriptionPlan obj)
        {
            return SubscriptionPlanDAL.Insert(obj);
        }
         public bool Delete(int id)
        {
            return SubscriptionPlanDAL.Delete(id);
        }
        public bool UpdatePlanDetailsOfInvestor(int Id,Investor investor)
        {
            return SubscriptionPlanDAL.UpdatePlanDetailsOfInvestor(Id,investor);
        }
    }
}
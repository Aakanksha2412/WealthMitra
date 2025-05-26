using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class SectorManager
    {
        public static SectorManager self=null;
        private SectorManager(){
            self=this;
        }
        
        public static SectorManager GetManager(){
            SectorManager themanager;
            if(self == null){
                themanager = new SectorManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
       
        public  List<Object> InvestorStocksSector(int id){
            return SectorDAL.InvestorStocksSector(id);
        }
        public  List<Object> InvestorMutualFundsSector(int id){
            return SectorDAL.InvestorMutualFundsSector(id);
        }

        public  List<Object> AdvisorStocksSector(int id){
            return SectorDAL.InvestorStocksSector(id);
        }
        public  List<Object> AdvisorMutualFundsSector(int id){
            return SectorDAL.InvestorMutualFundsSector(id);
        }

        public  List<Object> CeoStocksSector(){
            return SectorDAL.CeoStocksSector();
        }
        public  List<Object> CeoMutualFundsSector(){
            return SectorDAL.CeoStocksSector();
        }
         public  List<Sector> GetAll(){
            return SectorDAL.GetAll();
        }
       
         
        public bool InsertSector(Sector sector){
            return SectorDAL.InsertSector(sector);
        }

        public bool UpdateSector(int id, Sector sector){
            return SectorDAL.UpdateSector(id,sector);
        }
         
    }
         
}

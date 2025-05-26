using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class StockManager
    {
        public static StockManager self=null;
        private StockManager(){
            self=this;
        }
        
        public static StockManager GetManager(){
            StockManager themanager;
            if(self == null){
                themanager = new StockManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
        public List<Stock> GetAll(){
            return StockDAL.GetAll();
        }
        public bool AddStock(Stock stock){
            return StockDAL.CreateStock(stock);
        }

        public bool UpdateStock(int id,Stock stock){
            return StockDAL.UpdateStock(id,stock);
        }

        public  List<Object> InvestorStocks(int id){
            return StockDAL.InvestorStocks(id);
        }
        public  List<Object> InvestorBuyStocks(int id){
            return StockDAL.InvestorBuyStocks(id);
        }

    }
}

using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class CategoryManager
    {
        public static CategoryManager self=null;
        private CategoryManager(){
            self=this;
        }
        public static CategoryManager GetManager(){
            CategoryManager themanager;
            if(self == null){
                themanager = new CategoryManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
        public List<Category> GetAll(){
            return CategoryDAL.GetAll();
        }

        public List<Object> InvestorCategory(int id){
            return CategoryDAL.InvestorCategory(id);
        }
        public List<Object> InvestorStocksCategory(int id){
            return CategoryDAL.InvestorStocksCategory(id);
        }
         public List<Object> InvestorMutualFundsCategory(int id){
            return CategoryDAL.InvestorMutualFundsCategory(id);
        }
        public List<Object> CEOStocksCategory(){
            return CategoryDAL.CEOStocksCategory();
        }
        public List<Object> CEOMutualFundsCategory(){
            return CategoryDAL.CEOMutualFundsCategory();
        }
        public List<Category> CategoryById(int id){
            return CategoryDAL.CategoryById(id);
        }
        public List<Object> AdvisorStocksCategory(int id){
            return CategoryDAL.AdvisorStocksCategory(id);
        }

        public List<Object> AdvisorMutualFundsCategory(int id){
            return CategoryDAL.AdvisorMutualFundsCategory(id);
        }
        
        public bool InsertCategory(Category category){
            return CategoryDAL.InsertCategory(category);
        }

        public bool UpdateCategory(int id,Category category){
            return CategoryDAL.UpdateCategory(id,category);
        }
        public bool DeleteCategory(int id){
            return CategoryDAL.DeleteCategory(id);
        }

    }
}

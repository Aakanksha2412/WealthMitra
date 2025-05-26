using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class ProductManager
    {
        public static ProductManager self=null;
        private ProductManager(){
            self=this;
        }
        public static ProductManager GetManager(){
            ProductManager themanager;
            if(self == null){
                themanager = new ProductManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
        public List<Product> GetAll(){
            return ProductDAL.GetAll();
        }

        public  List<Object> InvestorProduct(int id){
            return ProductDAL.InvestorProduct(id);
        }
        public  List<Object> CEOProduct(){
            return ProductDAL.CEOProduct();
        }
        public  List<Object> AdvisorProduct(int id){
            return ProductDAL.AdvisorProduct(id);
        }

        public bool InsertProduct(Product product)
        {
            return ProductDAL.InsertProduct(product);
        }

        public bool UpdateProduct(int id,Product product)
        {
            return ProductDAL.UpdateProduct(id,product);
        }

        public bool DeleteProduct(int id)
        {
            return ProductDAL.DeleteProduct(id);
        }
    }
}

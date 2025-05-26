using System;
using System.Collections.Generic;
using DAL;
using BOL;

namespace BLL
{
    public class AssetManager
    {
        public static AssetManager self=null;
        private AssetManager(){
            self=this;
        }
        
        public static AssetManager GetManager(){
            AssetManager themanager;
            if(self == null){
                themanager = new AssetManager();
               
            }
            else{
                themanager = self;
            }
            return themanager;
        }
        public List<Asset> GetAll(){
            return AssetDAL.GetAll();
        }
        public  List<Object> InvestorAsset(int id){
            return AssetDAL.InvestorAsset(id);
        }
        public  List<Object> CEOAsset(){
            return AssetDAL.CEOAsset();
        }
        public List<Object> AdvisorAsset(int id){
            return AssetDAL.AdvisorAsset(id);
        }
        public List<Asset> GetAssetById(int id){
            return AssetDAL.GetAssetById(id);
        }
        public bool InsertAsset(Asset asset){
            return AssetDAL.InsertAsset(asset);
        }
        public bool UpdateAsset(int id, Asset asset){
            return AssetDAL.UpdateAsset(id,asset);
        }
        public bool DeleteAsset(int id){
            return AssetDAL.DeleteAsset(id);
        } 
         
    }
         
}

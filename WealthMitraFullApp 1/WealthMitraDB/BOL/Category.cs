using System;

namespace BOL
{
    public class  Category{
        public int AssetProductCategoryId {get;set;}
        public string CategoryName {get; set;}
        public int ProductID {get;set;}
        public string ProductName{get;set;}
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}
    }
}
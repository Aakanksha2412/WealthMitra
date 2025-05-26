using System;

namespace BOL
{
    public class  Product{
        public int ProductID {get;set;}
        public string ProductName {get; set;}
        public string AssetName {get;set;}
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}
    }
}
using System;

namespace BOL
{
    public class MutualFund
    {
        public int MutualFundId { get; set; }
        public string MutualFundName { get; set; }
        public string SchemeCode { get; set; }
        public string  CategoryName { get; set; }
        public string SectorName { get; set; }
        public string ProductName { get; set; }
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate { get; set; }
        public string RecordModifiedBy { get; set; } 
        public string RecordModifiedDate { get; set; }
    }
}
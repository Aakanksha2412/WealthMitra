using System;

namespace BOL
{
    public class Stock
    {
        public int StockId { get; set; }
        public string StockName { get; set; }
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
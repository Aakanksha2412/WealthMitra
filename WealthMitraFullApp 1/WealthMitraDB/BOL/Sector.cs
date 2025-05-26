using System;

namespace BOL
{
    public class Sector
    {
        public int  SectorID  { get; set; }            
        public string SectorName { get; set; }
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}

    }
}

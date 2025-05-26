namespace BOL{
    public class Transaction{
        public int TransactionId{get;set;}
        public int InvestorId{get;set;}
        public int InstrumentId{get;set;}
        public string NameOfInstrument{get;set;}
        public string SchemeCode{get;set;}
        public string Action{get;set;}
        public int Units{get;set;}
        public float UnitValue{get;set;}
        public float TotalValue{get;set;}
        public float AverageValue{get;set;}
        public string ActionDate{get;set;}
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}
    }
}
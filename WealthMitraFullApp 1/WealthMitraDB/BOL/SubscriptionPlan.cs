 namespace BOL{
     public class SubscriptionPlan{
         public int SubscriptionPlanID {get; set;}
         public string SubscriptionPlanName{get;set;}
         public float Price{get;set;}
         public string Features{get;set;}
         public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}

     }
 }
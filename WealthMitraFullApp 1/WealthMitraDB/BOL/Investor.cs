using System;

namespace BOL
{
    public class Investor
    {
        public int InvestorId{get; set;}      
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public long MobileNo { get; set; }
        public long AltrnateMobileNo { get; set; }
        public int Age { get; set; }
        public string PAN { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string MaritalStatus { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PinCode { get; set; }
        public string AadharNo { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string Password{get;set;}
        public string SubscriptionPlanName {get;set;}
        public int CurrentStatus{get;set;}
        public string PlanPurchasedDate {get;set;}
        public string PlanExpiryDate {get;set;}
        public string RecordCreatedDate {get;set;}
    }
}


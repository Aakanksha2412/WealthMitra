
namespace BOL{
    public class Employee{
        public int EmployeeId{get;set;}
        public string FName{get; set;}
        public string MName{get; set;}
        public string LName{get; set;}
        public string Email{get; set;}
        public long MobileNo{get; set;}
        public string RoleName{get;set;}
        public long AltrnateMobileNo{get;set;}
        public int Age{get;set;}
        public string Gender{get;set;}
        public string DOB{get;set;}
        public string MaritalStatus{get;set;}
        public string PAN{get;set;}
        public string AadharNo{get;set;}
        public string AddressLine1{get;set;}
        public string AddressLine2{get;set;}
        public int Pincode{get;set;}
        public string CityName{get;set;}
        public string StateName{get;set;}
        public string CountryName{get;set;}

        public string Experience{get;set;}
        public string JoiningDate{get;set;}
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}
        public string Password{get;set;}

    }
}
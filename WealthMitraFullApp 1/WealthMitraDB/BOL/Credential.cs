using System;
using System.Text.Json.Serialization;
namespace BOL
{
    public class Credential
    {
        public int CredentialID {get; set;}
        public string UserName {get;set;}
        [JsonIgnore]
        public string Password{get; set;}
        public int RoleID{get;set;}
        public bool IsActive { get; set; }
        public string RecordCreatedBy { get; set; }
        public string RecordCreatedDate  { get; set; }  
        public string RecordModifiedBy { get; set; }
        public string RecordModifiedDate {get;set;}
        public string Token { get; set; }
    }
}

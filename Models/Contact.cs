using System;

namespace contactManagementBackend.Models
{
    public record Contact
    {
        public Guid Id {get;  set;}
         public string FirstName {set; get;}
        public string LastName{set; get;}
        public string Email {set; get;}
        public string MobilePhoneNumber {set; get;}
        
        public string HomePhoneNumber {set; get;}
        public string BusinessPhoneNumber {set; get;}
        
    }
}
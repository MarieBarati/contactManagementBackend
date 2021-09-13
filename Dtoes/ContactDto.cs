using System;

namespace contactManagementBackend.Dtoes
{
     public record ContactDto
    {
        
        public Guid Id {set; get;}
        
        public string FirstName {set; get;}
        public string LastName{set; get;}
        public string Email {set; get;}
        public string HomePhoneNumber {set; get;}
        public string BusinessPhoneNumber {set; get;}
        public string MobilePhoneNumber {set; get;}
    }
}
using contactManagementBackend.Dtoes;
using contactManagementBackend.Models;

namespace contactManagementBackend
{
    public static class Extension
    {
        
        public static ContactDto AsDto(this Contact contact){
            return new ContactDto{
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                MobilePhoneNumber = contact.MobilePhoneNumber,
                BusinessPhoneNumber=contact.BusinessPhoneNumber,
                Email=contact.Email
            };

        }
    }
}
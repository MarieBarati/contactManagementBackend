using System;
using System.Collections.Generic;
using contactManagementBackend.Dtoes;
using contactManagementBackend.Models;

namespace contactManagementBackend
{
    public static class Extensions
    {
        public static ContactDto AsDto(this Contact contact){
            return new ContactDto{
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                MobilePhoneNumber = contact.MobilePhoneNumber,
                HomePhoneNumber = contact.HomePhoneNumber,
                BusinessPhoneNumber = contact.BusinessPhoneNumber
            };
        }
        public static ContactListDto AsContactListReponse (this IEnumerable<ContactDto> contactList, int ContactNumber){

            return new ContactListDto {
                ContactList = contactList,
                TotalNumber = ContactNumber
            };

        }
        
    }
}
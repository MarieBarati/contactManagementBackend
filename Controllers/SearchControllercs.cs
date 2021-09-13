using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contactManagementBackend.Dtoes;
using contactManagementBackend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace contactManagementBackend.Controllers
{
    [ApiController]
    [Route("/api/search")]
    public class SearchController : ControllerBase
    {
        private readonly IcontactRepository  repository;
        public SearchController(IcontactRepository repository)
        {
            this.repository = repository;
            
        }

        [HttpGet]
        public async Task<ActionResult<ContactListDto>> SearchContactAsync(string firstname, string lastname, int PageNumber=1, int PageSize=50){

            if ((firstname is null) && (lastname is null)){
                var AllContacts = (await repository.GetContactAsync(PageNumber, PageSize)).Select(contact => contact.AsDto());
                return AllContacts.AsContactListReponse(await repository.TotalRecordsAsync()); 
                
            } 
            if ((firstname is null) && (lastname is not null)){
                var contactsForLastname = (await repository.SearchContactsByLastNameAsync(lastname, PageNumber, PageSize)).Select(contact => contact.AsDto());
                int ContactForLastNameNumber = contactsForLastname.Count();
                return contactsForLastname.AsContactListReponse(ContactForLastNameNumber);
            }
            if ((firstname is not null) && (lastname is null)){
                var contactsForFirstname = (await repository.SearchContactsByFirstNameAsync(firstname, PageNumber, PageSize)).Select(contact => contact.AsDto());
                int ContactForFirstNameNumber = contactsForFirstname.Count();
                return contactsForFirstname.AsContactListReponse(ContactForFirstNameNumber);
            }

            var contacts = (await repository.SearchContactsAsync(firstname, lastname, PageNumber, PageSize)).Select(contact => contact.AsDto());
            int ContactNumber = contacts.Count();
            return contacts.AsContactListReponse(ContactNumber);
        } 
     
    }
}
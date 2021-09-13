using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contactManagementBackend;
using contactManagementBackend.Dtoes;
using contactManagementBackend.Models;
using contactManagementBackend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Name.Controllers
{

    
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    { 
        private readonly IcontactRepository repository;
       
        public ContactController(IcontactRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<ContactListDto> GetContactsAsync(int PageNumber=1, int PageSize=50)
        {
            var contactList = (await repository.GetContactAsync(PageNumber,PageSize))
            .Select(c=> new ContactDto{
                Id = c.Id, 
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                MobilePhoneNumber = c.MobilePhoneNumber,
                BusinessPhoneNumber = c.BusinessPhoneNumber,
                HomePhoneNumber = c.HomePhoneNumber
            });
        
            return  new ContactListDto{
                ContactList = contactList,
                TotalNumber = (await repository.TotalRecordsAsync())
            };

            
        }
         [HttpPost]
        public async Task<ActionResult> CreateContactAsync(CreateDto contactdto){
            Contact newContact = new(){
                Id = Guid.NewGuid(),
                FirstName = contactdto.FirstName,
                LastName = contactdto.LastName,
                MobilePhoneNumber = contactdto.MobilePhoneNumber,
                Email = contactdto.Email,
                HomePhoneNumber = contactdto.HomePhoneNumber,
                BusinessPhoneNumber = contactdto.BusinessPhoneNumber
            };
            await repository.CreateContactAsync(newContact);
            return Ok();
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContactAsync(Guid id, UpdateContactDto updateDto){
            var existingContact = await repository.GetContactAsync(id);
            if(existingContact is null){
                return NotFound();
            }
            Contact updateContact = existingContact with{
                FirstName = updateDto.FirstName is null ? existingContact.FirstName: updateDto.FirstName,
                LastName = updateDto.LastName is null ? existingContact.LastName: updateDto.LastName,
                Email = updateDto.Email is null ? existingContact.Email: updateDto.Email,
                MobilePhoneNumber = updateDto.MobilePhoneNumber is null ? existingContact.MobilePhoneNumber: updateDto.MobilePhoneNumber,
                HomePhoneNumber = updateDto.HomePhoneNumber is null ? existingContact.HomePhoneNumber: updateDto.HomePhoneNumber,
                BusinessPhoneNumber = updateDto.BusinessPhoneNumber is null ? existingContact.BusinessPhoneNumber: updateDto.BusinessPhoneNumber
            };
            await repository.UpdateContactAsync(updateContact);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id){
            Contact existingContact = await repository.GetContactAsync(id);
            if (existingContact is null){
                return NotFound();
            }

            await repository.DeleteContactAsync(id);
            return NoContent();
        }
    }
}
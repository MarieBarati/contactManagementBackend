
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using contactManagementBackend;
using contactManagementBackend.Dtoes;
using contactManagementBackend.Models;
using contactManagementBackend.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace contactManagementBackend.Controllers
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
            .Select(contact => contact.AsDto());
        
            return  contactList.AsContactListReponse(await repository.TotalRecordsAsync());

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> GetContactAsync(Guid id){
            var contact = await repository.GetContactAsync(id);

            if (contact is null){
                return NotFound();
            }
            return contact.AsDto();
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
            try{
                await repository.CreateContactAsync(newContact);
            }
            catch (DbException e){
                return StatusCode(500, e);
            }
            return StatusCode(200, "Success");
           
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
            try{
                await repository.UpdateContactAsync(updateContact);
            }
            catch (DbException e){
                return StatusCode(500, e);
            }

            return StatusCode(200, "Sucess");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id){
            Contact existingContact = await repository.GetContactAsync(id);
            if (existingContact is null){
                return NotFound();
            }
            try{
                await repository.DeleteContactAsync(id);
            }
            catch (DbException e){
                return StatusCode(500, e);
            }
            return NoContent();
        }
    }
}
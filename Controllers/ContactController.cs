using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using contactManagementBackend.Dtoes;
using contactManagementBackend.Models;
using contactManagementBackend.Repository;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<ContactDto>> GetContactsAsync(int PageNumber, int PageSize)
        {
            return await repository.GetContactAsync(PageNumber,PageSize);

        }
    }
}
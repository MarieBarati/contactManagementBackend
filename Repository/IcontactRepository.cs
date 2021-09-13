using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contactManagementBackend.Models;

namespace contactManagementBackend.Repository
{
    public interface IcontactRepository
    {
        Task<Contact> GetContactAsync(Guid Id); 
        Task<IEnumerable<Contact>> GetContactAsync(int PageNumber, int PageSize);

        Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname, int PageNumber, int PageSize);
        Task<IEnumerable<Contact>> SearchContactsAsync(string query, int PageNumber, int PageSize);

         Task<IEnumerable<Contact>> SearchContactsByFirstNameAsync(string firstname, int PageNumber, int PageSize);

          Task<IEnumerable<Contact>> SearchContactsByLastNameAsync(string lastname, int PageNumber, int PageSize);
    
        Task CreateContactAsync(Contact contact);

        Task UpdateContactAsync(Contact contact);

        Task DeleteContactAsync(Guid id);

        Task <int> TotalRecordsAsync();
    }
}
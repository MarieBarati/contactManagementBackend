using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using contactManagementBackend.Models;

namespace contactManagementBackend.Repository
{
    public class SqliteRepository : IcontactRepository
    {
        public Task CreateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContactAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetContactAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetContactAsync(int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname, int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> SearchContactsAsync(string query, int PageNumber, int PageSize)
        {
            throw new NotImplementedException();
        }

        public Task<int> TotalRecordsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
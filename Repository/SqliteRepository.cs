using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contactManagementBackend.DataBasaContext;
using contactManagementBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace contactManagementBackend.Repository
{
    public class SqliteRepository : IcontactRepository
    {
          private readonly DataContext context;
        public SqliteRepository(DataContext context)
        {
            this.context = context;
        }
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

        public async Task<IEnumerable<Contact>> GetContactAsync(int PageNumber, int PageSize)
        {
             return await context.Contacts
            .OrderBy(a => a.LastName)
            .Skip((PageNumber-1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
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
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
        public async  Task CreateContactAsync(Contact contact)
        {
            context.Contacts.Add(contact);
            try{
            await context.SaveChangesAsync();
            }
            catch{
                throw;
            }
        }

        public async Task DeleteContactAsync(Guid id)
        {
           var existingContact = await context.Contacts.FindAsync(id);
            context.Remove(existingContact);
            await context.SaveChangesAsync();
        }

        public async Task<Contact> GetContactAsync(Guid Id)
        {
           return await context.Contacts.FindAsync(Id);
        }

        public async Task<IEnumerable<Contact>> GetContactAsync(int PageNumber, int PageSize)
        {
             return await context.Contacts
            .OrderBy(a => a.LastName)
            .Skip((PageNumber-1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string firstname, string lastname, int PageNumber, int PageSize)
        {
             return await context.Contacts
            .Where(Contact=> Contact.FirstName.ToLower().StartsWith(firstname.ToLower()) && Contact.LastName.ToLower().StartsWith(lastname.ToLower()))
            .Skip((PageNumber -1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> SearchContactsAsync(string query, int PageNumber, int PageSize)
        {
            return await context.Contacts
            .Where(Contact=> Contact.FirstName.ToLower().StartsWith(query.ToLower()) || Contact.LastName.ToLower().StartsWith(query.ToLower()))
            .Skip((PageNumber -1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

         
        public async  Task<IEnumerable<Contact>> SearchContactsByFirstNameAsync(string firstname, int PageNumber, int PageSize){
            return await context.Contacts
            .Where(Contact=> Contact.FirstName.ToLower().StartsWith(firstname.ToLower()) )
            .Skip((PageNumber -1) * PageSize)
            .Take(PageSize)
            .ToListAsync();

        }

        public async Task<IEnumerable<Contact>> SearchContactsByLastNameAsync(string lastname, int PageNumber, int PageSize){
             return await context.Contacts
            .Where(Contact=> Contact.LastName.ToLower().StartsWith(lastname.ToLower()) )
            .Skip((PageNumber -1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }

        public async Task<int> TotalRecordsAsync()
        {
            return await Task.FromResult(context.Contacts.Count());
        }

        public async Task UpdateContactAsync(Contact contact)
        {
            var existingContact = await context.Contacts.FindAsync(contact.Id);
            var props = typeof(Contact).GetProperties();
            foreach(var prop in props){
                var value = prop.GetValue(contact);
                
                prop.SetValue(existingContact, value);
            }
            try{
            await context.SaveChangesAsync();
            }
            catch{
                throw;
            }
        }
    }
}
using contactManagementBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace contactManagementBackend.DataBasaContext
{
    public class DataContext:DbContext
    {
          public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            Database.EnsureCreated();
            
        }
      public DbSet<Contact> Contacts{get;set;}
    }
}
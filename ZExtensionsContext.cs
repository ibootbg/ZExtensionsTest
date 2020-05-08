using System.Data.Entity;

namespace ZExtensionsTest
{
    public class ZExtensionsContext : DbContext
    {
        public ZExtensionsContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
    }
}
using System;
using System.Data.Entity;
using System.Linq;

namespace ZExtensionsTest
{
    // Prerequisites:
    // 1. Create SQL DB.
    // 2. Open SQL Server Management Studio and execute SQL\CreateAndInitTables.sql.
    class Program
    {
        // specify DB Server name
        private const string DbServer = "localhost";
        // specify DB name
        private const string DbName = "ZExtensions";
        static void Main()
        {
            try
            {
                Database.SetInitializer<ZExtensionsContext>(null);

                using (var ctx = new ZExtensionsContext($"Server = {DbServer}; Database = {DbName}; Trusted_Connection = True;"))
                {
                    // Update the first record
                    ctx.Contacts.First().Address = "AddressMax10AddressMax20AddressMax30AddressMax40AddressMax50";
                    try
                    {
                        ctx.SaveChanges();
                        Console.WriteLine("SaveChanges succeeded (incorrect)");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("SaveChanges failed (correct)");
                    }
                    // this should fail, but it doesn't
                    ctx.BulkSaveChanges();
                    Console.WriteLine("BulkSaveChanges: updating 1 record succeeded (incorrect)");

                    // Update all 1000 records
                    foreach (var contact in ctx.Contacts)
                    {
                        contact.Address = "AddressMax10AddressMax20AddressMax30AddressMax40AddressMax50";
                    }
                    try
                    {
                        ctx.BulkSaveChanges(false);
                        Console.WriteLine("BulkSaveChanges: Updating 1000 records succeeded (incorrect)");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("BulkSaveChanges: Updating 1000 records failed (correct)");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

using System;
using System.Data.Entity;

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
                    foreach (var contact in ctx.Contacts)
                    {
                        contact.Address = "AddressMax10AddressMax20AddressMax30AddressMax40AddressMax50";
                    }

                    var tran = ctx.Database.BeginTransaction();
                    try
                    {
                        ctx.BulkSaveChanges(false);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        try
                        {
                            tran.Rollback();
                            Console.WriteLine("Rollback works!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Rollback doesn't work!");
                        }
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

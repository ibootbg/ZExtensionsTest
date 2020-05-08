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
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

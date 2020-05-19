using KSTrips.Infrastructure.Database.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Infrastructure.Database
{
    public static class DatabaseInitializer
    {
        public static void Seed(TripContext context)
        { 

            // Seed database objects (sequences, functions, views, stored procedures, etc)
            ScriptSeeder.SeedDatabaseObjects(context);

            // Execute deployment scripts
            ScriptSeeder.ExecuteDeploymentScripts(context);
        }
    }
}

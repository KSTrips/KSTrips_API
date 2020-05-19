using KSTrips.Infrastructure.Database.Functions;
using KSTrips.Infrastructure.Database.StoredProcedures;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace KSTrips.Infrastructure.Database.Scripts
{
    internal class ScriptSeeder
    {
        /// <summary>
        ///     Execute Deployment scripts
        /// </summary>
        /// <param name="context">The database context</param>
        public static void ExecuteDeploymentScripts(TripContext context)
        {
            // Execute deployment scripts
            ScriptSeeder.ExecuteSqlFile(context, ScriptsSeedHelper.CreatePath.Deployment);
        }

        /// <summary>
        ///     Method to seed database objects (sequences, functions, views, stored procedures, etc)
        /// </summary>
        /// <param name="context">The database context</param>
        public static void SeedDatabaseObjects(TripContext context)
        {
            // Drop all before recreating
            ScriptSeeder.DropAll(context);

            // Create all of the entities
            ScriptSeeder.CreateAll(context);

            // Grant any permissions that could not be granted in the initial seeding
            ScriptSeeder.GrantPermissions(context);

        }

        /// <summary>
        ///     This method will create all of the views and stored procedures set up by this seed file
        /// </summary>
        /// <param name="context">The database context</param>
        private static void CreateAll(TripContext context)
        {
            // Chronology is important when creating database objects due to dependencies.
            // Order should be: (1) Functions (2) Views (3) Stored Procedures.
            // Scripts are a wildcard and may be run first or last.

            // Scripts (for before "creates" are completed)
            ScriptSeeder.ExecuteSqlFile(context, ScriptsSeedHelper.CreatePath.Deployment);

            // Functions
            ScriptSeeder.ExecuteSqlFile(context, FunctionsSeedHelper.CreatePath.Split);


            // Views


            // Stored Procedures
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetDashBoardReport);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetDetailReport);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetExpenseReport);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetFinancialReport);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetMonthlyDashboard);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetQtyReport);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.SaveTolls);
            ScriptSeeder.ExecuteSqlFile(context, StoredProceduresSeedHelper.CreatePath.GetMaintenanceVehicles);


            // Scripts (for after "creates" are completed)
        }

        /// <summary>
        ///     This method will drop all of the views and stored procedures set up by this seed file
        /// </summary>
        /// <param name="context">The database context</param>
        private static void DropAll(TripContext context)
        {
            // Chronology is important when dropping database objects due to dependencies.
            // Order should be: (1) Stored Prcedures (2) Views (3) Functions.
            // Scripts are a wildcard and may be run first or last.

            // Scripts (for before "drops" are completed)

            // Stored Procedures
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetDashBoardReport);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetDetailReport);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetExpenseReport);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetFinancialReport);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetMonthlyDashboard);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetQtyReport);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.SaveTolls);
            context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.DropCommand.GetMaintenanceVehicles);

            // Views


            // Functions (must drop functions last due to dependencies)
            context.Database.ExecuteSqlCommand(FunctionsSeedHelper.DropCommand.Split);

            // Scripts (for after "drops" are completed)
        }

        /// <summary>
        ///     This method will run the sql file at the given location against the context
        /// </summary>
        /// <param name="context">The database context</param>
        /// <param name="sqlFile">The file location of the sql file to run</param>
        private static void ExecuteSqlFile(TripContext context, string sqlFile)
        {
            var sqlText = File.ReadAllText(sqlFile);

            context.Database.ExecuteSqlCommand(sqlText);
        }

        /// <summary>
        ///     This method will grant permissions to the sql entities created in this seed class
        /// </summary>
        /// <param name=""></param>
        private static void GrantPermissions(TripContext context)
        {
            // Views do not require permissions to query

            //// Stored Procedures
            ////context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsDeletedDictationsProc); // this SP contains a function call json_value which is not supported in SQL Server 2014 (used by Genex developers due to Windows 7 restrictions). Therefore the SP must be manually seeded in all environments.
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsNewReferralsProc);
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsClosedDetailsProc);
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsInvoiceSummaryProc);
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsDailyInvoicesSalesProc);
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsDataDumpProc);
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsCustomerPortalAccessAuditProc);
            //context.Database.ExecuteSqlCommand(StoredProceduresSeedHelper.GrantCommand.ReportsTranscriptionChecklistProc);

            //// Functions
            //context.Database.ExecuteSqlCommand(FunctionsSeedHelper.GrantCommand.CsvToTableFunc);

        }

    }

}

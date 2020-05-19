using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KSTrips.Infrastructure.Database.StoredProcedures
{
    internal static class StoredProceduresSeedHelper
    {
        /// <summary>
        ///     File Paths
        /// </summary>
        private static class FilePath
        {
            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string GetDashBoardReport = @"Database\StoredProcedures\GetDashBoardReport.sql";

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string GetDetailReport = @"Database\StoredProcedures\GetDetailReport.sql";

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string GetExpenseReport = @"Database\StoredProcedures\GetExpenseReport.sql";

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string GetFinancialReport = @"Database\StoredProcedures\GetFinancialReport.sql";

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string GetMonthlyDashboard = @"Database\StoredProcedures\GetMonthlyDashboard.sql";

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string GetQtyReport = @"Database\StoredProcedures\GetQtyReport.sql";

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string SaveTolls = @"Database\StoredProcedures\SaveTolls.sql";

            public const string GetMaintenanceVehicles = @"Database\StoredProcedures\GetMaintenanceVehicles.sql";

        }

        /// <summary>
        ///     Create Paths
        /// </summary>
        public static class CreatePath
        {
            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string GetDashBoardReport = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetDashBoardReport);

            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string GetDetailReport = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetDetailReport);

            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string GetExpenseReport = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetExpenseReport);

            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string GetFinancialReport = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetFinancialReport);

            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string GetMonthlyDashboard = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetMonthlyDashboard);

            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string GetQtyReport = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetQtyReport);

            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string SaveTolls = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.SaveTolls);

            public static readonly string GetMaintenanceVehicles = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.GetMaintenanceVehicles);


        }

        /// <summary>
        ///     Drop Commands
        /// </summary>
        public static class DropCommand
        {
            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string GetDashBoardReport = "IF OBJECT_ID('[dbo].[GetDashBoardReport]','P') IS NOT NULL DROP PROC [dbo].[GetDashBoardReport];";

            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string GetDetailReport = "IF OBJECT_ID('[dbo].[GetDetailReport]','P') IS NOT NULL DROP PROC [dbo].[GetDetailReport];";

            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string GetExpenseReport = "IF OBJECT_ID('[dbo].[GetExpenseReport]','P') IS NOT NULL DROP PROC [dbo].[GetExpenseReport];";

            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string GetFinancialReport = "IF OBJECT_ID('[dbo].[GetFinancialReport]','P') IS NOT NULL DROP PROC [dbo].[GetFinancialReport];";

            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string GetMonthlyDashboard = "IF OBJECT_ID('[dbo].[GetMonthlyDashboard]','P') IS NOT NULL DROP PROC [dbo].[GetMonthlyDashboard];";

            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string GetQtyReport = "IF OBJECT_ID('[dbo].[GetQtyReport]','P') IS NOT NULL DROP PROC [dbo].[GetQtyReport];";

            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string SaveTolls = "IF OBJECT_ID('[dbo].[SaveTolls]','P') IS NOT NULL DROP PROC [dbo].[SaveTolls];";

            public const string GetMaintenanceVehicles = "IF OBJECT_ID('[dbo].[GetMaintenanceVehicles]','P') IS NOT NULL DROP PROC [dbo].[GetMaintenanceVehicles];";



        }

        /// <summary>
        ///     Grant Commands
        /// </summary>
        public static class GrantCommand
        {
            ///// <summary>
            /////     SQL command string that grants permissions on the database object.
            ///// </summary>
            //public const string ReportsClosedDetailsProc = "IF EXISTS(SELECT 1 FROM sys.sysusers WHERE name = 'WindwardReportsUser' ) GRANT EXECUTE ON [dbo].[ReportsClosedDetailsProc] TO [WindwardReportsUser];";

        }
    }

}

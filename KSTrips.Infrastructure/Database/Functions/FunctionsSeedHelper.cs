using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KSTrips.Infrastructure.Database.Functions
{
    internal static class FunctionsSeedHelper
    {
        /// <summary>
        ///     File Paths
        /// </summary>
        private static class FilePath
        {

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string Split = @"Database\Functions\Split.sql";
        }

        /// <summary>
        ///     Create Paths
        /// </summary>
        public static class CreatePath
        {
            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string Split = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.Split);


        }

        /// <summary>
        ///     Drop Commands
        /// </summary>
        public static class DropCommand
        {
            /// <summary>
            ///     SQL command string that drops the database object.
            /// </summary>
            public const string Split = "IF EXISTS( SELECT 1 FROM Information_schema.Routines WHERE Specific_schema = 'dbo' AND specific_name = 'Split' AND Routine_Type = 'FUNCTION' ) DROP FUNCTION[dbo].[Split]";

        }

        /// <summary>
        ///     Grant Commands
        /// </summary>
        public static class GrantCommand
        {
            ///// <summary>
            /////     SQL command string that grants permissions on the database object.
            ///// </summary>
            //public const string CsvToTableFunc = "IF EXISTS(SELECT 1 FROM sys.sysusers WHERE name = 'WindwardReportsUser') GRANT SELECT ON[dbo].[CSVToTableFunc] TO[WindwardReportsUser]";


        }
    }

}

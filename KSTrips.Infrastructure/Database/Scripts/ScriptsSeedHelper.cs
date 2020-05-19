using System;
using System.IO;

namespace KSTrips.Infrastructure.Database.Scripts
{
    internal static class ScriptsSeedHelper
    {
        /// <summary>
        ///     File Paths
        /// </summary>
        private static class FilePath
        {

            /// <summary>
            ///     Get the file location relative to the project
            /// </summary>
            public const string Deployments = @"Database\Scripts\Deployment.sql";

        }

        /// <summary>
        ///     Create Paths
        /// </summary>
        public static class CreatePath
        {
            /// <summary>
            ///     Get file location based on the current domain base directory.
            /// </summary>
            public static readonly string Deployment = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FilePath.Deployments);

        }

        /// <summary>
        ///     Drop Commands
        /// </summary>
        public static class DropCommand
        {
            // Placeholder for future drop commands (see FunctionsSeedHelper.cs for examples of how to formulate the drop strings). do not remove DropCommand class.
        }

        /// <summary>
        ///     Grant Commands
        /// </summary>
        public static class GrantCommand
        {
            // Placeholder for future grant commands (see FunctionsSeedHelper.cs for examples of how to formulate the grant strings). do not remove GrantCommand class.
        }
    }

}

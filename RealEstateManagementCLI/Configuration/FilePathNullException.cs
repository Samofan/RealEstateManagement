using System;
using CliFx.Exceptions;
using RealEstateManagementCLI.Commands;

namespace RealEstateManagementCLI.Configuration
{
    /// <summary>
    /// This exception is thrown if no path is given to the <see cref="PathCommand"/>.
    /// </summary>
    public class FilePathNotNullException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public FilePathNotNullException()
        {
            throw new CliFxException("Please specify a path.");
        }
    }
}
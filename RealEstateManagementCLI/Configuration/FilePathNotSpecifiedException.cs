using System;
using CliFx.Exceptions;

namespace RealEstateManagementCLI.Configuration
{
    /// <summary>
    /// This exception is thrown if the path of the XML file is not specified. 
    /// </summary>
    public class FilePathNotSpecifiedException : Exception
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public FilePathNotSpecifiedException()
        {
            throw new CliFxException("The filepath of the XML file is not specified!", true);
        }
    }
}
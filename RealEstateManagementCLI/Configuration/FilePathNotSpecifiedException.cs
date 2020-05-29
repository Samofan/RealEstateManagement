using System;

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
        public FilePathNotSpecifiedException() : base("The filepath of the XML file is not specified!")
        {
            // TODO: Test FilePathNotSpecifiedExcpetion -> does it occur at the right places?
        }
    }
}
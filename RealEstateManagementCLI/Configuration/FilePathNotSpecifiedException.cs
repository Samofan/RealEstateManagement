using System;

namespace RealEstateManagementCLI.Configuration
{
    public class FilePathNotSpecifiedException : Exception
    {
        public FilePathNotSpecifiedException() : base("The filepath of the XML file is not specified!")
        {
            
        }
    }
}
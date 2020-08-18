using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Exceptions;
using RealEstateManagementCLI.Configuration;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementCLI.Commands
{
    [Command("serialization", Description = "Specify the serialization type. (Xml is standard).")]
    public class SerializationCommand : ICommand
    {
        [CommandOption("set", 'p', Description = "Set the serialization type (Xml or Binary).")]
        public string Type { get; set; } = null;

        [CommandOption("show", 's', Description = "Show the specified serialization type.")]
        public bool ShowType { get; set; } = false;

        private IConsole _console;
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            _console = console;
            
            if (ShowType)
            {
                console.Output.WriteLine(AppConfiguration.ReadSerializationType().ToString());               
            }

            if (Type == null) return default;
            
            if (Type == SerializationType.Binary.ToString() || Type == SerializationType.Xml.ToString())
            {
                AppConfiguration.SpecifySerializationType(Enum.Parse<SerializationType>(Type));
                
                console.Output.WriteLine("Serialization type changed!");

                if (ConfirmExtensionChange(Enum.Parse<SerializationType>(Type)))
                {
                    ChangeFileExtension(Enum.Parse<SerializationType>(Type));
                }
            }
            else
            {
                throw new CliFxException("Serialization type not known! Known types are " + 
                                         SerializationType.Xml + " or " + SerializationType.Binary);
            }

            return default;
        }

        /// <summary>
        /// Asks the user if she/he wants to update the file extension of the existing file.
        /// </summary>
        /// <param name="serializationType">The new serialization type</param>
        /// <returns>True if the user wants to update the serialization type</returns>
        private bool ConfirmExtensionChange(SerializationType serializationType)
        {
            _console.Output.Write("Do you want to update the file extension of the existing to {0}? (y/n)", serializationType);

            var result = _console.Input.ReadLine();

            switch (result)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    _console.Output.WriteLine("Not possible!");
                    ConfirmExtensionChange(serializationType);
                    break;
            }
            
            // TODO: Convert data to have it still available after changing the serialization type.

            return false;
        }
        
        /// <summary>
        /// Changes the file extension of the existing file
        /// </summary>
        /// <param name="serializationType">The new serialization type</param>
        private void ChangeFileExtension(SerializationType serializationType)
        {
            var actualPath = AppConfiguration.ReadFilePath();
            var extension = System.IO.Path.GetExtension(actualPath);

            // Remove the file extension.
            var pathWithoutExtension = actualPath.Substring(0, actualPath.Length - extension.Length);

            switch (serializationType)
            {
                case SerializationType.Binary:
                    AppConfiguration.SpecifyPath(pathWithoutExtension + ".dat");
                    break;
                case SerializationType.Xml:
                    AppConfiguration.SpecifyPath(pathWithoutExtension + ".xml");
                    break;
            }
        }
    }
}
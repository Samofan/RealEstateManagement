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
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            if (ShowType)
            {
                console.Output.WriteLine(AppConfiguration.ReadSerializationType().ToString());               
            }

            if (Type == null) return default;
            
            if (Type == SerializationType.Binary.ToString() || Type == SerializationType.Xml.ToString() || 
                Type == SerializationType.Json.ToString())
            {
                AppConfiguration.SpecifySerializationType(Enum.Parse<SerializationType>(Type));
                console.Output.WriteLine("Serialization type changed. Please make sure to change the file extension!");
            }
            else
            {
                throw new CliFxException("Serialization type not known! Known types are " + 
                                         SerializationType.Xml + ", " + SerializationType.Binary + " or " + 
                                         SerializationType.Json);
            }

            return default;
        }
    }
}
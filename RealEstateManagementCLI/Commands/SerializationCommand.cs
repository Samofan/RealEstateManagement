using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
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
            if (Type == null && ShowType)
            {
                try
                {
                    console.Output.WriteLine(AppConfiguration.ReadSerializationType().ToString());
                }
                catch (FilePathNotSpecifiedException e)
                {
                    // TODO: Change exception.
                    console.Error.Write(e);
                }
            }
            else if (Type != null && ShowType)
            {
                AppConfiguration.SpecifySerializationType(Enum.Parse<SerializationType>(Type));
                console.Output.WriteLine(AppConfiguration.ReadSerializationType().ToString());
            }
            else if (Type != null)
            {
                AppConfiguration.SpecifySerializationType(Enum.Parse<SerializationType>(Type));
            }

            return default;
        }
    }
}
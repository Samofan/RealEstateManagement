using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using RealEstateManagementCLI.Configuration;

namespace RealEstateManagementCLI.Commands
{
    [Command("path", Description = "Specify the path of the XML file.")]
    public class PathCommand : ICommand
    {
        [CommandOption("set", 'p', Description = "Set the path.")]
        public string Path { get; set; } = null;

        [CommandOption("show", 's', Description = "Show the specified path.")]
        public bool ShowPath { get; set; } = false;
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            if (Path == null && !ShowPath)
            {
                console.Error.WriteLine("Please specify a path.");
            }
            else if (Path == null && ShowPath)
            {
                console.Output.WriteLine(AppConfiguration.ReadFilePath());
            }
            else if (Path != null && ShowPath)
            {
                AppConfiguration.SpecifyPath(Path);
                console.Output.WriteLine(AppConfiguration.ReadFilePath());
            }
            else
            {
                AppConfiguration.SpecifyPath(Path);
            }
            
            return default;
        }
    }
}
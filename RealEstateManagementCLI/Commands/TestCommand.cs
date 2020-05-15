using System;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;

namespace RealEstateManagementCLI.Commands
{
    [Command]
    public class TestCommand : ICommand
    {
        [CommandParameter(0, Description = "Value whose logarithm is to be found.")]
        public double Value { get; set; }

        [CommandOption("base", 'b', Description = "Logarithm base.")]
        public double Base { get; set; } = 10;

        public ValueTask ExecuteAsync(IConsole console)
        {
            var result = Math.Log(Value, Base);
            console.Output.WriteLine(result);

            return default;
        }
    }
}
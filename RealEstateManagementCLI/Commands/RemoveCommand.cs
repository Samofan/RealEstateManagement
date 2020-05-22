using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;

namespace RealEstateManagementCLI.Commands
{
    [Command("remove", Description = "Remove a real estate.")]
    public class RemoveCommand : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            throw new System.NotImplementedException();
        }
    }
}
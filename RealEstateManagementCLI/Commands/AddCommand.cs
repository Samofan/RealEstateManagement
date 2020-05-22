using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;

namespace RealEstateManagementCLI.Commands
{
    [Command("add", Description = "Add a new real estate.")]
    public class AddCommand : ICommand
    {
        public ValueTask ExecuteAsync(IConsole console)
        {
            throw new System.NotImplementedException();
        }
    }
}
using System.ComponentModel;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Exceptions;

namespace RealEstateManagementCLI.Commands
{
    [Command("list", Description = "List available real estates.")]
    public class ListCommand : ICommand
    {
        [CommandOption("alphabetical", 'a', Description = "Sort by alphabetic order.")]
        public bool SortAlphabetical { get; set; } = false;

        [CommandOption("housesOnly", 'o', Description = "Show houses only.")]
        public bool ShowHousesOnly { get; set; } = false;

        [CommandOption("apartmentsOnly", 'p', Description = "Show apartments only.")]
        public bool ShowApartmentsOnly { get; set; } = false;
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            if (ShowApartmentsOnly && ShowHousesOnly)
            {
                throw new CommandException("You have to decide!");
            }
            else
            {
            console.Output.WriteLine("Sort by alphabet: " + SortAlphabetical);
            console.Output.WriteLine("Show houses only: " + ShowHousesOnly);
            console.Output.Write("Show apartments only: " + ShowApartmentsOnly);    
            }

            

            return default;
        }
    }
}
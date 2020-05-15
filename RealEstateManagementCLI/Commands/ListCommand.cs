using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;

namespace RealEstateManagementCLI
{
    [Command("list")]
    public class ListCommand : ICommand
    {
        [CommandOption("alphabetical", 'a', Description = "Sort by alphabetic order.")]
        public bool SortAlphabetical { get; set; } = false;

        [CommandOption("housesOnly", 'o', Description = "Show houses only.")]
        public bool ShowHousesOnly { get; set; } = false;
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            console.Output.WriteLine("Sort by alphabet: " + SortAlphabetical);
            console.Output.WriteLine("Show houses only: " + ShowHousesOnly);

            return default;
        }
    }
}
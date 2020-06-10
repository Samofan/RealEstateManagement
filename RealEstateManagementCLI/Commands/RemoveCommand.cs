using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using RealEstateManagementCLI.Configuration;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementCLI.Commands
{
    [Command("remove", Description = "Remove a real estate.")]
    public class RemoveCommand : ICommand
    {
        [CommandParameter(0, Description = "Index of the real estate you want to remove. Make sure to take the " +
                                           "index from the list command without any filters.", Name = "index")]
        public int Index { get; set; }

        private IConsole _console;

        public ValueTask ExecuteAsync(IConsole console)
        {
            _console = console;

            var realEstateManagement = new RealEstateManagementImpl(AppConfiguration.ReadFilePath(), SerializationType.Xml);

            if (Confirmation(realEstateManagement.GetAll().ToList()))
            {
                realEstateManagement.Remove(Index - 1);
                _console.Output.WriteLine("Item removed.");
                realEstateManagement.Save();
            }
            else
            {
                _console.Output.WriteLine("Cancelled!");
            }
            
            return default;
        }

        /// <summary>
        /// Confirmation if the real estate should be deleted.
        /// </summary>
        /// <param name="realEstates">A list of all real estates.</param>
        /// <returns>True if the user wants to delete the real estate.</returns>
        private bool Confirmation(List<RealEstate> realEstates)
        {
            _console.Output.Write(realEstates[Index - 1] + "\nDo you really want to remove the item? (y/n): ");

            var decision = _console.Input.ReadLine();
            
            switch (decision)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    _console.Output.WriteLine("Not possible!");
                    Confirmation(realEstates);
                    break;
            }

            return false;
        }
    }
}
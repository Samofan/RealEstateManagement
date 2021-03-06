using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using RealEstateManagementCLI.Configuration;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementCLI.Commands
{
    [Command("list", Description = "List available real estates.")]
    public class ListCommand : ICommand
    {
        [CommandOption("housesOnly", 'o', Description = "Show houses only.")]
        public bool ShowHousesOnly { get; set; } = false;

        [CommandOption("apartmentsOnly", 'p', Description = "Show apartments only.")]
        public bool ShowApartmentsOnly { get; set; } = false;

        [CommandOption("sortBySize", 's', Description = "Sort by size [ascending] or [descending].")]
        public string SortBySize { get; set; } = null;
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            // Create new instance of RealEstateManagementImpl if filePath is specified in app.config.
            var realEstateManagement = new RealEstateManagementImpl(AppConfiguration.ReadFilePath(),
                AppConfiguration.ReadSerializationType());

            var realEstates = realEstateManagement.GetAll();

            // Check if the output should be sorted ascending or descending.
            if (SortBySize != null && SortBySize.Equals("ascending"))
            {
                realEstates = realEstates.OrderBy(realEstate => realEstate.Size);
            }
            else if (SortBySize != null && SortBySize.Equals("descending"))
            {
                realEstates = realEstates.OrderByDescending(realEstate => realEstate.Size);
            }

            // Check if only houses or apartments should be shown.
            if (ShowApartmentsOnly)
            {
                realEstates = realEstates.OfType<Apartment>().ToList();
                
                foreach (var apartment in realEstates)
                {
                    console.Output.WriteLine(apartment.ToString());
                }
            }
            else if (ShowHousesOnly)
            {
                realEstates = realEstates.OfType<House>().ToList();
                
                foreach (var house in realEstates)
                {
                    console.Output.WriteLine(house.ToString());
                }
            }
            else
            {
                var counter = 1;
                
                foreach (var realEstate in realEstates)
                {
                    console.Output.WriteLine(counter + ".\n" + realEstate);
                    counter++;
                }   
            }

            return default;
        }
    }
}
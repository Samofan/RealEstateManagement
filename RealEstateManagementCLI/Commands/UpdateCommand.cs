using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using RealEstateManagementCLI.Configuration;
using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementCLI.Commands
{
    [Command("update", Description = "Update an existing real estate.")]
    public class UpdateCommand : ICommand
    {
        [CommandParameter(0, Description = "Index of the real estate you want to remove. Make sure to take the " +
                                           "index from the list command without any filters.", Name = "index")]
        public int Index {get; set;}
        
        private IConsole _console;
        
        public ValueTask ExecuteAsync(IConsole console)
        {
            _console = console;

            var realEstateManagement = new RealEstateManagementImpl(AppConfiguration.ReadFilePath(), 
                AppConfiguration.ReadSerializationType());
            
            if (Confirmation(realEstateManagement.GetAll().ToList()))
            {
                realEstateManagement.Update(Index - 1, UpdateRealEstate(realEstateManagement.Get(Index - 1)));
                _console.Output.WriteLine("Item updated.");
                realEstateManagement.Save();
            }
            else
            {
                _console.Output.WriteLine("Cancelled!");
            }
            
            return default;
        }

        /// <summary>
        /// Update the values of a real estate.
        /// </summary>
        /// <param name="realEstate">The real estate to update.</param>
        /// <returns>The updated real estate.</returns>
        private RealEstate UpdateRealEstate(RealEstate realEstate)
        {
            if (realEstate.GetType() == typeof(House))
            {
                return UpdateHouse(realEstate);
            }
            else
            {
                return UpdateApartment(realEstate);
            }
        }

        /// <summary>
        /// Update the values of an <see cref="Apartment"/>.
        /// </summary>
        /// <param name="realEstate">The <see cref="Apartment"/> to update.</param>
        /// <returns>The updated <see cref="Apartment"/>.</returns>
        private Apartment UpdateApartment(RealEstate realEstate)
        {
            if (CheckAddress(realEstate.Address))
            {
                realEstate.Address = UpdateAddress(realEstate.Address);
            }
            
            _console.Output.WriteLine("Press return if you don't want to update the value.");

            var apartment = (Apartment) CheckForSaleOrRent(realEstate);
            
            _console.Output.Write("Story: " + apartment.Story + " ");

            var story = _console.Input.ReadLine();
            
            _console.Output.Write("Size: " + apartment.Size + " ");

            var size = _console.Input.ReadLine();
            
            _console.Output.Write("Amount of rooms: " + apartment.AmountOfRooms + " ");

            var amountOfRooms = _console.Input.ReadLine();

            apartment.Story = story != "" ? Convert.ToInt32(story) : apartment.Story;

            apartment.Size = size != "" ? Convert.ToInt32(size) : apartment.Size;

            apartment.AmountOfRooms = amountOfRooms != "" ? Convert.ToInt32(amountOfRooms) : apartment.AmountOfRooms;

            return apartment;
        }

        /// <summary>
        /// Updates a <see cref="House"/> object.
        /// </summary>
        /// <param name="realEstate">The <see cref="House"/> to update.</param>
        /// <returns>The updated <see cref="House"/> object.</returns>
        private RealEstate UpdateHouse(RealEstate realEstate)
        {
            if (CheckAddress(realEstate.Address))
            {
                realEstate.Address = UpdateAddress(realEstate.Address);
            }
            
            _console.Output.WriteLine("Press return if you don't want to update the value.");

            var house = (House) CheckForSaleOrRent(realEstate);
            
            _console.Output.Write("Size: " + house.Size + " ");

            var size = _console.Input.ReadLine();
            
            _console.Output.Write("Amount of rooms: " + house.AmountOfRooms + " ");

            var amountOfRooms = _console.Input.ReadLine();
            
            _console.Output.Write("Plot size: " + house.PlotSize + " ");

            var plotSize = _console.Input.ReadLine();

            house.Size = size != "" ? Convert.ToInt32(size) : house.Size;

            house.AmountOfRooms = amountOfRooms != "" ? Convert.ToInt32(amountOfRooms) : house.AmountOfRooms;

            house.PlotSize = plotSize != "" ? Convert.ToDouble(plotSize) : house.PlotSize;

            return house;
        }
        
        /// <summary>
        /// Checks whether the <see cref="RealEstate"/> is for sale or for rent. And updates it if the user wants to.
        /// </summary>
        /// <param name="realEstate">The <see cref="RealEstate"/> that should be checked.</param>
        /// <returns>A <see cref="RealEstate"/> which rental or sale status has been updated.</returns>
        private RealEstate CheckForSaleOrRent(RealEstate realEstate)
        {
            _console.Output.WriteLine(realEstate.IsForSale());
            _console.Output.Write("\nIs the apartment for sale (1) or for rent (2) ? (or return): ");

            var decision = _console.Input.ReadLine();
            
            switch (decision)
            {
                case "1":
                    realEstate.ForRent = false;
                    realEstate.ForSale = true;

                    _console.Output.Write("How much does it cost?: ");
                    realEstate.PurchasePrice = Convert.ToDouble(_console.Input.ReadLine());

                    return realEstate;
                case "2":
                    realEstate.ForRent = true;
                    realEstate.ForSale = false;
                    
                    _console.Output.Write("How much does it cost?: ");
                    realEstate.RentalPrice = Convert.ToDouble(_console.Input.ReadLine());
                    
                    return realEstate;
                case "":
                    break;
                default:
                    _console.Error.WriteLine("Not possible!");
                    CheckForSaleOrRent(realEstate);
                    break;
            }

            return realEstate;
        }

        /// <summary>
        /// Checks whether the user wants to update the <see cref="Address"/>.
        /// </summary>
        /// <param name="address">The <see cref="Address"/> to check.</param>
        /// <returns>True if the user wants to update the <see cref="Address"/>.</returns>
        private bool CheckAddress(Address address)
        {
            _console.Output.Write(address + "\nDo you want to update the address? (y/n): ");

            var decision = _console.Input.ReadLine();

            switch (decision)
            {
                case "y":
                    return true;
                case "n":
                    _console.Output.WriteLine("\nOK. Going on with the update of the real estate.");
                    return false;
                default:
                    _console.Output.WriteLine("\nNot possible!");
                    CheckAddress(address);
                    break;
            }

            return false;
        }

        /// <summary>
        /// Updates an <see cref="Address"/> object.
        /// </summary>
        /// <param name="address">The <see cref="Address"/> to update.</param>
        /// <returns>The updated <see cref="Address"/>.</returns>
        private Address UpdateAddress(Address address)
        {
            // The properties of the address object. 
            var properties = typeof(Address).GetProperties();
            var values = new string[properties.Length];
 
            _console.Output.WriteLine("Press return if you don't want to update the value.");
            _console.Output.Write("Street: " + address.Street + " ");

            values[0] = _console.Input.ReadLine();
            
            _console.Output.Write("House number: " + address.HouseNumber + " ");

            values[1] = _console.Input.ReadLine();
            
            _console.Output.Write("Zip code: " + address.ZipCode + " ");

            values[2] = _console.Input.ReadLine();
            
            _console.Output.Write("City: " + address.City + " ");

            values[3] = _console.Input.ReadLine();

            var counter = 0;

            foreach (var property in properties)
            {
                if (values[counter] != "")
                {
                    property.SetValue(address, values[counter]);
                }
                
                counter++;
            }
            
            _console.Output.WriteLine("Address updated!");

            return address;
        }

        /// <summary>
        /// Checks whether the user wants to update the <see cref="RealEstate"/>.
        /// </summary>
        /// <param name="realEstates">A list of <see cref="RealEstate"/> that holds the <see cref="RealEstate"/> which
        /// the user can update if she/he wants to.</param>
        /// <returns>True if the user wants to update the <see cref="RealEstate"/>.</returns>
        private bool Confirmation(List<RealEstate> realEstates)
        {
            _console.Output.Write(realEstates[Index - 1] + "\nDo you really want to update this item? (y/n): ");

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
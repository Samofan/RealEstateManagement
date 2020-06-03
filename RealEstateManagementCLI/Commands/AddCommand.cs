using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Exceptions;
using RealEstateManagementCLI.Configuration;
using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;

namespace RealEstateManagementCLI.Commands
{
    [Command("add", Description = "Add a new real estate.")]
    public class AddCommand : ICommand
    {
        [CommandOption("house", 'o', Description = "Add a house.")]
        public bool AddHouse { get; set; } = false;

        [CommandOption("apartment", 'a', Description = "Add an apartment.")]
        public bool AddApartment { get; set; } = false;

        /// <summary>
        /// The console to make some output and receive input.
        /// </summary>
        private IConsole _console;

        public ValueTask ExecuteAsync(IConsole console)
        {
            _console = console;
            
            if (AddHouse && AddApartment || !AddHouse && !AddApartment)
            {
                MakeDecision();
            }
            
            var realEstateManagement = new RealEstateManagementImpl(AppConfiguration.ReadFilePath());

            var realEstate = CreateRealEstate();

            realEstateManagement.Add(realEstate);

            IsRealEstateCorrect(realEstateManagement);

            return default;
        }

        /// <summary>
        /// Make a decision whether a house or an apartment should be added.
        /// </summary>
        private void MakeDecision()
        {
            _console.Output.Write("Do you want to add a house (1) or an apartment (2) ? ");
            var houseOrApartment = _console.Input.ReadLine();

            switch (houseOrApartment)
            {
                case "1":
                    AddHouse = true;
                    AddApartment = false;
                    break;
                case "2":
                    AddHouse = false;
                    AddApartment = true;
                    break;
                default:
                    _console.Error.WriteLine("Not possible!");
                    MakeDecision();
                    break;
            }
        }

        /// <summary>
        /// Have a quick look at the real estate again and decide if you want to save it.
        /// </summary>
        /// <param name="realEstateManagement">The <see cref="RealEstateManagementImpl"/> that has the list with the
        /// recently added real estate.</param>
        private void IsRealEstateCorrect(IRealEstateManagement realEstateManagement)
        {
            var list = realEstateManagement.GetAll();
            
            _console.Output.WriteLine(list.Last().ToString());
            _console.Output.Write("Is this correct? (y/n): ");

            switch (_console.Input.ReadLine())
            {
                case "y":
                    realEstateManagement.Save();
                    _console.Output.WriteLine("Changes saved!");
                    break;
                case "n":
                    realEstateManagement.Load();
                    _console.Output.WriteLine("Changes not saved!");
                    break;
                default:
                    _console.Error.WriteLine("Not possible!");
                    IsRealEstateCorrect(realEstateManagement);
                    break;
            }
        }

        /// <summary>
        /// Create the <see cref="RealEstate"/>.
        /// </summary>
        /// <returns>A <see cref="RealEstate"/> that´ll be added to the list.</returns>
        private RealEstate CreateRealEstate()
        {
            RealEstate realEstate = null;

            if (AddApartment)
            {
                realEstate = CreateApartment();
            }
            else if (AddHouse)
            {
                realEstate = CreateHouse();
            }
            else
            {
                return null;
            }

            return realEstate;
        }

        /// <summary>
        /// Create a <see cref="House"/> via console.
        /// </summary>
        /// <returns>A <see cref="House"/> object.</returns>
        private RealEstate CreateHouse()
        {
            // TODO: Create a RealEstate at first and make a house or apartment out of it.
            // TODO: Check Convert.ToX() and maybe add some try catches.
            
            var house = new House();
            
            _console.Output.Write("Is the house for rent (1) or for purchase (2)?: ");
            var rentOrPurchase = _console.Input.ReadLine();

            switch (rentOrPurchase)
            {
                case "1":
                    house.ForRent = true;

                    _console.Output.Write("Price per month: ");
                    house.RentalPrice = Convert.ToDouble(_console.Input.ReadLine());
                    break;
                case "2":
                    house.ForSale = true;
                    
                    _console.Output.Write("Price: ");
                    house.PurchasePrice = Convert.ToDouble(_console.Input.ReadLine());
                    break;
                default:
                    _console.Error.WriteLine("Not possible");
                    CreateHouse();
                    break;
            }

            house.Address = DefineAddress();
            
            _console.Output.Write("Size: ");
            house.Size = Convert.ToInt32(_console.Input.ReadLine());
            
            _console.Output.Write("Amount of rooms: ");
            house.AmountOfRooms = Convert.ToInt32(_console.Input.ReadLine());
            
            _console.Output.Write("Plot size in square meters: ");
            house.PlotSize = Convert.ToDouble(_console.Input.ReadLine());

            return house;
        }

        /// <summary>
        /// Create an <see cref="Apartment"/> via console.
        /// </summary>
        /// <returns>An <see cref="Apartment"/> object.</returns>
        private RealEstate CreateApartment()
        {
            var apartment = new Apartment();
            
            _console.Output.Write("Is the apartment for rent (1) or for purchase (2)?: ");
            var rentOrPurchase = _console.Input.ReadLine();

            switch (rentOrPurchase)
            {
                case "1":
                    apartment.ForRent = true;

                    _console.Output.Write("Price per month: ");
                    apartment.RentalPrice = Convert.ToDouble(_console.Input.ReadLine());
                    break;
                case "2":
                    apartment.ForSale = true;
                    
                    _console.Output.Write("Price: ");
                    apartment.PurchasePrice = Convert.ToDouble(_console.Input.ReadLine());
                    break;
                default:
                    _console.Error.WriteLine("Not possible");
                    CreateHouse();
                    break;
            }

            apartment.Address = DefineAddress();
            
            _console.Output.Write("Size: ");
            apartment.Size = Convert.ToInt32(_console.Input.ReadLine());
            
            _console.Output.Write("Amount of rooms: ");
            apartment.AmountOfRooms = Convert.ToInt32(_console.Input.ReadLine());

            return apartment;
        }

        /// <summary>
        /// Define the <see cref="Address"/> of the real estate via console.
        /// </summary>
        /// <returns>An address object.</returns>
        private Address DefineAddress()
        {
            var address = new Address();
            
            _console.Output.Write("Please define the address of the real estate.\nStreet: ");
            address.Street = _console.Input.ReadLine();
            
            _console.Output.Write("House number: ");
            address.HouseNumber = _console.Input.ReadLine();
            
            _console.Output.Write("Zip code: ");
            address.ZipCode = _console.Input.ReadLine();
            
            _console.Output.Write("City: ");
            address.City = _console.Input.ReadLine();

            return address;
        }
    }
}
using System;
using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;
using Xunit;

namespace RealEstateManagementUnitTest.Utils.Management
{
    public class RealEstateManagementImplTest
    {
        /// <summary>
        /// An <see cref="Address"/> to test with.
        /// </summary>
        private static readonly Address TestAddress = new Address
        {
            Street = "Sandstraße",
            HouseNumber = "112",
            City = "Siegen",
            ZipCode = "57072"
        };

        /// <summary>
        /// A <see cref="House"/> to test with.
        /// </summary>
        private static readonly House TestHouse = new House
        {
            ForSale = true,
            PurchasePrice = 250000.0,
            Address = TestAddress,
            Size = 180,
            PlotSize = 300,
            AmountOfRooms = 6
        };

        /// <summary>
        /// An <see cref="Apartment"/> to test with.
        /// </summary>
        private static readonly Apartment TestApartment = new Apartment()
        {
            ForRent = true,
            RentalPrice = 389,
            Address = TestAddress,
            Size = 45,
            Story = 3,
            AmountOfRooms = 2
        };
        
        /// <summary>
        /// <see cref="RealEstateManagementImpl"/> object for testing.
        /// </summary>
        private readonly IRealEstateManagement _realEstateManagement = new RealEstateManagementImpl("test.xml", 
            SerializationType.Xml);

        /// <summary>
        /// Test to add a <see cref="RealEstate"/>.
        /// </summary>
        [Fact]
        private void AddRealEstateToList()
        {
            // Clear the list.
            _realEstateManagement.RemoveAll();

            // Add an item.
            _realEstateManagement.Add(TestApartment);
            
            // Compare the TestApartment and the first item of the list. It should be equal.
            Assert.Equal(TestApartment, _realEstateManagement.Get(0));
        }

        /// <summary>
        /// Remove all items from the list without saving.
        /// </summary>
        [Fact]
        private void RemoveAllItems()
        {
            AddRealEstateToList();
            
            // Remove all items from the list.
            _realEstateManagement.RemoveAll();
            
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> _realEstateManagement.Get(0)
            );
        }

        /// <summary>
        /// Remove an item at an index.
        /// </summary>
        [Fact]
        private void RemoveItemAtIndex()
        {
            AddRealEstateToList();
            
            _realEstateManagement.Remove(0);
            
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> _realEstateManagement.Get(0)
            );
        }

        /// <summary>
        /// Remove an object from the list.
        /// </summary>
        [Fact]
        private void RemoveObject()
        {
            AddRealEstateToList();
            
            _realEstateManagement.Remove(TestApartment);
            
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> _realEstateManagement.Get(0)
            );
        }

        /// <summary>
        /// Update an item. 
        /// </summary>
        [Fact]
        private void UpdateItem()
        {
            _realEstateManagement.RemoveAll();
            
            var localTestHouse = new House
            {
                ForSale = true,
                PurchasePrice = 1.0,
                Address = TestAddress,
                Size = 1,
                PlotSize = 1,
                AmountOfRooms = 1
            };

            _realEstateManagement.Add(TestHouse);
            _realEstateManagement.Update(0, localTestHouse);

            Assert.NotEqual(_realEstateManagement.Get(0), TestHouse);
        }
    }
}
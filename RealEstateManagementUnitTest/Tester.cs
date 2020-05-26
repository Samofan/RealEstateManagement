using System;
using System.Collections.Generic;
using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace RealEstateManagementUnitTest
{
    public class Tester
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
            AmountOfRooms = 2
        };

        /// <summary>
        /// Test the ToString() method of <see cref="House"/>.
        /// </summary>
        [Fact]
        private void HouseToString()
        {
            const string expectedStringHouse =
                "[HOUSE]\nPlot size: 300\nFor sale: true\nPurchase price: 250000\nStreet: Sandstraße\nHouse number: 112" +
                "\nZip code: 57072\nCity: Siegen\nSize: 180\nAmount of rooms: 6\n";
            var toStringHouse = TestHouse.ToString();

            Assert.Equal(expectedStringHouse, toStringHouse);
        }

        /// <summary>
        /// Test the ToString() method of <see cref="Apartment"/>.
        /// </summary>
        [Fact]
        private void ApartmentToString()
        {
            const string expectedStringApartment =
                "[APARTMENT]\nFor rent: true\nRental price: 389\nStreet: Sandstraße\nHouse number: 112\nZip code: 57072" +
                "\nCity: Siegen\nSize: 45\nAmount of rooms: 2\n";
            var apartmentToString = TestApartment.ToString();

            Assert.Equal(expectedStringApartment, apartmentToString);
        }

        /// <summary>
        /// This fact tests all methods in <see cref="RealEstateManagementImpl"/>.
        /// </summary>
        [Fact]
        private void TestRealEstateManagement()
        {
            var realEstateManagement = new RealEstateManagementImpl(true);

            #region Add

            // Make sure that the list is empty.
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> realEstateManagement.Get(0)
            );
            
            // Add an element.
            realEstateManagement.Add(TestHouse);
            
            // Make sure that the added element equals the first element in the list.
            Assert.Equal(TestHouse, realEstateManagement.Get(0));
            
            #endregion

            #region Update

            // Create a new House object that we use to update the TestHouse that we added to the list before.
            var localTestHouse = new House
            {
                ForSale = true,
                PurchasePrice = 1.0,
                Address = TestAddress,
                Size = 1,
                PlotSize = 1,
                AmountOfRooms = 1
            };
            
            realEstateManagement.Update(0, localTestHouse);
            
            // Make sure that the first element in the list is not equal to TestHouse that was added before. 
            // (If they are not equal -> Update() method works!)
            Assert.NotEqual(realEstateManagement.Get(0), TestHouse);

            #endregion

            #region Remove(RealEstate)

            // Test the Remove(RealEstate realEstate) method. Remove the localTestHouse that was created before.
            realEstateManagement.Remove(localTestHouse);
            
            // Make sure that the list is empty.
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> realEstateManagement.Get(0)
            );

            #endregion

            #region Remove(index)

            // Add the localTestHouse again.
            realEstateManagement.Add(localTestHouse);

            realEstateManagement.Remove(0);
            
            // Make sure that the list is empty.
            Assert.Throws<ArgumentOutOfRangeException>(
                ()=> realEstateManagement.Get(0)
            );

            #endregion
        }

        /// <summary>
        /// Tests if serializing of the objects in the real estate list works.
        /// </summary>
        [Fact]
        private void TestSerializeToXml()
        {
            var realEstateManagement = new RealEstateManagementImpl(true);
            
            realEstateManagement.Add(TestApartment);
            realEstateManagement.Add(TestHouse);
            
            realEstateManagement.Save();
        }

        /// <summary>
        /// Check if the deserialization of an object from the XML file works.
        /// </summary>
        [Fact]
        private void TestDeserializeFromXml()
        {
            var realEstateManagement = new RealEstateManagementImpl(true);
            
            realEstateManagement.Add(TestHouse);
            
            realEstateManagement.Save();

            var realEstates = realEstateManagement.Load();
            
            Assert.Equal(realEstates[0].ToString(), TestHouse.ToString());
        }
    }
}
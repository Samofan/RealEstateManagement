using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using Xunit;

namespace RealEstateManagementUnitTest.Models
{
    public class HouseTest
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
    }
}
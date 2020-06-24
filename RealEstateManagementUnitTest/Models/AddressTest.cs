using RealEstateManagementLibrary.Models;
using Xunit;

namespace RealEstateManagementUnitTest.Models
{
    public class AddressTest
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
        /// Test the ToString() method of <see cref="Address"/>.
        /// </summary>
        [Fact]
        private void AddressToString()
        {
            const string expectedStringAddress = "\nStreet: Sandstraße\nHouse number: 112\nZip code: 57072\nCity: Siegen";
            var apartmentToString = TestAddress.ToString();

            Assert.Equal(expectedStringAddress, apartmentToString);
        }
    }
}
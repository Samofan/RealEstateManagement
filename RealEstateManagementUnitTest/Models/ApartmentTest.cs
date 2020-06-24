using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using Xunit;

namespace RealEstateManagementUnitTest.Models
{
    public class ApartmentTest
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
        /// Test the ToString() method of <see cref="Apartment"/>.
        /// </summary>
        [Fact]
        private void ApartmentToString()
        {
            const string expectedStringApartment =
                "[APARTMENT]\nStory: 3\nFor rent: true\nRental price: 389\nStreet: Sandstraße\nHouse number: 112\nZip code: 57072" +
                "\nCity: Siegen\nSize: 45\nAmount of rooms: 2\n";
            var apartmentToString = TestApartment.ToString();

            Assert.Equal(expectedStringApartment, apartmentToString);
        }
    }
}
using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Management;
using Xunit;

namespace RealEstateManagementUnitTest.Utils.Management
{
    public class SerializationTest
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
        private readonly IRealEstateManagement _realEstateManagementXml = new RealEstateManagementImpl("test.xml", 
            SerializationType.Xml);
        
        /// <summary>
        /// <see cref="RealEstateManagementImpl"/> object for testing.
        /// </summary>
        private readonly IRealEstateManagement _realEstateManagementBinary = new RealEstateManagementImpl("test.dat", 
            SerializationType.Binary);

        [Fact]
        private void XmlSerialization()
        {
            _realEstateManagementXml.RemoveAll();
            _realEstateManagementXml.Save();
            
            _realEstateManagementXml.Add(TestApartment);
            _realEstateManagementXml.Add(TestHouse);
            
            _realEstateManagementXml.Save();
            
            _realEstateManagementXml.RemoveAll();

            var realEstates = _realEstateManagementXml.Load();
            
            Assert.Equal(realEstates[0].ToString(), TestApartment.ToString());
            Assert.Equal(realEstates[1].ToString(), TestHouse.ToString());
        }

        [Fact]
        private void BinarySerialization()
        {
            _realEstateManagementBinary.RemoveAll();
            _realEstateManagementBinary.Save();
            
            _realEstateManagementBinary.Add(TestApartment);
            _realEstateManagementBinary.Add(TestHouse);
            
            _realEstateManagementBinary.Save();
            
            _realEstateManagementBinary.RemoveAll();

            var realEstates = _realEstateManagementBinary.Load();
            
            Assert.Equal(realEstates[0].ToString(), TestApartment.ToString());
            Assert.Equal(realEstates[1].ToString(), TestHouse.ToString());
        }
    }
}
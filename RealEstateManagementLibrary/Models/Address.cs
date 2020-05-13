using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Models
{
    /// <summary>
    /// Represents an address of a <see cref="RealEstate"/>.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// The country.
        /// </summary>
        private string _country;

        /// <summary>
        /// The state.
        /// </summary>
        private string _state;

        /// <summary>
        /// The zip code.
        /// </summary>
        private string _zipCode;

        /// <summary>
        /// The city.
        /// </summary>
        private string _city;

        /// <summary>
        /// The street.
        /// </summary>
        private string _street;

        /// <summary>
        /// The house number.
        /// </summary>
        private string _houseNumber;

        /// <summary>
        /// Properties of _country.
        /// </summary>
        public string Country
        {
            get => _country;
            set => _country = value;
        }

        /// <summary>
        /// Properties of _state.
        /// </summary>
        public string State
        {
            get => _state;
            set => _state = value;
        }

        /// <summary>
        /// Properties of _zipCode.
        /// </summary>
        public string ZipCode
        {
            get => _zipCode;
            set => _zipCode = value;
        }

        /// <summary>
        /// Properties of _city.
        /// </summary>
        public string City
        {
            get => _city;
            set => _city = value;
        }

        /// <summary>
        /// Properties of _street.
        /// </summary>
        public string Street
        {
            get => _street;
            set => _street = value;
        }

        /// <summary>
        /// Properties of _houseNumber.
        /// </summary>
        public string HouseNumber
        {
            get => _houseNumber;
            set => _houseNumber = value;
        }
        
        /// <summary>
        /// ToString method of Address.
        /// </summary>
        /// <returns>An Address human friendly.</returns>
        public override string ToString()
        {
            return "";
        }
    }
}
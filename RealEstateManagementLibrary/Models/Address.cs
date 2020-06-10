using System;
using System.Runtime.Serialization;
using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Models
{
    /// <summary>
    /// Represents an address of a <see cref="RealEstate"/>.
    /// </summary>
    [Serializable]
    public class Address : ISerializable
    {
        /// <summary>
        /// The street.
        /// </summary>
        private string _street;

        /// <summary>
        /// The house number.
        /// </summary>
        private string _houseNumber;
        
        /// <summary>
        /// The zip code.
        /// </summary>
        private string _zipCode;

        /// <summary>
        /// The city.
        /// </summary>
        private string _city;

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
        /// Empty constructor.
        /// </summary>
        public Address()
        {
            
        }

        /// <summary>
        /// ToString method of Address.
        /// </summary>
        /// <returns>An Address human friendly.</returns>
        public override string ToString()
        {
            return "\nStreet: " + _street 
                + "\nHouse number: " + _houseNumber
                + "\nZip code: " + _zipCode
                + "\nCity: " + _city;
        }

        #region Serialization

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Street", _street);
            info.AddValue("HouseNumber", _houseNumber);
            info.AddValue("ZipCode", _zipCode);
            info.AddValue("City", _city);
        }

        public Address(SerializationInfo info, StreamingContext context)
        {
            Street = info.GetString("Street");
            HouseNumber = info.GetString("HouseNumber");
            ZipCode = info.GetString("ZipCode");
            City = info.GetString("City");
        }

        #endregion
    }
}
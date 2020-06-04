using System;
using System.Xml.Serialization;

namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// This abstract class represents one real estate. 
    /// </summary>
    [XmlInclude(typeof(House))]
    [XmlInclude(typeof(Apartment))]
    [Serializable]
    public abstract class RealEstate
    {
        /// <summary>
        /// Whether the real estate is for sale.
        /// </summary>
        private bool _forSale;

        /// <summary>
        /// The price of the real estate if the real estate is for sale.
        /// </summary>
        private double _purchasePrice;

        /// <summary>
        /// Whether the real estate is for rent.
        /// </summary>
        private bool _forRent;

        /// <summary>
        /// The price of the real estate per month if it is for rental.
        /// </summary>
        private double _rentalPrice;

        /// <summary>
        /// The <see cref="Address"/> of the real estate.
        /// </summary>
        private Address _address;

        /// <summary>
        /// The size of the RealEstate in square meters.
        /// </summary>
        private int _size;

        /// <summary>
        /// The amount of rooms of the RealEstate.
        /// </summary>
        private int _amountOfRooms;

        /// <summary>
        /// Properties of _forSale.
        /// </summary>
        public bool ForSale
        {
            get => _forSale;
            set => _forSale = value;
        }

        /// <summary>
        /// Properties of _purchasePrice.
        /// </summary>
        public double PurchasePrice
        {
            get => _purchasePrice;
            set => _purchasePrice = value;
        }

        /// <summary>
        /// Properties of _forRent.
        /// </summary>
        public bool ForRent
        {
            get => _forRent;
            set => _forRent = value;
        }

        /// <summary>
        /// Properties of _rentalPrice.
        /// </summary>
        public double RentalPrice
        {
            get => _rentalPrice;
            set => _rentalPrice = value;
        }

        /// <summary>
        /// Properties of _address.
        /// </summary>
        public Address Address
        {
            get => _address;
            set => _address = value;
        }

        /// <summary>
        /// Properties of _size.
        /// </summary>
        public int Size
        {
            get => _size;
            set => _size = value;
        }

        /// <summary>
        /// Properties of _amountOfRooms.
        /// </summary>
        public int AmountOfRooms
        {
            get => _amountOfRooms;
            set => _amountOfRooms = value;
        }

        /// <summary>
        /// ToString method of RealEstate.
        /// </summary>
        /// <returns>A RealEstate human friendly.</returns>
        public override string ToString()
        {
            return IsForSale()
                   + _address
                   + "\nSize: " + _size
                   + "\nAmount of rooms: " + _amountOfRooms;
        }

        /// <summary>
        /// Checks if the RealEstate is for sale.
        /// </summary>
        /// <returns>A string whether it is for sale or for rent.</returns>
        public string IsForSale()
        {
            var returnString = "";
            
            if (_forSale)
            {
                returnString = "\nFor sale: true\nPurchase price: " + _purchasePrice;
            }
            else
            {
                returnString = "\nFor rent: true\nRental price: " + _rentalPrice;
            }

            return returnString;
        }
    }
}
namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// This abstract class represents one real estate. 
    /// </summary>
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
        /// ToString method of RealEstate.
        /// </summary>
        /// <returns>A RealEstate human friendly.</returns>
        public override string ToString()
        {
            return "";
        }
    }
}
using System.Collections.Generic;

namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// Represents an apartment complex. This is not a living unit but you can buy it anyway.
    /// </summary>
    public class ApartmentComplex : RealEstate
    {
        /// <summary>
        /// A list of apartments that are inside the apartment complex.
        /// </summary>
        private List<Apartment> _apartments;

        /// <summary>
        /// Properties of _apartments.
        /// </summary>
        public List<Apartment> Apartments
        {
            get => _apartments;
            set => _apartments = value;
        }
    }
}
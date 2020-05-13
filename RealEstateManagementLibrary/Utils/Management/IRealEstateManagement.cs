using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Utils.Management
{
    /// <summary>
    /// Interface to interact with the data.
    /// </summary>
    public interface IRealEstateManagement
    {
        /// <summary>
        /// Add a <see cref="RealEstate"/>.
        /// </summary>
        /// <param name="realEstate">The <see cref="RealEstate"/> to add.</param>
        void Add(RealEstate realEstate);

        /// <summary>
        /// Remove a <see cref="RealEstate"/>.
        /// </summary>
        /// <param name="realEstate">The <see cref="RealEstate"/> to remove.</param>
        void Remove(RealEstate realEstate);

        /// <summary>
        /// Update a <see cref="RealEstate"/>.
        /// </summary>
        /// <param name="realEstate">The <see cref="RealEstate"/> to update.</param>
        void Update(RealEstate realEstate);
    }
}
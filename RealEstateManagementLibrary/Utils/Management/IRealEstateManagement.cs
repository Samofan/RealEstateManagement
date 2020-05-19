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
        /// Remove a <see cref="RealEstate"/>.
        /// </summary>
        /// <param name="index">The index of the <see cref="RealEstate"/> to remove.</param>
        void Remove(int index);

        /// <summary>
        /// Update a <see cref="RealEstate"/>.
        /// </summary>
        /// <param name="index">The index of the element we want to update.</param>
        /// <param name="realEstate">The <see cref="RealEstate"/> to update.</param>
        void Update(int index, RealEstate realEstate);

        /// <summary>
        /// Get a <see cref="RealEstate"/> from the list by its index.
        /// </summary>
        /// <param name="index">The index of the <see cref="RealEstate"/>.</param>
        /// <returns>A <see cref="RealEstate"/> from the list.</returns>
        RealEstate Get(int index);
    }
}
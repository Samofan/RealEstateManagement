using System.Collections.Generic;
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
        /// Remove all real estates from the list.
        /// </summary>
        void RemoveAll();

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

        /// <summary>
        /// Get all list items.
        /// </summary>
        /// <returns>All <see cref="RealEstate"/> items in the list.</returns>
        IEnumerable<RealEstate> GetAll();

        /// <summary>
        /// Saves the current real estate list to an XML file.
        /// </summary>
        void Save();

        /// <summary>
        /// Loads the serialized objects from the XML file.
        /// </summary>
        /// <returns>A list of all RealEstate objects that are saved in the XML file.</returns>
        List<RealEstate> Load();
    }
}
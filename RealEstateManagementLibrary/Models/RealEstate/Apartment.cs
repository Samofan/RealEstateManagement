namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// Represents an apartment.
    /// </summary>
    public class Apartment : RealEstate
    {
        /// <summary>
        /// ToString method of Apartment.
        /// </summary>
        /// <returns>An apartment human friendly.</returns>
        public override string ToString()
        {
            return "[APARTMENT]" + base.ToString() + "\n";
        }
    }
}
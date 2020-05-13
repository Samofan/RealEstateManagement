namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// Represents a living unit.
    /// </summary>
    public abstract class LivingUnit : RealEstate
    {
        /// <summary>
        /// The amount of rooms of a living unit.
        /// </summary>
        private int _amountOfRooms;

        /// <summary>
        /// Properties of _amountOfRooms.
        /// </summary>
        public int AmountOfRooms
        {
            get => _amountOfRooms;
            set => _amountOfRooms = value;
        }
        
        /// <summary>
        /// ToString method of a living unit.
        /// </summary>
        /// <returns>A LivingUnit human friendly.</returns>
        public override string ToString()
        {
            return "";
        }
    }
}
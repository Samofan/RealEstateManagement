namespace RealEstateManagementLibrary
{
    /// <summary>
    /// Represents a house that comes with a plot around the house.
    /// </summary>
    public class House : LivingUnit
    {
        /// <summary>
        /// The size of the plot in square meters.
        /// </summary>
        private double _plotSize;

        /// <summary>
        /// Properties of _plotSize.
        /// </summary>
        public double PlotSize
        {
            get => _plotSize;
            set => _plotSize = value;
        }

        /// <summary>
        /// ToString method of a house.
        /// </summary>
        /// <returns>A house human friendly.</returns>
        public override string ToString()
        {
            return "";
        }
    }
}
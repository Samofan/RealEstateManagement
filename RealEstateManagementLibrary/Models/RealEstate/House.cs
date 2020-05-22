using System;
using System.Runtime.Serialization;

namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// Represents a house that comes with a plot around the house.
    /// </summary>
    [Serializable]
    public class House : RealEstate, ISerializable
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
        /// Empty Constructor.
        /// </summary>
        public House()
        {
            
        }

        /// <summary>
        /// ToString method of a house.
        /// </summary>
        /// <returns>A house human friendly.</returns>
        public override string ToString()
        {
            return "[HOUSE]\nPlot size: " + PlotSize + base.ToString() + "\n";
        }

        #region Serialization
        
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ForSale", ForSale);
            info.AddValue("PurchasePrice", PurchasePrice);
            info.AddValue("ForRent", ForRent);
            info.AddValue("RentalPrice", RentalPrice);
            info.AddValue("Address", Address);
            info.AddValue("Size", Size);
            info.AddValue("AmountOfRooms", AmountOfRooms);
            info.AddValue("PlotSize", PlotSize);
        }

        public House(SerializationInfo info, StreamingContext context)
        {
            ForSale = info.GetBoolean("ForSale");
            PurchasePrice = info.GetDouble("PurchasePrice");
            ForRent = info.GetBoolean("ForRent");
            RentalPrice = info.GetDouble("RentalPrice");
            Address = (Address)info.GetValue("Address", typeof(Address));
            Size = info.GetInt32("Size");
            AmountOfRooms = info.GetInt32("AmountOfRooms");
            PlotSize = info.GetInt32("PlotSize");
        }

        #endregion
    }
}
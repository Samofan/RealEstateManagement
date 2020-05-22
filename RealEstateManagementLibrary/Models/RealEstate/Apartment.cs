using System;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace RealEstateManagementLibrary.Models.RealEstate
{
    /// <summary>
    /// Represents an apartment.
    /// </summary>
    [Serializable]
    public class Apartment : RealEstate, ISerializable
    {
        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Apartment()
        {
            
        }
        
        /// <summary>
        /// ToString method of Apartment.
        /// </summary>
        /// <returns>An apartment human friendly.</returns>
        public override string ToString()
        {
            return "[APARTMENT]" + base.ToString() + "\n";
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
        }

        public Apartment(SerializationInfo info, StreamingContext context)
        {
            ForSale = info.GetBoolean("ForSale");
            PurchasePrice = info.GetDouble("PurchasePrice");
            ForRent = info.GetBoolean("ForRent");
            RentalPrice = info.GetDouble("RentalPrice");
            Address = (Address)info.GetValue("Address", typeof(Address));
            Size = info.GetInt32("Size");
            AmountOfRooms = info.GetInt32("AmountOfRooms");
        }

        #endregion
    }
}
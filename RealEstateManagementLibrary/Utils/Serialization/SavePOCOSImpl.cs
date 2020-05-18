using RealEstateManagementLibrary.Models;
using RealEstateManagementLibrary.Models.RealEstate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace RealEstateManagementLibrary.Utils.Serialization
{
    class SavePOCOSImpl : ISavePOCOS
    {
        string filePath;

        public SavePOCOSImpl(string filePath)
        {
            this.filePath = filePath;
        }

        public void SaveAsJson()
        {
            RealEstate realEstate = new House
            {
                ForSale = true,
                PurchasePrice = 100000,
                Address = new Address
                {
                    Country = "Germany",
                    City = "Siegen",
                    State = "NRW",
                    ZipCode = "57072",
                    Street = "Frankfurter Straße",
                    HouseNumber = "32"
                },
                AmountOfRooms = 5,
                PlotSize = 250
            };

            string jsonString;
            jsonString = JsonSerializer.Serialize(realEstate);

            File.WriteAllText(filePath + "/RealEstate.json", jsonString);
        }

        public void SaveAsXml()
        {
            throw new NotImplementedException();
        }

        public void SaveInDatabase()
        {
            throw new NotImplementedException();
        }
    }
}

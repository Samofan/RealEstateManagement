using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Utils.Serialization
{
    public class SaveService
    {
        private string _filePath;
        
        public SaveService(string filePath)
        {
            _filePath = filePath;
        }

        public void SaveToJson(List<RealEstate> realEstates)
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(realEstates));
        }

        public void SaveToDb(List<RealEstate> realEstates)
        {
            throw new System.NotImplementedException();
        }
    }
}
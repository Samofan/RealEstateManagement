using System.Collections.Generic;
using System.Text.Json;
using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Utils.Serialization
{
    public class LoadService
    {
        private string _filePath;

        public LoadService(string filePath)
        {
            _filePath = filePath;
        }

        public List<RealEstate> LoadFromFile()
        {
            return JsonSerializer.Deserialize<List<RealEstate>>(_filePath);
        }
    }
}
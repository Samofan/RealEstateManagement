using System.Collections.Generic;
using System.Xml.Linq;
using RealEstateManagementLibrary.Models.RealEstate;
using RealEstateManagementLibrary.Utils.Serialization;

namespace RealEstateManagementLibrary.Utils.Management
{
    /// <summary>
    /// Class to interact with the data. Implementation of <see cref="IRealEstateManagement"/>.
    /// </summary>
    public class RealEstateManagementImpl : IRealEstateManagement
    {
        private List<RealEstate> _realEstates;
        private SaveService _saveService;
        private LoadService _loadService;

        public RealEstateManagementImpl()
        {
            _saveService = new SaveService("");
            _loadService = new LoadService("");

            _realEstates = _loadService.LoadFromFile();
        }
        
        public void Add(RealEstate realEstate)
        {
            _realEstates.Add(realEstate);
        }
        
        public void Remove(RealEstate realEstate)
        {
            _realEstates.Remove(realEstate);
        }
        
        public void Remove(int index)
        {
            _realEstates.RemoveAt(index);
        }

        public void Update(int index, RealEstate realEstate)
        {
            _realEstates[index] = realEstate;
        }

        public RealEstate Get(int index)
        {
            return _realEstates[index];
        }
    }
}
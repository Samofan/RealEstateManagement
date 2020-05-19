using System.Collections.Generic;
using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Utils.Management
{
    /// <summary>
    /// Class to interact with the data. Implementation of <see cref="IRealEstateManagement"/>.
    /// </summary>
    public class RealEstateManagementImpl : IRealEstateManagement
    {
        private List<RealEstate> _realEstates = new List<RealEstate>();
        
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
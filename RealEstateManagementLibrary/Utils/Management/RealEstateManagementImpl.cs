using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using RealEstateManagementLibrary.Models.RealEstate;

namespace RealEstateManagementLibrary.Utils.Management
{
    /// <summary>
    /// Class to interact with the data. Implementation of <see cref="IRealEstateManagement"/>.
    /// </summary>
    public class RealEstateManagementImpl : IRealEstateManagement
    {
        private List<RealEstate> _realEstates;

        /// <summary>
        /// Default constructor that loads all objects from the specified XML file into
        /// the _realEstates list.
        /// </summary>
        public RealEstateManagementImpl()
        {
            _realEstates = Load();
        }

        /// <summary>
        /// Constructor that is used for testing the methods in this class. An empty _realEstates list
        /// is needed for that. The behaviour of the default constructor is used if the testing flag is false.
        /// </summary>
        /// <param name="testing">Defines whether the unit test should run.</param>
        public RealEstateManagementImpl(bool testing)
        {
            if (testing)
            {
                _realEstates = new List<RealEstate>();
            }
            else
            {
                _realEstates = Load();
            }
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
        
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(List<RealEstate>));
            
            TextWriter textWriter = new StreamWriter("RealEstate.xml");
            
            serializer.Serialize(textWriter, _realEstates);
        }

        public List<RealEstate> Load()
        {
            var deserializer = new XmlSerializer(typeof(List<RealEstate>));
            
            TextReader textReader = new StreamReader("RealEstate.xml");

            return (List<RealEstate>) deserializer.Deserialize(textReader);
        }
    }
}
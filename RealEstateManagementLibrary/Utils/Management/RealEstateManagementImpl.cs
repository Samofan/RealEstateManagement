using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
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
        /// <summary>
        /// The list that saves the real estates.
        /// </summary>
        private readonly List<RealEstate> _realEstates;
        
        /// <summary>
        /// The filepath of the XML file.
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        /// Default constructor that loads all objects from the specified XML file into
        /// the _realEstates list.
        /// </summary>
        public RealEstateManagementImpl(string filePath)
        {
            _filePath = filePath;
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
                _filePath = "Test.xml";
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

        public IEnumerable<RealEstate> GetAll()
        {
            return _realEstates;
        }

        public void Save()
        {
            var serializer = new XmlSerializer(typeof(List<RealEstate>));
            
            TextWriter textWriter = new StreamWriter(_filePath);

            serializer.Serialize(textWriter, _realEstates);
            
            textWriter.Close();
            
        }

        public List<RealEstate> Load()
        {
            var deserializer = new XmlSerializer(typeof(List<RealEstate>));

            // Create a new empty XML file if it not exists. ArrayOfRealEstate is the root element.
            if (!File.Exists(_filePath))
            {
                var xDocument = new XDocument( new XElement("ArrayOfRealEstate"));
                xDocument.Save(_filePath);
            }
            
            TextReader textReader = new StreamReader(_filePath);
            
            var realEstates = (List<RealEstate>) deserializer.Deserialize(textReader);
            
            textReader.Close();

            return realEstates;
        }
    }
}
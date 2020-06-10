using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

        private readonly SerializationType _serializationType;

        /// <summary>
        /// Default constructor that loads all objects from the specified XML file into
        /// the _realEstates list.
        /// </summary>
        public RealEstateManagementImpl(string filePath, SerializationType serializationType)
        {
            _filePath = filePath;
            _serializationType = serializationType;
            _realEstates = Load();
        }

        /// <summary>
        /// Constructor that is used for testing the methods in this class. An empty _realEstates list
        /// is needed for that. The behaviour of the default constructor is used if the testing flag is false.
        /// </summary>
        /// <param name="testing">Defines whether the unit test should run.</param>
        /// <param name="filePath"></param>
        /// <param name="serializationType"></param>
        public RealEstateManagementImpl(bool testing, string filePath, SerializationType serializationType)
        {
            _serializationType = serializationType;
            
            if (testing)
            {
                _realEstates = new List<RealEstate>();
                _filePath = filePath;
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
            switch (_serializationType)
            {
                case SerializationType.Xml:
                    SaveXml();
                    break;
                case SerializationType.Binary:
                    SaveBinary();
                    break;
            }
        }

        public List<RealEstate> Load()
        {
            switch (_serializationType)
            {
                case SerializationType.Xml:
                    return LoadXml();
                case SerializationType.Binary:
                    return LoadBinary();
                default:
                    return new List<RealEstate>();
            }
        }

        private void SaveXml()
        {
            var serializer = new XmlSerializer(typeof(List<RealEstate>));
            
            TextWriter textWriter = new StreamWriter(_filePath);

            serializer.Serialize(textWriter, _realEstates);
            
            textWriter.Close();
        }

        private void SaveBinary()
        { 
            var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
            
            var binaryFormatter = new BinaryFormatter();
            
            binaryFormatter.Serialize(fileStream, _realEstates);
            
            fileStream.Close();
        }

        private List<RealEstate> LoadXml()
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

        private List<RealEstate> LoadBinary()
        {
            var fileStream = new FileStream(_filePath, FileMode.Open);
            
            var binaryFormatter = new BinaryFormatter();

            var realEstates = (List<RealEstate>) binaryFormatter.Deserialize(fileStream);
            
            fileStream.Close();

            return realEstates;
        }
    }
}
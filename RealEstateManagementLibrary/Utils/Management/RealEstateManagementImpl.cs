using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
        /// <param name="filePath">The filepath of the file that stores the real estates.</param>
        /// <param name="serializationType">The <see cref="SerializationType"/>.</param>
        public RealEstateManagementImpl(string filePath, SerializationType serializationType)
        {
            _filePath = filePath;
            _serializationType = serializationType;
            _realEstates = Load();
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

        public void RemoveAll()
        {
            _realEstates.Clear();
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

        /// <summary>
        /// Save the real estate list in a xml file.
        /// </summary>
        private void SaveXml()
        {
            var serializer = new XmlSerializer(typeof(List<RealEstate>));
            
            TextWriter textWriter = new StreamWriter(_filePath);

            serializer.Serialize(textWriter, _realEstates);
            
            textWriter.Close();
        }

        /// <summary>
        /// Save the real estate list in a xml file.
        /// </summary>
        private void SaveBinary()
        { 
            var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
            
            var binaryFormatter = new BinaryFormatter();
            
            binaryFormatter.Serialize(fileStream, _realEstates);
            
            fileStream.Close();
        }

        /// <summary>
        /// Load the content of a xml file and create the real estate list. 
        /// </summary>
        /// <returns>A list of real estates.</returns>
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

            List<RealEstate> realEstates;
            
            // TODO: Improve file creation and adding a root element.
            
            try
            {
                realEstates = (List<RealEstate>) deserializer.Deserialize(textReader);
            }
            catch (InvalidOperationException)
            {
                var xDocument = new XDocument( new XElement("ArrayOfRealEstate"));
                xDocument.Save(_filePath);
                
                realEstates = (List<RealEstate>) deserializer.Deserialize(textReader);
            }
            
            textReader.Close();

            return realEstates;
        }

        /// <summary>
        /// Load the content of a binary file and create the real estate list.
        /// </summary>
        /// <returns>A list of real estates.</returns>
        private List<RealEstate> LoadBinary()
        {
            var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
            List<RealEstate> realEstates;
            
            if (fileStream.Length != 0)
            {
                var binaryFormatter = new BinaryFormatter();
                realEstates = (List<RealEstate>) binaryFormatter.Deserialize(fileStream);
            }
            else
            {
                realEstates = new List<RealEstate>();
            }

            fileStream.Close();

            return realEstates;
        }
    }
}
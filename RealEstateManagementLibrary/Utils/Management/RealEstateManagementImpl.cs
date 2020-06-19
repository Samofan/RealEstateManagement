using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using RealEstateManagementLibrary.Models;
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

        /// <summary>
        /// Constructor that is used for testing the methods in this class. An empty _realEstates list
        /// is needed for that. The behaviour of the default constructor is used if the testing flag is false.
        /// </summary>
        /// <param name="testing">Defines whether the unit test should run.</param>
        /// <param name="filePath">The filepath of the file that stores the real estates.</param>
        /// <param name="serializationType">The <see cref="SerializationType"/>.</param>
        public RealEstateManagementImpl(bool testing, string filePath, SerializationType serializationType)
        {
            _serializationType = serializationType;
            _filePath = filePath;
            
            _realEstates = testing ? new List<RealEstate>() : Load();
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
                case SerializationType.Json:
                    SaveJson();
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
                case SerializationType.Json:
                    return LoadJson();
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

        private void SaveJson()
        {
            var jsonSerializer = new JsonSerializer();

            var streamWriter = File.AppendText(_filePath);
            
            jsonSerializer.Serialize(streamWriter, _realEstates);
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
            
            var realEstates = (List<RealEstate>) deserializer.Deserialize(textReader);
            
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

        private List<RealEstate> LoadJson()
        {
            Address TestAddress = new Address
            {
                Street = "Sandstraße",
                HouseNumber = "112",
                City = "Siegen",
                ZipCode = "57072"
            };
            
            House TestHouse = new House
            {
                ForSale = true,
                PurchasePrice = 250000.0,
                Address = TestAddress,
                Size = 180,
                PlotSize = 300,
                AmountOfRooms = 6
            };
            
            
            _realEstates.Add(TestHouse);
            
            SaveJson();

            return null;

            /*StreamReader streamReader;

            try
            {
                streamReader = File.OpenText(_filePath);
            }
            catch (FileNotFoundException)
            {
                File.Create(_filePath);
                streamReader = File.OpenText(_filePath);
            }

            TextReader textReader = streamReader;

            var realEstates = JsonConvert.DeserializeObject<List<RealEstate>>(textReader.ReadToEnd());

            streamReader.Close();

            return realEstates;*/
        }
    }
}
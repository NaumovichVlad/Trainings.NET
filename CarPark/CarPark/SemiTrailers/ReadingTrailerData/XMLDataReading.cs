using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace CarPark.SemiTrailers.ReadingTrailerData
{
    public class XMLDataReading
    {
        private string fileXMLPath;
        private List<SemiTrailer> semiTrailers = new List<SemiTrailer>();
        public int Amount { get { return semiTrailers.Count; } }
        public SemiTrailer this[int index]
        {
            get
            {
                return semiTrailers[index];
            }
            set
            {
                semiTrailers[index] = value;
            }
        }
        public void ReadXML(string XMLFilePath, string XSDFilePath)
        {
            semiTrailers = new List<SemiTrailer>();
            fileXMLPath = XMLFilePath;
            string fileXMLSchemaPath = XSDFilePath;

            XmlReaderSettings settings = new XmlReaderSettings();

            settings.Schemas.Add(null, XSDFilePath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(XmlSettingsValidationEventHandler);
            using (XmlReader xr = XmlReader.Create(fileXMLPath, settings))
            {
                string type = "";
                int liftingCapacity = 0;
                int availableVolume = 0;
                int availableMass = 0;
                string uploadedProductType = "";
                int occupiedVolume = 0;
                int occupiedWeight = 0;

                string element = "";

                while (xr.Read())
                {
                    if (xr.NodeType == XmlNodeType.Element)
                    {
                        element = xr.Name;
                    }
                    else if (xr.NodeType == XmlNodeType.Text)
                    {
                        switch (element)
                        {
                            case "Type":
                                type = xr.Value;
                                break;
                            case "LiftingCapacity":
                                liftingCapacity = int.Parse(xr.Value);
                                break;
                            case "AvailableVolume":
                                availableVolume = int.Parse(xr.Value);
                                break;
                            case "AvailableMass":
                                availableMass = int.Parse(xr.Value);
                                break;
                            case "UploadedProductType":
                                uploadedProductType = xr.Value;
                                break;
                            case "OccupiedVolume":
                                occupiedVolume = int.Parse(xr.Value);
                                break;
                            case "OccupiedWeight":
                                occupiedWeight = int.Parse(xr.Value);
                                break;

                        }
                    }
                    else if ((xr.NodeType == XmlNodeType.EndElement) && (xr.Name == "SemiTrailer"))
                    {
                        SemiTrailerCreator trailerCreator = new SemiTrailerCreator();
                        semiTrailers.Add(trailerCreator.CreateST(type, liftingCapacity, availableVolume, availableMass, uploadedProductType, occupiedVolume, occupiedWeight));
                    }
                }
            }
        }

        static void XmlSettingsValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                throw new Exception("WARNING: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                throw new Exception("WARNING: " + e.Message);
            }
        }
    }
}


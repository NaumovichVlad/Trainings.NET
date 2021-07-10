using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.FileProcessor
{
    abstract public class Connection
    {
        private string connectionString = "../../../Data/";

        protected string GetCargoTypesConnection()
        {
            return connectionString + "cargoTypes.xml";
        }
        protected string GetCargoTypesSchemaConnection()
        {
            return connectionString + "cargoTypesSchema.xsd";
        }
    }
}

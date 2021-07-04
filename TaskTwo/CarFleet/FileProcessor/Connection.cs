using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.FileProcessor
{
    public class Connection
    {
        private string connectionString = "../../../Data/";

        protected string GetCargoTypesConnection()
        {
            return connectionString + "cargoTypes.xml";
        }
    }
}

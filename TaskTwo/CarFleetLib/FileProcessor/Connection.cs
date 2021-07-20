using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.FileProcessor
{
    abstract public class Connection
    {
        private string connectionString = "../../../Data/";

        protected string GetCargoCategoriesConnection()
        {
            return connectionString + "cargoCategories.xml";
        }
        protected string GetCargoCategoriesSchemaConnection()
        {
            return connectionString + "cargoCategoriesSchema.xsd";
        }
        protected string GetCargosConnection()
        {
            return connectionString + "cargos.xml";
        }
        protected string GetCargosSchemaConnection()
        {
            return connectionString + "cargosSchema.xsd";
        }
        protected string GetTrailerCategoriesConnection()
        {
            return connectionString + "trailerCategories.xml";
        }
        protected string GetTrailerCategoriesSchemaConnection()
        {
            return connectionString + "trailerCategoriesSchema.xsd";
        }
    }
}

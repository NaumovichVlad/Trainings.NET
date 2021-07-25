using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.FileProcessor
{
    /// <summary>
    /// Getting access to files
    /// </summary>
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
        protected string GetTrailersConnection()
        {
            return connectionString + "trailers.xml";
        }
        protected string GetTrailersSchemaConnection()
        {
            return connectionString + "trailersSchema.xsd";
        }
        protected string GetInvoicesConnection()
        {
            return connectionString + "invoices.xml";
        }
        protected string GetInvoicesSchemaConnection()
        {
            return connectionString + "invoicesSchema.xsd";
        }
        protected string GetTrucksConnection()
        {
            return connectionString + "trucks.xml";
        }
        protected string GetTrucksSchemaConnection()
        {
            return connectionString + "trucksSchema.xsd";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Products
{
    /// <summary>
    /// the class that describes the Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// type of product
        /// </summary>
        public string Type;
        /// <summary>
        /// product volume
        /// </summary>
        public int Volume;
        /// <summary>
        /// product weight
        /// </summary>
        public int Weight;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> type of product </param>
        /// <param name="volume"> product volume </param>
        /// <param name="weight"> product weight </param>
        public Product(string type, int volume, int weight)
        {
            Type = type;
            Volume = volume;
            Weight = weight;
        }
    }
}

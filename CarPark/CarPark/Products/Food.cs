using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Products
{
    /// <summary>
    /// the class that describes the food product
    /// </summary>
    public class Food : Product
    {
        /// <summary>
        /// permissible storage temperature of the product
        /// </summary>
        public int[] StorageTemperature;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> type of product </param>
        /// <param name="volume"> product volume </param>
        /// <param name="weight"> product weight </param>
        /// <param name="storageTemperature"> permissible storage temperature of the product </param>
        public Food(string type, int volume, int weight, int[] storageTemperature) : base(type, volume, weight)
        {
            Type = type;
            Volume = volume;
            Weight = weight;
            StorageTemperature = storageTemperature;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Products
{
    /// <summary>
    /// class that describes petroleum products
    /// </summary>
    public class PetroleumProducts : Product
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"> type of product </param>
        /// <param name="volume"> product volume </param>
        /// <param name="weight"> product weight </param>
        public PetroleumProducts(string type, int volume, int weight) : base (type, volume, weight)
        {
            Type = type;
            Volume = volume;
            Weight = weight;
        }
    }
}

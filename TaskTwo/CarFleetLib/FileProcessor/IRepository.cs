using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.FileProcessor
{
    /// <summary>
    /// Interface for changing the way you work with files
    /// </summary>
    /// <typeparam name="T">View of the object being read</typeparam>
    public interface IRepository<T>
         where T : class
    {
        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="t">Objects to save</param>
        void Save(List<T> t);
        /// <summary>
        /// Load data
        /// </summary>
        /// <returns>Loaded objects</returns>
        List<T> Load();
    }
}

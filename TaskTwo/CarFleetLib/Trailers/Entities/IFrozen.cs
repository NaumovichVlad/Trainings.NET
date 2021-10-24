using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Trailers.Entities
{
    public interface IFrozen
    {
        double Temperature { get; set; }
    }
}

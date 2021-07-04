using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos
{
    public interface ICargoType
    {
        int TypeId { get; set; }
        string TypeName { get; set; }
    }
}

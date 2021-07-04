using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleet.Cargos
{
    public class CargoType : ICargoType
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public CargoType (int typeId, string typeName)
        {
            TypeId = typeId;
            TypeName = typeName;
        }

    }
}

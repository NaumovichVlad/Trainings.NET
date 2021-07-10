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
        public override bool Equals(object obj)
        {
            return Equals(obj as CargoType);
        }

        public bool Equals(CargoType cargoType)
        {
            var flag = false;
            if (cargoType != null)
            {
                if (TypeId == cargoType.TypeId && TypeName == cargoType.TypeName)
                {
                    flag = true;
                }
            }
            return flag;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeId, TypeName);
        }

    }
}

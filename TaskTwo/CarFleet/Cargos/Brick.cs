using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos
{
    public class Brick : Materials
    {
        public Brick (double weight, double volume)
            : base (weight, volume)
        { }

        public override string GetCargoType()
        {
            return "brick";
        }
    }
}

using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public class ChemistryCargoContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IGasCreator>().To<GasCreator>();
            Bind<IPetrolCreator>().To<PetrolCreator>();
            Bind<IDieselCreator>().To<DieselCreator>();
        }
    }
}

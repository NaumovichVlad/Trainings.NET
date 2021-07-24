using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFleetLib.Cargos.Factories
{
    public class MaterialsCargoContainer : NinjectModule
    {
        public override void Load()
        {
            Bind<IBrickCreator>().To<BrickCreator>();
            Bind<IGlassCreator>().To<GlassCreator>();
            Bind<IBoardCreator>().To<BoardCreator>();
        }
    }
}

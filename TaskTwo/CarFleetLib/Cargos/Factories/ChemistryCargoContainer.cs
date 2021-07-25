using Ninject.Modules;

namespace CarFleetLib.Cargos.Factories
{
    /// <summary>
    /// IoC container for chemistry
    /// </summary>
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

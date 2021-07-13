namespace CarFleet.Cargos.Entities
{

    public class Brick : Materials
    {
        public Brick(int cargoId, double weight, double volume, bool isLiquid)
            : base(cargoId, weight, volume, isLiquid)
        { }

        public override ConcreteCargo GetCargoType()
        {
            return ConcreteCargo.Brick;
        }
    }
}

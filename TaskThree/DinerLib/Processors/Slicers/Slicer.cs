using DinerLib.Ingredients;
using DinerLib.Processors.ProcessQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.Slicers
{
    internal class Slicer : IConcreteIngredientProcessor<ISlicedIngredient>
    {
        private readonly SlicingTypes _slicingType;
        private const int _productionCapacity = 5;
        private const double _processTimeInMinutes = 0.5;
        public int ProductionCapacity => _productionCapacity;
        public double ProcessTime => _processTimeInMinutes;
        public Slicer(SlicingTypes slicingType)
        {
            _slicingType = slicingType;
        }

        public ISlicedIngredient ProcessIngredient(IngredientTypes ingredientType)
        {
            IConcreteSlicer slicer = null;
            var queue = new ProcessQueue(ProcessingTypes.Slicing, _productionCapacity, _processTimeInMinutes);
            switch (_slicingType)
            {
                case SlicingTypes.Cubes:
                    slicer = new CubesSlicer();
                    break;
                case SlicingTypes.Stripes:
                    slicer = new StripesSlicer();
                    break;
            }
            return slicer.ProcessIngredient(ingredientType, queue.AddIngredient());
        }
    }
}

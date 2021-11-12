using DinerLib.Ingredients;
using DinerLib.Processors.Slicers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    internal class IngredientProcessor : IIngredientProcessor
    {

        public IIngredient ProcessIngredient(string ingredientType, string processingType, string concreteProcessingType)
        {
            IConcreteIngredientProcessor<IIngredient> ingredientProcessor = null;
            Enum.TryParse(processingType, out ProcessingTypes processingTypeEnum);
            Enum.TryParse(ingredientType, out IngredientTypes ingredientTypeEnum);
            switch (processingTypeEnum) 
            {
                case ProcessingTypes.Slicing:
                    Enum.TryParse(concreteProcessingType, out SlicingTypes slicerType);
                    ingredientProcessor = new Slicer(slicerType);
                    break;
            }
            return ingredientProcessor.ProcessIngredient(ingredientTypeEnum);
        }
    }
}

using DinerLib.Ingredients;
using DinerLib.Processors.Slicers;
using DinerLib.Reports;
using System;

namespace DinerLib.Processors
{
    internal class IngredientProcessor : IIngredientProcessor
    {
        /// <summary>
        /// Process ingredient
        /// </summary>
        /// <param name="ingredientType">ingredientType</param>
        /// <param name="processingType">process type</param>
        /// <param name="concreteProcessingType">concrete process type</param>
        /// <returns></returns>
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
            IIngredient ingredient = ingredientProcessor.ProcessIngredient(ingredientTypeEnum);
            var logger = new IngredientLogger();
            logger.AddNote(ingredient as Ingredient);
            return ingredient;
        }
    }
}

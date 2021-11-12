using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Recipes
{
    public class IngredientForRecipe
    {
        public IngredientTypes IngredientType { get; set; }
        public ProcessingTypes ProcessingType { get; set; }
        public string ConcreteProcessingType { get; set; }

        public IngredientForRecipe (IngredientTypes ingredientType, ProcessingTypes processingType, string concreteProcType)
        {
            IngredientType = ingredientType;
            ProcessingType = processingType;
            ConcreteProcessingType = concreteProcType;
        }
    }
}

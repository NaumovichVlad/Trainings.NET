using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Recipes
{
    public struct IngredientForRecipe
    {
        public IngredientTypes IngredientType {  get; set; }
        public ProcessingTypes ProcessingType { get; set; }
        public int Count { get; set; }

        public IngredientForRecipe(IngredientTypes ingredientType, ProcessingTypes processingType, int count)
        {
            IngredientType = ingredientType;
            ProcessingType = processingType;
            Count = count;
        }
    }
}

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

        public override bool Equals(object obj)
        {
            return obj is IngredientForRecipe recipe &&
                   IngredientType == recipe.IngredientType &&
                   ProcessingType == recipe.ProcessingType &&
                   ConcreteProcessingType == recipe.ConcreteProcessingType;
        }

        public override int GetHashCode()
        {
            int hashCode = 1914823169;
            hashCode = hashCode * -1521134295 + IngredientType.GetHashCode();
            hashCode = hashCode * -1521134295 + ProcessingType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ConcreteProcessingType);
            return hashCode;
        }
    }
}

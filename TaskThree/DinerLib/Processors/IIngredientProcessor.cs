using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    internal interface IIngredientProcessor
    {
        IIngredient ProcessIngredient(string ingredientType, string processingType, string concreteProcessingType);
    }
}

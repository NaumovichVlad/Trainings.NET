using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors
{
    internal interface IConcreteIngredientProcessor<out T> 
         where T : IIngredient
    {
        int ProductionCapacity { get; }
        double ProcessTime { get; }
        T ProcessIngredient(IngredientTypes ingredientType);
    }
}

using DinerLib.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.Slicers
{
    internal interface IConcreteSlicer
    {
        ISlicedIngredient ProcessIngredient(IngredientTypes ingredientType);
    }
}

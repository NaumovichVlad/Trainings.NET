using DinerLib.Ingredients;
using DinerLib.Ingredients.Carrot;
using DinerLib.Ingredients.Onions;
using DinerLib.Ingredients.Tomato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Processors.Slicers
{
    internal class CubesSlicer : IConcreteSlicer
    {
        public ISlicedIngredient ProcessIngredient(IngredientTypes ingredientType, DateTime createTime)
        {
            ISlicedIngredient ingredient = null;
            switch (ingredientType)
            {
                case IngredientTypes.Onion:
                    ingredient = new CubesSlicedOnion(10, createTime);
                    break;
                case IngredientTypes.Carrot:
                    ingredient = new CubesSlicedCarrot(10, createTime);
                    break;
                case IngredientTypes.Tomato:
                    ingredient = new CubesSlicedTomato(10, createTime);
                    break;
            }
            return ingredient;
        }
    }
}

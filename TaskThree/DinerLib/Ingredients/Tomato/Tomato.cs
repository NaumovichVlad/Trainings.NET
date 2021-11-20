using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients.Tomato
{
    public class Tomato : Ingredient
    {
        public Tomato(double costPrice, DateTime createTime) : base(costPrice, createTime)
        {
        }

        public override IngredientTypes Type => IngredientTypes.Tomato;

        public override ProcessingTypes ProcessingType => ProcessingTypes.None;
    }
}

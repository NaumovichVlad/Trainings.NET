using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public abstract class Ingredient : IIngredient
    {
        public abstract IngredientTypes Type { get; }
        public abstract ProcessingTypes ProcessingType { get; }
        public double CostPrice { get; set; }

        public Ingredient (double costPrice)
        {
            CostPrice = costPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is Ingredient ingredient &&
                   Type == ingredient.Type &&
                   ProcessingType == ingredient.ProcessingType &&
                   CostPrice == ingredient.CostPrice;
        }

        public override int GetHashCode()
        {
            int hashCode = 977684680;
            hashCode = hashCode * -1521134295 + Type.GetHashCode();
            hashCode = hashCode * -1521134295 + ProcessingType.GetHashCode();
            hashCode = hashCode * -1521134295 + CostPrice.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", ProcessingType, Type);
        }
    }
}

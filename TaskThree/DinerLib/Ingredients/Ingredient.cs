using DinerLib.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    /// <summary>
    /// Ingredient for dish
    /// </summary>
    public abstract class Ingredient : IIngredient, ILoggable
    {
        /// <summary>
        /// Ingredient type
        /// </summary>
        public abstract IngredientTypes Type { get; }
        /// <summary>
        /// Processing type
        /// </summary>
        public abstract ProcessingTypes ProcessingType { get; }
        /// <summary>
        /// Cost price
        /// </summary>
        public double CostPrice { get; set; }
        public DateTime CreateTime { get; set; }
        public string LogType => Type.ToString();

        public Ingredient(double costPrice, DateTime createTime)
        {
            CostPrice = costPrice;
            CreateTime = createTime;
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

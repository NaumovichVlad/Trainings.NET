using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public class Ingredient : IIngredient
    {
        public ProcessingTypes ProcessingType { get; set; }
        public int ProcessingTime { get; set; }
        public DateTime StartOfProcessingTime { get; set; }
        public double CostPrice { get; set; }

        public Ingredient(ProcessingTypes processingType, int processingTime, DateTime startOfProcessingTime, double costPrice)
        {
            ProcessingType = processingType;
            ProcessingTime = processingTime;
            StartOfProcessingTime = startOfProcessingTime;
            CostPrice = costPrice;
        }

        protected Ingredient()
        { }

        public override bool Equals(object obj)
        {
            return Equals(obj as Ingredient);
        }
        public bool Equals(Ingredient ingredient)
        {
            if (ingredient != null)
            {
                if (ProcessingTime == ingredient.ProcessingTime &&
                    ProcessingType == ingredient.ProcessingType &&
                    StartOfProcessingTime - ingredient.StartOfProcessingTime < TimeSpan.FromSeconds(1) &&
                    CostPrice == ingredient.CostPrice)
                {
                    return true;
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProcessingTime, ProcessingType, StartOfProcessingTime);
        }

        public IngredientTypes GetIngredientType()
        {
            return IngredientTypes.Default;
        }
    }
}

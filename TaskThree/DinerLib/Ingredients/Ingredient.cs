using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public class Ingredient : IIngredient
    {
        public string ProcessingType { get; set; }
        public int ProcessingTime { get; set; }
        public DateTime StartOfProcessingTime { get; set; }

        public Ingredient (string processingType, int processingTime, DateTime startOfProcessingTime)
        {
            ProcessingType = processingType;
            ProcessingTime = processingTime;
            StartOfProcessingTime = startOfProcessingTime;
        }

        public Ingredient()
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
                    StartOfProcessingTime == ingredient.StartOfProcessingTime)
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
    }
}

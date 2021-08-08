using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public interface IIngredient
    {
        ProcessingTypes ProcessingType {  get; set; }
        int ProcessingTime {  get; set; }
        DateTime StartOfProcessingTime { get; set; }
        double CostPrice { get; set; }

        IngredientTypes GetIngredientType();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public interface IIngredient
    {
        IngredientTypes Type { get; }
        ProcessingTypes ProcessingType { get; }
        double CostPrice { get; set; }
        DateTime CreateTime { get; set; }
    }
}

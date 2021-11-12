using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.Ingredients
{
    public interface ISlicedIngredient : IIngredient
    {
        SlicingTypes SlicingType { get; }
    }
}

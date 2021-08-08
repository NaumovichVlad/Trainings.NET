using DinerLib.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinerLib.DataAccess
{
    public interface IQueue : IEnumerable
    {
        int Count { get; }
        IIngredient this[int index] { get; set; }
        List<IIngredient> ToList();

        void DeleteFromQueue(IIngredient t);

        void AddToQueue(IIngredient ingredient);

        IIngredient GetLastInQueue();

        void DeleteReadyMade();
    }
}

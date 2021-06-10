using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class PawnAction : IFigureAction
    {
        public bool CheckMove(Vector position, Vector newPosition)
        {
            var flag = false;
            if (!position.Equals(newPosition))
            {

            }
            return flag;
        }
    }
}

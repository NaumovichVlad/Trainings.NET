using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class BishopAction : IFigureAction
    {
        public bool CheckMove(Vector position, Vector newPosition)
        {
            if (!position.Equals(newPosition) &&
                Math.Abs(position.CoordinateX - newPosition.CoordinateX) == Math.Abs(position.CoordinateY - newPosition.CoordinateY)
            )
                return true;
            else
                return false;
        }
    }
}

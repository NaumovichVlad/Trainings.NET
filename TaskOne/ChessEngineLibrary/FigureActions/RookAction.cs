using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class RookAction : IFigureAction
    {
        public bool CheckMove(Vector position, Vector newPosition)
        {
            var flag = false;
            if (!position.Equals(newPosition))
                if (position.CoordinateX == newPosition.CoordinateY || position.CoordinateY == newPosition.CoordinateY)
                    flag = true;
            return flag;
        }
    }
}

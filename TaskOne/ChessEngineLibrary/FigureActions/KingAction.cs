using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class KingAction : IFigureAction
    {
        public bool CheckMove(Vector position, Vector newPosition)
        {
            var flag = false;
            if (!position.Equals(newPosition))
                if (Math.Abs(position.CoordinateX - newPosition.CoordinateX) <= 1 || Math.Abs(position.CoordinateY - newPosition.CoordinateY) <= 1)
                    flag = true;
            return flag;
        }
    }
}

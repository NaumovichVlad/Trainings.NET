using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public interface IFigureAction
    {
        bool CheckMove(Vector position, Vector newPosition);

    }
}


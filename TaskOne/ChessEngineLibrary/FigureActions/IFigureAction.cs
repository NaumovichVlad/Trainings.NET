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
        List<Vector> GetPossibleMoves(Vector position, Vector fieldSize);

    }
}


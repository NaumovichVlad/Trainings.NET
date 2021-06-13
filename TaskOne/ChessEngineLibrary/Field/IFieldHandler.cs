using ChessEngineLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public interface IFieldHandler
    {
        bool CheckCellOccupancy(Vector position, Vector newPosition, IFiguresCollection figures);
    }
}

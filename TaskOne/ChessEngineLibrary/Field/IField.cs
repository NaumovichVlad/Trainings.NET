using ChessEngineLibrary.Figures;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public interface IField
    {
        Vector Size { get; }
        List<Vector> GetPossibleMoves(Vector position, IPlayer player);
        void Move(Vector position, Vector newPosition, IPlayer player);
        IFiguresCollection GetFigures();
        void SetFigures(IFiguresCollection figures);
        ILog GetLog();
    }
}

using ChessEngineLibrary.Field;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Figures
{
    public class Rook : Figure, IFigure
    {
        public Rook(IPlayer owner, Vector position)
            : base(owner, position)
        { }
        public override FigureType GetFigureType()
        {
            return FigureType.Rook;
        }
    }
}

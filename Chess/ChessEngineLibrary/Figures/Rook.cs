using ChessEngineLibrary.Field;
using ChessEngineLibrary.FigureActions;
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
        { 
            Action = new RookAction(); 
        }

        public Rook(Figure figure)
            : base(figure)
        {
            Action = new RookAction();
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Rook;
        }
    }
}

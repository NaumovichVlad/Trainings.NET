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
    public class Pawn : Figure, IFigure
    {
        public Pawn (IPlayer owner, Vector position) 
            : base(owner, position)
        {
            Action = new PawnAction();
        }

        public Pawn(Figure figure)
            : base(figure)
        {
            Action = new PawnAction();
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Pawn;
        }
    }
}

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
    public class Queen : Figure, IFigure
    {
        public Queen(IPlayer owner, Vector position)
            : base(owner, position)
        {
            Action = new QueenAction();
        }

        public Queen(Figure figure)
            : base(figure)
        {
            Action = new QueenAction();
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Queen;
        }
    }
}

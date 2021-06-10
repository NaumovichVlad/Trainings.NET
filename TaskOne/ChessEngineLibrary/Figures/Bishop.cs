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
    public class Bishop : Figure, IFigure
    {
        public Bishop(IPlayer owner, Vector position)
            : base(owner, position)
        {
            Action = new BishopAction();
        }

        public Bishop(Figure figure)
            : base(figure)
        {
            Action = new BishopAction();
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Bishop;
        }
    }
}

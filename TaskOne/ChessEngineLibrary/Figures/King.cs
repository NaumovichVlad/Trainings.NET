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
    public class King : Figure, IFigure
    {
        public King(IPlayer owner, Vector position)
            : base(owner, position)
        {
            Action = new KingAction();
        }

        public King(Figure figure)
            : base(figure)
        {
            Action = new KingAction();
        }

        public override FigureType GetFigureType()
        {
            return FigureType.King;
        }
    }
}

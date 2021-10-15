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
    public class Knight : Figure, IFigure
    {
        public Knight(IPlayer owner, Vector position)
            : base(owner, position)
        {
            Action = new KnightAction();
        }

        public Knight(Figure figure)
            : base(figure)
        {
            Action = new KnightAction();
        }

        public override FigureType GetFigureType()
        {
            return FigureType.Knight;
        }
    }
}

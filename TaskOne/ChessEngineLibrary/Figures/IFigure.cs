using ChessEngineLibrary.Field;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Figures
{
    public interface IFigure
    {
        IPlayer Owner { get; }
        Vector Position { get; }
        bool IsActive { get; }
        bool IsFirstTurn { get; set; }
        void MakePassive();
        FigureType GetFigureType();
    }
}

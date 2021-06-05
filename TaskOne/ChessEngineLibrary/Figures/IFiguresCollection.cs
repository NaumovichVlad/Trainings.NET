using ChessEngineLibrary.Field;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Figures
{
    public interface IFiguresCollection
    {
        void AddFigure(IFigure figure);
        void RemoveFigure(Vector position);
        List<IFigure> GetFiguresByOwner(IPlayer player);
        IFigure GetFigureByPosition(Vector position);
        List<IFigure> GetPassiveFigures();
        List<IFigure> GetFigures();
    }
}

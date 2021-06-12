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
        IFigure GetActiveFigureByPosition(Vector position);
        IFigure GetKing(IPlayer player);
        List<IFigure> GetPassiveFigures();
        List<IFigure> GetActiveFigures();
        List<IFigure> GetFigures();
        IEnumerator<IFigure> GetEnumerator();
    }
}

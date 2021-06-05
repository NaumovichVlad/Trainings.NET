using ChessEngineLibrary.Field;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Figures
{
    public class FigureCollection : IFiguresCollection
    {
        List<IFigure> figures;

        public FigureCollection (List<IFigure> figures)
        {
            this.figures = figures;
        }

        public void AddFigure(IFigure figure)
        {
            figures.Add(figure);
        }

        public List<IFigure> GetFigures()
        {
            return figures;
        }

        public List<IFigure> GetFiguresByOwner(IPlayer player)
        {
            var ownerFigures = figures.Where(f => f.Owner.Username == player.Username).ToList();
            return ownerFigures;
        }

        public IFigure GetFigureByPosition(Vector position)
        {
            var figureByPosition = figures.First(f => f.Position.GetCoordinates() == position.GetCoordinates());
            return figureByPosition;
        }

        public List<IFigure> GetPassiveFigures()
        {
            var passiveFigures = figures.Where(f => !f.IsActive).ToList();
            return passiveFigures;
        }

        public void RemoveFigure(Vector position)
        {
            figures.Remove(figures.First(f => f.Position.GetCoordinates() == position.GetCoordinates()));
        }
    }
}

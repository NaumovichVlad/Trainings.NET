using ChessEngineLibrary.Field;
using ChessEngineLibrary.Players;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Figures
{
    public class FigureCollection : IFiguresCollection, IEnumerable<IFigure>
    {
        List<IFigure> figures;

        public FigureCollection()
        {
            figures = new List<IFigure>();
        }

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
            var ownerFigures = figures.Where(f => f.Owner.Equals(player)).ToList();
            return ownerFigures;
        }

        public IFigure GetKing(IPlayer player)
        {
            var king = figures.First(f => f.GetFigureType() == FigureType.King && f.Owner.Equals(player));
            return king;
        }

        public IFigure GetActiveFigureByPosition(Vector position)
        {
            try
            {
                var activeFigures = figures.Where(f => f.IsActive == true).ToList();
                var figureByPosition = activeFigures.Find(f => f.Position.Equals(position));
                return figureByPosition;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public List<IFigure> GetPassiveFigures()
        {
            var passiveFigures = figures.Where(f => !f.IsActive).ToList();
            return passiveFigures;
        }

        public List<IFigure> GetActiveFigures()
        {
            var passiveFigures = figures.Where(f => f.IsActive).ToList();
            return passiveFigures;
        }

        public void RemoveFigure(Vector position)
        {
            figures.Remove(figures.First(f => f.Equals(position)));
        }

        public IEnumerator<IFigure> GetEnumerator()
        {
            return ((IEnumerable<IFigure>)figures).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)figures).GetEnumerator();
        }
    }
}

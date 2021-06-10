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
    abstract public class Figure
    {
        public IPlayer Owner { get; }
        public bool IsActive { get; private set; }
        public bool IsFirstTurn { get; set; }
        public Vector Position { get; private set; }
        public IFigureAction Action { get; protected set; }

        public Figure(Figure figure)
        {
            Owner = figure.Owner;
            IsActive = figure.IsActive;
            IsFirstTurn = figure.IsFirstTurn;
            Position = figure.Position;
        }
        public Figure(IPlayer owner, Vector position)
        {
            Owner = owner;
            IsActive = true;
            IsFirstTurn = true;
            Position = position;
        }

        public void MakePassive()
        {
            IsActive = false;
            Position = null;
        }
        abstract public FigureType GetFigureType();
    }
}

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
    /// <summary>
    /// Chess piece
    /// </summary>
    abstract public class Figure
    {
        /// <summary>
        /// The player who owns the piece
        /// </summary>
        public IPlayer Owner { get; }
        /// <summary>
        /// Being on the field
        /// </summary>
        public bool IsActive { get; private set; }
        /// <summary>
        /// did the piece move
        /// </summary>
        public bool IsFirstTurn { get; set; }
        /// <summary>
        /// Piece position
        /// </summary>
        public Vector Position { get; private set; }
        /// <summary>
        /// Rules for the course of a chess piece
        /// </summary>
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

        public override bool Equals(object obj)
        {
            return obj is Figure figure &&
                   EqualityComparer<IPlayer>.Default.Equals(Owner, figure.Owner) &&
                   IsActive == figure.IsActive &&
                   IsFirstTurn == figure.IsFirstTurn &&
                   EqualityComparer<Vector>.Default.Equals(Position, figure.Position) &&
                   EqualityComparer<IFigureAction>.Default.Equals(Action, figure.Action);
        }

        public override int GetHashCode()
        {
            int hashCode = -617021294;
            hashCode = hashCode * -1521134295 + EqualityComparer<IPlayer>.Default.GetHashCode(Owner);
            hashCode = hashCode * -1521134295 + IsActive.GetHashCode();
            hashCode = hashCode * -1521134295 + IsFirstTurn.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Vector>.Default.GetHashCode(Position);
            hashCode = hashCode * -1521134295 + EqualityComparer<IFigureAction>.Default.GetHashCode(Action);
            return hashCode;
        }
    }
}

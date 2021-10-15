using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class KnightAction : IFigureAction
    {
        public List<Vector> GetPossibleMoves(Vector position, Vector fieldSize)
        {
            List<Vector> forDelete = new List<Vector>();
            var possiblePositions = new List<Vector>();
            possiblePositions.Add(new Vector(position.CoordinateX + 2, position.CoordinateY + 1));
            possiblePositions.Add(new Vector(position.CoordinateX + 2, position.CoordinateY - 1));
            possiblePositions.Add(new Vector(position.CoordinateX - 2, position.CoordinateY + 1));
            possiblePositions.Add(new Vector(position.CoordinateX - 2, position.CoordinateY - 1));
            possiblePositions.Add(new Vector(position.CoordinateX + 1, position.CoordinateY + 2));
            possiblePositions.Add(new Vector(position.CoordinateX - 1, position.CoordinateY + 2));
            possiblePositions.Add(new Vector(position.CoordinateX + 1, position.CoordinateY - 2));
            possiblePositions.Add(new Vector(position.CoordinateX - 1, position.CoordinateY - 2));

            foreach (var possiblePosition in possiblePositions)
                if (possiblePosition.CoordinateX >= fieldSize.CoordinateX || possiblePosition.CoordinateY >= fieldSize.CoordinateY
                    || possiblePosition.CoordinateX < 0 || possiblePosition.CoordinateY < 0)
                    forDelete.Add(possiblePosition);
            foreach (var delete in forDelete)
                possiblePositions.Remove(delete);
            return possiblePositions;
        }
    }
}

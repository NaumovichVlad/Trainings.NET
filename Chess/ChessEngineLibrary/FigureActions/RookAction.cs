using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class RookAction : IFigureAction
    {
        public List<Vector> GetPossibleMoves(Vector position, Vector fieldSize)
        {
            var possiblePositions = new List<Vector>();
            for (var i = position.CoordinateX + 1; i < fieldSize.CoordinateX; i++)
                possiblePositions.Add(new Vector(i, position.CoordinateY));
            for (var i = position.CoordinateX - 1; i >= 0; i--)
                possiblePositions.Add(new Vector(i, position.CoordinateY));
            for (var j = position.CoordinateY + 1; j < fieldSize.CoordinateY; j++)
                possiblePositions.Add(new Vector(position.CoordinateX, j));
            for (var j = position.CoordinateY - 1; j >= 0; j--)
                possiblePositions.Add(new Vector(position.CoordinateX, j));
            return possiblePositions;
        }
    }
}

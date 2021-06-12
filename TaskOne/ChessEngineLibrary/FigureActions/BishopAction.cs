using ChessEngineLibrary.Field;
using System.Collections.Generic;

namespace ChessEngineLibrary.FigureActions
{
    public class BishopAction : IFigureAction
    {
        public List<Vector> GetPossibleMoves(Vector position, Vector fieldSize)
        {
            var possiblePositions = new List<Vector>();
            for (var i = 0; position.CoordinateX + i < fieldSize.CoordinateX && position.CoordinateY + i < fieldSize.CoordinateY; i++)
                possiblePositions.Add(new Vector(position.CoordinateX + i, position.CoordinateY + i));
            for (var i = 0; position.CoordinateX + i < fieldSize.CoordinateX && position.CoordinateY - i >= 0; i++)
                possiblePositions.Add(new Vector(position.CoordinateX + i, position.CoordinateY - i));
            for (var i = 0; position.CoordinateX - i >= 0 && position.CoordinateY + i < fieldSize.CoordinateY; i++)
                possiblePositions.Add(new Vector(position.CoordinateX - i, position.CoordinateY + i));
            for (var i = 0; position.CoordinateX - i >= 0 && position.CoordinateY - i >= 0; i++)
                possiblePositions.Add(new Vector(position.CoordinateX - i, position.CoordinateY - i));
            possiblePositions.RemoveAll(p => p.CoordinateX == position.CoordinateX && p.CoordinateY == position.CoordinateY);
            return possiblePositions;
        }
    }
}

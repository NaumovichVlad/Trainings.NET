using ChessEngineLibrary.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.FigureActions
{
    public class QueenAction : IFigureAction
    {
        IFigureAction rookAction = new RookAction();
        IFigureAction bishopAction = new BishopAction();
        public List<Vector> GetPossibleMoves(Vector position, Vector fieldSize)
        {
            var firstGroupPossibleActions = rookAction.GetPossibleMoves(position, fieldSize);
            var secondGroupPossibleActions = bishopAction.GetPossibleMoves(position, fieldSize);
            var possibleActions = firstGroupPossibleActions.Concat(secondGroupPossibleActions).ToList();
            return possibleActions;
        }
    }
}

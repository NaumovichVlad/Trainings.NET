using ChessEngineLibrary.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public class FieldHandler : IFieldHandler
    {
        

        public bool CheckCellOccupancy(Vector position, Vector newPosition, IFiguresCollection figures)
        {
            var flag = false;
            if (Math.Abs(position.CoordinateX - newPosition.CoordinateX) < 2 && Math.Abs(position.CoordinateY - newPosition.CoordinateY) < 2)
            {
                flag = true;
            }
            else
            {
                
                if (position.CoordinateX == newPosition.CoordinateX || position.CoordinateY == newPosition.CoordinateY)
                    flag = CheckLine(position, newPosition, figures);
                else
                {
                    if (Math.Abs(position.CoordinateX - newPosition.CoordinateX) == Math.Abs(position.CoordinateY - newPosition.CoordinateY))
                        flag = CheckDiagonal(position, newPosition, figures);
                    else
                    {
                        var newPositionFigure = figures.GetActiveFigureByPosition(newPosition);
                        if (newPositionFigure != null)
                        {
                            flag = newPositionFigure.Owner.FiguresColor != figures.GetActiveFigureByPosition(position).Owner.FiguresColor;
                        }
                        else
                        {
                            flag = true;
                        }
                    }
                }
            }
            return flag;
        }

        private bool CheckLine(Vector position, Vector newPosition, IFiguresCollection figures)
        {
            int minXCoordinate;
            int maxXCoordinate;
            int minYCoordinate;
            int maxYCoordinate;
            if (position.CoordinateX > newPosition.CoordinateX)
            {
                minXCoordinate = newPosition.CoordinateX;
                maxXCoordinate = position.CoordinateX;
            }
            else
            {
                minXCoordinate = position.CoordinateX;
                maxXCoordinate = newPosition.CoordinateX;
            }
            if (position.CoordinateY > newPosition.CoordinateY)
            {
                minYCoordinate = newPosition.CoordinateY;
                maxYCoordinate = position.CoordinateY;
            }
            else
            {
                minYCoordinate = position.CoordinateY;
                maxYCoordinate = newPosition.CoordinateY;
            }
            if (minYCoordinate == maxYCoordinate)
            {
                for (var i = minXCoordinate + 1; i < maxXCoordinate; i++)
                {
                    if (figures.GetActiveFigureByPosition(new Vector(i, minYCoordinate)) != null)
                        return false;
                }
            }
            else
            {
                for (var i = minYCoordinate + 1; i < maxYCoordinate; i++)
                {
                    if (figures.GetActiveFigureByPosition(new Vector(minXCoordinate, i)) != null)
                        return false;
                }
            }
            return true;
        }

        private bool CheckDiagonal(Vector position, Vector newPosition, IFiguresCollection figures)
        {
            if (position.CoordinateX > newPosition.CoordinateX)
            {
                if(position.CoordinateY > newPosition.CoordinateY)
                {
                    for (var i = 1; position.CoordinateX - i > newPosition.CoordinateX; i++)
                        if (figures.GetActiveFigureByPosition(new Vector(position.CoordinateX - i, position.CoordinateY - i)) != null)
                            return false;
                }
                else
                {
                    for (var i = 1; position.CoordinateX - i > newPosition.CoordinateX; i++)
                        if (figures.GetActiveFigureByPosition(new Vector(position.CoordinateX - i, position.CoordinateY + i)) != null)
                            return false;
                }
            }
            else
            {
                if (position.CoordinateY > newPosition.CoordinateY)
                {
                    for (var i = 1; i + position.CoordinateX < newPosition.CoordinateX && position.CoordinateY - i > newPosition.CoordinateY; i++)
                        if (figures.GetActiveFigureByPosition(new Vector(position.CoordinateX + i, position.CoordinateY - i)) != null)
                            return false;
                }
                else
                {
                    for (var i = 1; i + position.CoordinateX < newPosition.CoordinateX; i++)
                        if (figures.GetActiveFigureByPosition(new Vector(position.CoordinateX + i, position.CoordinateY + i)) != null)
                            return false;
                }
            }
            return true;
        }
    }
}

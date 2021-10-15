using ChessEngineLibrary.Figures;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public class Field : IField
    {
        IFieldHandler fieldHandler;
        IFiguresCollection figures = new FigureCollection();
        List<IPlayer> players;
        ILog log = new Log();

        public Vector Size { get; }

        public Field (IPlayer playerOne, IPlayer playerTwo)
        {
            players = new List<IPlayer>() { playerOne, playerTwo };
            Size = new Vector(8, 8);
            InitializeFigures();
            fieldHandler = new FieldHandler();
        }

        private void InitializeFigures()
        {
            foreach (var player in players)
            {
                if (player.FiguresColor == Color.White)
                {
                    for (var i = 0; i < 8; i++)
                        figures.AddFigure(new Pawn(player, new Vector(i, 1)));
                    figures.AddFigure(new Knight(player, new Vector(1, 0)));
                    figures.AddFigure(new Knight(player, new Vector(6, 0)));
                    figures.AddFigure(new Bishop(player, new Vector(2, 0)));
                    figures.AddFigure(new Bishop(player, new Vector(5, 0)));
                    figures.AddFigure(new Rook(player, new Vector(0, 0)));
                    figures.AddFigure(new Rook(player, new Vector(7, 0)));
                    figures.AddFigure(new Queen(player, new Vector(3, 0)));
                    figures.AddFigure(new King(player, new Vector(4, 0)));
                }
                else
                {
                    for (var i = 0; i < 8; i++)
                        figures.AddFigure(new Pawn(player, new Vector(i, 6)));
                    figures.AddFigure(new Knight(player, new Vector(1, 7)));
                    figures.AddFigure(new Knight(player, new Vector(6, 7)));
                    figures.AddFigure(new Bishop(player, new Vector(2, 7)));
                    figures.AddFigure(new Bishop(player, new Vector(5, 7)));
                    figures.AddFigure(new Rook(player, new Vector(0, 7)));
                    figures.AddFigure(new Rook(player, new Vector(7, 7)));
                    figures.AddFigure(new Queen(player, new Vector(3, 7)));
                    figures.AddFigure(new King(player, new Vector(4, 7)));
                }
            }
        }

        public List<Vector> GetPossibleMoves(Vector position, IPlayer player)
        {
            List<Vector> possibleMoves = null;
            List<Vector> deleteMoves = new List<Vector>();
            var figure = figures.GetActiveFigureByPosition(position);
            if (figure.Owner.Equals(player))
            {
                possibleMoves = figure.Action.GetPossibleMoves(figure.Position, Size);
                foreach (var possibleMove in possibleMoves)
                    if (!fieldHandler.CheckCellOccupancy(figure.Position, possibleMove, figures))
                        deleteMoves.Add(possibleMove);

                foreach (var possibleMove in possibleMoves)
                    if (figures.GetActiveFigureByPosition(possibleMove) != null)
                        if(figures.GetActiveFigureByPosition(possibleMove).Owner.Equals(player))
                            deleteMoves.Add(possibleMove);
            }
            foreach (var delete in deleteMoves)
                possibleMoves.Remove(delete);
            return possibleMoves;
        }
        
        public void Move(Vector position, Vector newPosition, IPlayer player)
        {
            if (figures.GetActiveFigureByPosition(newPosition) != null)
            {
                var opponentFigure = figures.GetActiveFigureByPosition(newPosition);
                opponentFigure.MakePassive();
            }
            var figure = figures.GetActiveFigureByPosition(position);
            figure.Position.ChangeCoordinates(newPosition.CoordinateX, newPosition.CoordinateY);
            log.AddTurn(figure);
        }

        public IFiguresCollection GetFigures()
        {
            return figures;
        }

        public void SetFigures(IFiguresCollection figures)
        {
            this.figures = figures;
        }

        public ILog GetLog()
        {
            return log;
        }
    }
}

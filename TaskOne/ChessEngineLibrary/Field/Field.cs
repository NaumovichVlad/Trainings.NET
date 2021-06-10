using ChessEngineLibrary.Figures;
using ChessEngineLibrary.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineLibrary.Field
{
    public class Field
    {
        IFiguresCollection figures = new FigureCollection();
        List<IPlayer> players;

        public Vector Size { get; }

        public Field (IPlayer playerOne, IPlayer playerTwo)
        {
            players = new List<IPlayer>() { playerOne, playerTwo };
            Size = new Vector(7, 7);
            InitializeFigures();
        }

        private void InitializeFigures()
        {
            foreach (var player in players)
            {
                if (player.FiguresColor == Color.White)
                {
                    for (var i = 0; i < 7; i++)
                        figures.AddFigure(new Pawn(player, new Vector(i, 1)));
                    figures.AddFigure(new Knight(player, new Vector(1, 0)));
                    figures.AddFigure(new Knight(player, new Vector(6, 0)));
                    figures.AddFigure(new Bishop(player, new Vector(2, 0)));
                    figures.AddFigure(new Bishop(player, new Vector(5, 0)));
                    figures.AddFigure(new Rook(player, new Vector(0, 0)));
                    figures.AddFigure(new Rook(player, new Vector(7, 0)));
                    figures.AddFigure(new Knight(player, new Vector(3, 0)));
                    figures.AddFigure(new Knight(player, new Vector(4, 0)));
                }
                else
                {
                    for (var i = 0; i < 7; i++)
                        figures.AddFigure(new Pawn(player, new Vector(i, 6)));
                    figures.AddFigure(new Knight(player, new Vector(1, 7)));
                    figures.AddFigure(new Knight(player, new Vector(6, 7)));
                    figures.AddFigure(new Bishop(player, new Vector(2, 7)));
                    figures.AddFigure(new Bishop(player, new Vector(5, 7)));
                    figures.AddFigure(new Rook(player, new Vector(0, 7)));
                    figures.AddFigure(new Rook(player, new Vector(7, 7)));
                    figures.AddFigure(new Knight(player, new Vector(3, 7)));
                    figures.AddFigure(new Knight(player, new Vector(4, 7)));
                }
            }
        }

        /*
        public List<Vector> FigureSelectedAction(Vector position, IPlayer player)
        {
            List<Vector> positions;
            var figure = figures.GetFigureByPosition(position);
            if (figure != null && figure.Owner.FiguresColor == player.FiguresColor)
            {

            }
            return positions;
        }
        */
    }
}

using ChessEngineLibrary;
using ChessEngineLibrary.Field;
using ChessEngineLibrary.Figures;
using ChessEngineLibrary.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessEngineLibraryTests
{
    [TestClass]
    public class ActionsTests
    {
        [TestMethod]
        public void KnightTestOne()
        {
            IPlayer playerOne = new Player("vladislav", Color.White);
            IPlayer playerTwo = new Player("vlad", Color.Black);
            IField field = new Field(playerOne, playerTwo);
            field.Move(new Vector(1, 0), new Vector(7, 2), playerOne);
            var figures = field.GetFigures();
            var actual = figures.GetActiveFigureByPosition(new Vector(7, 2));
            Assert.AreEqual(null, actual);
        }


        [TestMethod]
        public void RookTest()
        {
            IPlayer playerOne = new Player("vladislav", Color.White);
            IPlayer playerTwo = new Player("vlad", Color.Black);
            IField field = new Field(playerOne, playerTwo);
            IFiguresCollection figures = new FigureCollection();
            figures.AddFigure(new Rook(playerOne, new Vector(2, 2)));
            field.SetFigures(figures);
            field.Move(new Vector(2, 2), new Vector(2, 7), playerOne);
            var fig = field.GetFigures();
            var actual = fig.GetActiveFigureByPosition(new Vector(2, 7)).GetFigureType();
            var expected = FigureType.Rook;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PawnTest()
        {
            IPlayer playerOne = new Player("vladislav", Color.White);
            IFigure figure = new Pawn(playerOne, new Vector(0, 0));
            var moves = figure.Action.GetPossibleMoves(new Vector(1 , 0), new Vector(7, 7));
            var actual = moves.Count;
            var expected = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BishopTest()
        {
            IPlayer playerOne = new Player("vladislav", Color.White);
            IPlayer playerTwo = new Player("vlad", Color.Black);
            IField field = new Field(playerOne, playerTwo);
            IFiguresCollection figures = new FigureCollection();
            figures.AddFigure(new Bishop(playerOne, new Vector(2, 2)));
            field.SetFigures(figures);
            field.Move(new Vector(2, 2), new Vector(6, 6), playerOne);
            var fig = field.GetFigures();
            var actual = fig.GetActiveFigureByPosition(new Vector(6, 6)).GetFigureType();
            var expected = FigureType.Bishop;
            Assert.AreEqual(expected, actual);
        }
    }
}

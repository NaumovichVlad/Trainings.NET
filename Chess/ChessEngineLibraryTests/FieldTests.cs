using ChessEngineLibrary;
using ChessEngineLibrary.Field;
using ChessEngineLibrary.Figures;
using ChessEngineLibrary.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessEngineLibraryTests
{
    [TestClass]
    public class FieldTests
    {
        [TestMethod]
        public void AttackTest()
        {
            IPlayer playerOne = new Player("vladislav", Color.White);
            IPlayer playerTwo = new Player("vlad", Color.Black);
            IField field = new Field(playerOne, playerTwo);
            IFiguresCollection figures = new FigureCollection();
            figures.AddFigure(new Rook(playerOne, new Vector(2, 2)));
            figures.AddFigure(new Bishop(playerTwo, new Vector(2, 7)));
            field.SetFigures(figures);
            field.Move(new Vector(2, 2), new Vector(2, 7), playerOne);
            var fig = field.GetFigures();
            var actual = fig.GetActiveFigureByPosition(new Vector(2, 7)).GetFigureType();
            var expected = FigureType.Rook;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MoveTest()
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
    }
}

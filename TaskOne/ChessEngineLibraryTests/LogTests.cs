using ChessEngineLibrary;
using ChessEngineLibrary.Field;
using ChessEngineLibrary.Figures;
using ChessEngineLibrary.Players;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ChessEngineLibraryTests
{
    [TestClass]
    public class LogTests
    {
        [TestMethod]
        public void AddTurn_Test()
        {
            ILog log = new Log();
            IPlayer player = new Player("vladislav", Color.White);
            var position = new Vector(1, 2);
            IFigure figure = new Pawn(player, position);
            log.AddTurn(figure);
            var expected = "White Pawn b3 > ";
            var actual = log.GetLog();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void LoadLog_Test()
        {
            ILog log = new Log();
            IPlayer player = new Player("vladislav", Color.White);
            var position = new Vector(1, 2);
            IFigure figure = new Pawn(player, position);
            log.AddTurn(figure);
            figure.Position.ChangeCoordinates(1, 3);
            log.AddTurn(figure);
            log.SaveLog("testlog");
            log = new Log();
            log.LoadLog("testlog");
            var expected = "White Pawn b3 > White Pawn b4 > ";
            var actual = log.GetLog();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Log_Test()
        {
            IPlayer playerOne = new Player("vladislav", Color.White);
            IPlayer playerTwo = new Player("vova", Color.Black);
            IField field = new Field(playerOne, playerTwo);
            field.Move(new Vector(1, 0), new Vector(0, 2), playerOne);
            field.Move(new Vector(6, 7), new Vector(5, 5), playerTwo);
            var expected = "White Knight a3 > Black Knight f6 > ";
            var actual = field.GetLog().GetLog();
            Assert.AreEqual(expected, actual);
        }
    }
}
